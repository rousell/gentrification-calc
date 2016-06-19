angular.module('app', []);

angular.module('app').factory('leaflet', [
            '$q',
    function ($q) {
        var deferred = $q.defer();
        return {
            map: deferred.promise,
            resolve: function (element) {
                deferred.resolve(new L.Map(element));
            }
        }
    }
]);

angular.module('app').directive('leaflet', [
            'leaflet',
    function (leaflet) {
        return {
            replace: true,
            template: '<div></div>',
            link: function (scope, element, attributes) {
                leaflet.resolve(element[0]);
            }
        }
    }
]);

angular.module('app').controller('rootController', [
            '$scope', 'leaflet',
    function ($scope, leaflet) {
        leaflet.map.then(function (map) {
            L.tileLayer('http://api.tiles.mapbox.com/v4/{id}/{z}/{x}/{y}.png?access_token={accessToken}', {
                attribution: 'Map data &copy; <a href="http://openstreetmap.org">OpenStreetMap</a> contributors, <a href="http://creativecommons.org/licenses/by-sa/2.0/">CC-BY-SA</a>, Imagery © <a href="http://mapbox.com">Mapbox</a>',
                maxZoom: 18,
                id: 'mapbox.streets',
                accessToken: 'pk.eyJ1IjoibHJvdXNlIiwiYSI6ImNpaHBnYmkxaDA0NGJ0c20yMG5sMmZlenIifQ.NVpXXlzfBCtK00m36zp68Q'
            }).addTo(map);
            map.setView([36.1666, -86.7833], 12);
            L.marker([36.1666, -86.7833]).addTo(map);
            L.circle([36.1666, -86.7833],{
                color: 'red',
                fillColor: '#f03',
                fillOpacity: 0.5
            }).addTo(map);    
        });
    }
]);