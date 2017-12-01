using AutoMapper;
using Dietitian.Core.Entities;
using Dietitian.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dietitian.Web.Mappings
{
    public class AutoMapperConfiguration : Profile
    {
        private static MapperConfiguration _mapperConfiguration;
        private static IMapper _mapper;

        public static IMapper Mapper
        {
            get
            {
                if (_mapper != null) return _mapper;
                if (_mapperConfiguration == null)
                    Configure();

                _mapper = _mapperConfiguration.CreateMapper();
                return _mapper;
            }
            set { _mapper = value; }
        }


        public static void Configure()
        {
            _mapperConfiguration = new MapperConfiguration(configure =>
            {
                configure.CreateMap<Customer, CustomerViewModel>();
                configure.CreateMap<CustomerViewModel, Customer>();
                //configure.CreateMap<IEnumerable<Customer>,IEnumerable<CustomerViewModel>>();
            });

        }
    }
}