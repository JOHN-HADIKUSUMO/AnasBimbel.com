var appAB = angular.module('appAB',[]);

var kirimEmailCtrl = appAB.controller("kirimEmailCtrl", ['$scope', '$http', 'emailService', function ($scope, $http, emailService) {
    $scope.nama = null;
    $scope.telepon = null;
    $scope.email = null;
    $scope.perihal = null;
    $scope.pesan = null;
    $scope.reset = function () {
        $scope.nama = null;
        $scope.formEmail.nama.$dirty = false;
        $scope.formEmail.nama.$valid = true;
        $scope.formEmail.nama.$pristine = true;
        $scope.telepon = null;
        $scope.formEmail.telepon.$dirty = false;
        $scope.formEmail.telepon.$valid = true;
        $scope.formEmail.telepon.$pristine = true;
        $scope.email = null;
        $scope.formEmail.email.$dirty = false;
        $scope.formEmail.email.$valid = true;
        $scope.formEmail.email.$pristine = true;
        $scope.perihal = null;
        $scope.formEmail.perihal.$dirty = false;
        $scope.formEmail.perihal.$valid = true;
        $scope.formEmail.perihal.$pristine = true;
        $scope.pesan = null;
        $scope.formEmail.pesan.$dirty = false;
        $scope.formEmail.pesan.$valid = true;
        $scope.formEmail.pesan.$pristine = true;
    };
    $scope.kirimEmail = function () {
        var obj = {
            Name: $scope.nama,
            Telephone: $scope.telepon,
            Email: $scope.email,
            Subject: $scope.perihal,
            Message: $scope.pesan
        };
        emailService.kirim(obj)
        .then(function (response) {
            alert("sukses");
        })
        .catch(function (response) { })
        .finally(function (response) {
            $scope.reset();
        })
    };
}]);

var kirimSMSCtrl = appAB.controller("kirimSMSCtrl", ['$scope', '$http', function ($scope, $http) {
    $scope.kirimSMS = function () {
        alert('Kirim SMS doank');
    };
}]);



var emailService = appAB.factory('emailService', ['$http', function ($http) {
    var emailService = {
        kirim: function (data) {
            return $http.post('/API/EMAIL/KIRIM', data);
        }
    };

    return emailService;
}]);

var artikelService = appAB.factory('artikelService', ['$http', function ($http) {
    var artikelService = {
        cari: function () {
            return $http.get('/API/ARTIKEL/CARI');
        }
    };

    return artikelService;
}]);

var artikel = appAB.directive('artikel', ['$timeout', 'artikelService', function ($timeout, artikelService) {
    var artikelCtl = function ($scope, $rootScope, $element) {
        $scope.init = function () {
            artikelService.cari()
            .then(function (response)
            {
                $scope.data = response.data;
            })
            .catch(function (response) {

            })
            .finally(function (response) {
               
            })
        };
        $scope.init();
    };

    return {
        restrict: 'AE',
        replace: 'true',
        templateUrl: '/scripts/templates/artikel.html',
        controller: artikelCtl
    };
}]);
