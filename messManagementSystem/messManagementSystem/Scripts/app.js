var RidePoolrApp = angular.module("RidePoolrApp", ["ngResource"]).
    config(function ($routeProvider) {
        $routeProvider.
            when('/', { controller: OfferListCtrl, templateUrl: 'ShowOffers.html' }).
            otherwise({ redirectTo: '/' });
    });

RidePoolrApp.factory('Offers', function ($resource) {
    return $resource('/api/OfferAPI/GetOffers', null, { update: { method: 'GET' } });
});

var OfferListCtrl = function ($scope, $location, Offers) {  

    $scope.reset = function () {
        $scope.Offers = Offers.query({ search: $scope.query });
    }   
    $scope.reset();
};