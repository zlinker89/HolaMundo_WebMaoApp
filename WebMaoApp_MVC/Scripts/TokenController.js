'use strict';
app.controller('TokenCtrl', ["$scope", "$http", "TokenService", function ($scope, $http, TokenService) {
    $scope.Dispositivos = [];
    $scope.obj = {
        title: '',
        body: ''
    };
    $scope.enviando = false;
    $scope.Cuenta = 0;
    $scope.Total = 0;
    function _init() {
        TokenService.getDispositivos().then(function (d) {
            console.log(d);
            $scope.Dispositivos = d.data;
            $scope.Total = d.data.length;
        },
        function (e) {
            alert(e);
        });
    }
    _init();
    $scope.SendMensaje = function () {
        if ($scope.obj.title != '' && $scope.obj.body != '') {
            $scope.enviando = true;
            for (var i in $scope.Dispositivos) {
                console.log($scope.Dispositivos[i]);
                TokenService.postMensaje($scope.obj, $scope.Dispositivos[i].Token).then(function (d) {
                    $scope.Cuenta += 1;
                    console.log(d.data);
                }, function (e) {
                    console.log(e);
                });
            }
        }
    }
}]);