(function(){

    'use strict';

    angular
        .module("GentrificationCalcApp", [])
        .factory('MapService', MapService)
        .directive('leaflet', leaflet)
        .controller('MapCtrl', MapCtrl);

    function MapService ($q) {
        var deferred = $q.defer();
        return {
            map: deferred.promise,
            resolve: function (element) {
                deferred.resolve(new L.Map(element));
            }
        }
    }
    
    function leaflet (MapService) {
        return {
            replace: true,
            template: '<div></div>',
            link: function (scope, element, attributes) {
                MapService.resolve(element[0]);
            }
        };
    }

    function MapCtrl($scope, leaflet) {
        //var mymap = L.map('mapid').setView([51.505, -0.09], 13);

        leaflet.map.then(function (map) {
            var tileLayer = L.tileLayer('http://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {
                attribution: '&copy; <a href="http://www.openstreetmap.org/copyright">OpenStreetMap</a>',
                maxZoom: 18
            }).addTo(map);
            map.setView([0, 0], 1);
            L.marker([0, 0]).addTo(map);
        });
    }

    /*angular.module('app').config([
  '$stateProvider',
  '$urlRouterProvider',
  function ($stateProvider, $urlRouterProvider) {
      $urlRouterProvider.otherwise('/');
      $stateProvider.state('root', {
          'url': '/',
          'controller': 'rootController',
          'template': '<leaflet></leaflet>'
      });
  }
    ]);*/


})();