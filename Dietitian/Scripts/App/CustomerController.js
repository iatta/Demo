DietitianApp.controller("CustomerController", function ($scope, Notification, $uibModal, $document, CustomerService) {

    $scope.initCustomers = function () {
        $scope.getCustomers();
    }
    
    $scope.getCustomers = function(){
        CustomerService.getCustomers()
                 .then(function (response) {
                     if (response.data.Success) {
                         $scope.customers = response.data.Result;
                     } else {
                         Notification.error(response.data.Result);
                     }
                 });
    }

    //Delete
    $scope.confirmDeleteCustomer = function (customer) {
        CustomerService.deleteCustomer(customer.Id)
          .then(function (response) {
              if (response.data.success) {
                  var index = $scope.customers.indexOf(customer);
                  if (index != -1) {
                      $scope.customers.splice(index, 1);

                      Notification.success('Deleted Successfully');
                  }
              }
          });
    }


    $scope.deleteCustomer= function (customer) {
        swal({
            title: 'Are you Sure You want to delete this customer',
            type: "warning",
            showCancelButton: true,
            confirmButtonColor: "#DD6B55",
            confirmButtonClass: "btn-danger",
            confirmButtonText:'Yes Delete' ,
            cancelButtonText: 'Cancel',
            closeOnConfirm: true,
            closeOnCancel: true
        },
        function (isConfirm) {
            if (isConfirm) {
                $scope.confirmDeleteCustomer(customer);
            }
        });
    }


    $scope.openCustomerModal = function (customer) {
        var modalInstance = $uibModal.open({
            templateUrl: 'stackedModal.html',
            controller: 'ModalInstanceCtrl',
            windowClass: 'center-modal',
            size: 'lg',
            backdrop: 'static',
            keyboard: false,
            resolve: {
                params: function () {
                    return {
                        parentScope: $scope,
                        customer: customer
                    }
                }
            }
        });
    }

    

}).factory("CustomerService", ['$http', function ($http) {

    var fac = {};
    fac.addCustomer = function () {

    }

    fac.getCustomers = function () {
        return $http.get('/Customers/GetCustomers');
    }

    fac.addCustomer = function (customer) {
        return $http.post('/Customers/AddCustomer', customer);
    }

    fac.updateCustomer = function (customer) {
        return $http.post('/Customers/UpdateCustomer', customer);
    }
    fac.deleteCustomer = function (id) {
        return $http.get('/Customers/DeleteCustomer/'+id);
    }

    return fac;
}]);

DietitianApp.controller('ModalInstanceCtrl', ["$scope", "Notification", "$uibModalInstance", "params", "CustomerService",
    function ($scope, Notification, $uibModalInstance, params, CustomerService) {

        $scope.customer = angular.copy(params.customer);
        if (typeof $scope.customer != 'undefined') {
            $scope.customer.DateOfBirth = new Date($scope.customer.DateOfBirth);
        }
       

        //Save
       $scope.saveCustomer = function () {
           if ($scope.customer.Id && $scope.customer.Id > 0) {
               $scope.updateCustomer();
           } else {
               $scope.addCustomer();
           }
       }

       $scope.addCustomer = function () {
           CustomerService.addCustomer($scope.customer)
                   .then(function (response) {
                       if (response.data.Success) {
                           Notification.success('Added Successfully');
                           $scope.cancel();
                           $scope.customer.Id = response.data.Result.Id;
                           params.parentScope.customers.push($scope.customer);
                       }
                   });
       }

       $scope.updateCustomer = function () {
           CustomerService.updateCustomer($scope.customer)
                   .then(function (response) {
                       if (response.data.Success) {
                           $scope.cancel();
                           Notification.success('Updates Successfully');
                       }
                   });
       }


        $scope.cancel = function () {
        $uibModalInstance.dismiss('cancel');
    };
}]);