"use strict"; var app = angular.module("webMaoApp", ["angular-loading-bar", "ngAnimate", "ngCookies", "ngResource", "ngRoute", "ngSanitize", "ngTouch", "monospaced.qrcode"]).config(["$routeProvider", "$locationProvider", function (a, b) { b.hashPrefix(""), a.when("/", { templateUrl: "views/qr_generator.html", controller: "QRgeneratorCtrl", controllerAs: "QRgenerator" }).otherwise({ redirectTo: "/" }) }]); app.config(['cfpLoadingBarProvider', function (cfpLoadingBarProvider) {
    cfpLoadingBarProvider.includeSpinner = true;
}]);app.controller("QRgeneratorCtrl",["$scope",function(a){a.n_mesas=[],a.ID_mesa="",a.GenerarQR=function(){a.n_mesas=[];var b=a.ID_mesa;if(""!=b&&a.host)if(b.includes(",")||b.includes("-")){if(b.includes(",")){var c=b.split(",");for(var d in c)if(c[d].includes("-"))for(var e=c[d].split("-"),f=e[0];f<=e[1];f++)a.n_mesas.push(f);else a.n_mesas.push(c[d])}else if(b.includes("-"))for(var e=b.split("-"),f=e[0];f<=e[1];f++)a.n_mesas.push(f)}else a.n_mesas.push(b)},a.printDiv=function(){$.print("#printable")}}]),angular.module("webMaoApp").run(["$templateCache",function(a){a.put("views/qr_generator.html",'<div id="QR_page"> <div class="row"> <div class="col-sm-8 col-sm-offset-2"> <form> <div class="form-group"> <label for="exampleInputEmail1" style="color:white">ID de la mesa(s):</label> <input type="text" class="form-control" ng-model="ID_mesa" size="45" id="exampleInputEmail1" placeholder="Ingresar el ID de las mesas. Ej:5,2,8,9,10 ó 1-9"> </div> <div class="form-group"> <label for="host" style="color:white">URL:</label> <input type="text" class="form-control" ng-model="host" size="45" id="host" placeholder="Ej: http://192.168.1.12/prueba.asmx"> </div> <button class="btn btn-success" ng-click="GenerarQR()">Generar</button> </form> </div> </div> <div style="cursor: pointer; position: fixed; bottom: 0; right: 0; width: 50px;height: 50px; padding: 5px 5px 5px 5px; font-size: 2em; border-radius: 100px;background: seagreen;text-align: center; color: white" ng-if="n_mesas.length > 0" ng-click="printDiv()"> <i class="fa fa-print"></i> </div> <div class="row"> <div class="col-sm-12" id="printable"> <br> <div class="col-sm-4 text-center" ng-repeat="m in n_mesas track by $index"> <h3 style="color:white"><strong>Mesa ID: {{m}}</strong></h3> <div style="padding: 10px;border: 2px dashed black"> <qrcode data="{{host}}$_${{m}}" error-correction-level="H" size="200"></qrcode> </div> </div> </div> </div> <div style="clear: both"></div> </div>')}]);