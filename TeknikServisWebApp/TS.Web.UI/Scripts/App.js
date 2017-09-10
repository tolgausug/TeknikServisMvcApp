﻿
/// <reference path="angular.js"/>
/// <reference path="angular-material.js"/>

var app = angular.module("admin", ['ngMaterial']);

app.factory("api", function ($http, $location) {
    var apiurl = "http://localhost:57108/Yonetim/"; //Değişecek
    var baseUrl = $location.$$protocol + "://" + $location.$$host;
    if ($location.$$port)
        baseUrl += ":" + $location.$$port
    console.log($location);
    console.log(baseUrl);
    return {
        urunkategoriekle: function (model, success) {
            $http({
                url: apiurl + 'Kategori/Ekle',
                data: model,
                method: 'POST',
                dataType: 'JSON'
            }).then(function (response) {
                success(response.data);
            });
        },
        urunkategorilerigetir: function (success) {
            $http({
                url: apiurl + 'Kategori/Getir',
                method: 'GET',
                dataType: 'JSON'
            }).then(function (response) {
                success(response.data);
            });
        },
        urunkategoriguncelle: function (model, success) {
            $http({
                url: apiurl + 'Kategori/Guncelle',
                data: model,
                method: 'POST',
                dataType: 'JSON'
            }).then(function (response) {
                success(response.data);
            });
        },
        urunkategorisil: function (id, success) {
            $http({
                url: apiurl + 'Kategori/Sil/' + id,
                method: 'POST',
                dataType: 'JSON'
            }).then(function (response) {
                success(response.data);
            });
        },

        arizalarigetir: function (success) {
            $http({
                url: apiurl + 'Ariza/Arizalar',
                method: 'GET',
                dataType: 'JSON'
            }).then(function (response) {
                success(response.data);
            });
        },
    }
});

app.controller("KategoriCtrl",
    function ($scope, api, $mdDialog) {
        $scope.yukleniyor = false;
        $scope.kategori = {};
        $scope.kategoriler = [];
        $scope.duzenlenecek = null;
        function init() {
            $scope.yukleniyor = true;
            api.urunkategorilerigetir(function (data) {
                $scope.kategoriler = data;
                $scope.yukleniyor = false;
            });
        }
        $scope.ekle = function () {
            console.log($scope.kategori);
            $scope.yukleniyor = true;
            api.urunkategoriekle($scope.kategori,
                function (data) {
                    init();
                    console.log(data);
                    //alert(data.message);
                    $mdDialog.show(
                        $mdDialog.alert()
                            .parent(angular.element(document.querySelector('#maindiv')))
                            .clickOutsideToClose(false)
                            .title('Add new Category')
                            .textContent(data.message)
                            .ok('Okay')
                    );
                    $scope.yukleniyor = false;
                });
        }
        $scope.duzenle = function (kategori) {
            $scope.duzenlenecek = {
                Id: kategori.Id,
                KategoriAdi: kategori.KategoriAdi,
                Aciklama: kategori.Aciklama
            };
        }
        $scope.guncelle = function () {
            $scope.yukleniyor = true;
            api.urunkategoriguncelle($scope.duzenlenecek,
                function (data) {
                    console.log(data);
                    init();
                    alert(data.message);
                    if (data.success === true)
                        $scope.duzenlenecek = null;
                    $scope.yukleniyor = false;
                });
        }
        $scope.sil = function (id) {
            $scope.yukleniyor = true;
            api.urunkategorisil(id,
                function (data) {
                    console.log(data);
                    init();
                    alert(data.message);
                    $scope.yukleniyor = false;
                });
        }
        init();
    });
app.controller("ArizaCtrl",
    function ($scope, api, $mdDialog) {
        $scope.yukleniyor = false;
        $scope.ariza = {};
        $scope.arizalar = [];
        function init() {
            $scope.yukleniyor = true;
            api.arizalarigetir(function (data) {
                $scope.arizalar = data;
                $scope.yukleniyor = false;
            });
        }
        init();
    });

