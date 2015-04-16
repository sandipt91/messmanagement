 
var module = angular.module("HomeDashboard", ['ngCookies']); 
 
module.config(function ($routeProvider) {
     
    $routeProvider.when("/allCustomer/", {
        controller: "customerController",
        templateUrl: "/templates/AllCustomer.html"
    });

    $routeProvider.when("/DeleteCustomer/", {
        controller: "customerController",
        templateUrl: "/templates/AllCustomer.html"
    });

    $routeProvider.when("/CreateCustomer/", {
        controller: "customerController",
        templateUrl: "/templates/CreateCustomer.html"
    });

    $routeProvider.when("/EditViewCustomer/", {
        controller: "customerController",
        templateUrl: "/templates/EditCustomer.html"
    });
    
    $routeProvider.otherwise("/");
});
  


module.factory('CustomerFactory', function ($http) {
    return {
        createCustomer: function (event) {
            var url = "/api/customerapi/createcustomer";
            return $http.post(url, event);
        },
    };
});

module.factory('custEditFactory', function ($http) {
    return { 
        editCustomer: function (event) {
            var url = "/api/customerapi/editcustomer";
            return $http.post(url, event);
        },
    };

});

function customerController($scope, $routeParams, $http, $window, CustomerFactory,custEditFactory, $location, $cookieStore, $rootScope)
{
    debugger;

    $scope.allCustomer = function () {
        debugger;
        $http.get("/api/customerapi/getallcustomers")
        .then(function (result) {
            $scope.customers = result.data;
        },
        function () {
            alert("Error, while fetching the my customer..");
        });
    }  
      
    $scope.DeleteCustomer = function (cust) {
        debugger;
        
        var id = cust.custId;

        $http.get("/api/customerapi/deletecustomer?id=" + id)
            .then(function (result) {
                var data = result.data;
                if (data == 0)
                    alert("Unable to delete an customer");
                else
                    $scope.allCustomer();
            },
            function () {
                alert("Error, while deleting an cuser.");

            });
    }


    $scope.CreateCustomer = function () {

        $scope.event = {};
        
        $scope.event.custFirstName = "ABC";
        $scope.event.custLastName = "XYZ";
        $scope.event.custContactNo = "9999999999";
        $scope.event.custAddress = "Dubai";
        $scope.event.custEmail = "abc@def.com"; 
        $location.path('/CreateCustomer/');
    }

    
    $scope.EditSaveCustomer = function ()
    {
        debugger;
        custEditFactory.editCustomer($scope.event).success(successPostCallback).error(errorCallback);
    }

    $scope.SaveCustomer = function ()
    {
        debugger;
        CustomerFactory.createCustomer($scope.event).success(successPostCallback).error(errorCallback);
    }

    var successPostCallback = function (data, status, headers, config) {
        alert(data);
        //$location.path('/CreateCustomer/'); 
        $location.path('/allCustomer/');
    };

    var errorCallback = function (data, status, headers, config) {
        alert(data.ExceptionMessage);
    };


    $scope.EditViewCustomer = function (cust) {
        debugger;
       // $scope.abc = this.cust;
        $cookieStore.put('myFavorite', cust);
        EditcustomerController($scope, $cookieStore, $location);
        
        //$location.path('/EditViewCustomer/');
         
    }

    $scope.allCustomer();
   
}

function EditcustomerController($scope, $cookieStore, $location)
{
    var abc = $cookieStore.get('myFavorite');
    $scope.event = abc; 
    $location.path('/EditViewCustomer/');
}