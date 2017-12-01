using Dietitian.Core.Exceptions;
using Dietitian.Web.Helpers;
using log4net;
using log4net.Core;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Dietitian.Web.Controllers
{
    public class BaseController : Controller
    {
        protected ILog Logger
        {
            get { return LogManager.GetLogger(GetType()); }
        }

        public BaseController()
        {
            
        }

        protected ActionResult AjaxResponse(bool success, dynamic result)
        {
            return Content(JsonConvert.SerializeObject(new AjaxResponse { Success = success, Result = result })
                , "application/json",
                Encoding.UTF8);
        }
        protected override void OnException(ExceptionContext filterContext)
        {
            if (filterContext.Exception is DietitionException)
            {
                filterContext.ExceptionHandled = true;
                filterContext.Result = Content(JsonConvert.SerializeObject(new AjaxResponse
                {
                    Success = false,
                    Result = filterContext.Exception.Message
                }), "application/json", Encoding.UTF8);

                Logger.Error(filterContext.Exception.Message);
            }
            //No further processing when the exception is handled or custom errors are not enabled.
            if (filterContext.ExceptionHandled || !filterContext.HttpContext.IsCustomErrorEnabled)
            {
                return;
            }

            if (!(filterContext.Exception is DietitionException))
            {
                //Changing exception type to a generic exception
                filterContext.Exception = new Exception
            ("An error occurred and logged during processing of this application.");
                
            }
            

            base.OnException(filterContext);
        }
    }
}