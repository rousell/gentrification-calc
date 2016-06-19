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
            L.tileLayer('http://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {
                attribution: '&copy; <a href="http://www.openstreetmap.org/copyright">OpenStreetMap</a>',
                maxZoom: 18
            }).addTo(map);
            map.setView([36.1666, -86.7833], 12);
            L.marker([36.1666, -86.7833]).addTo(map);
            L.polygon([
                [36.18, -86,78],
                [36.19, -86,78],
                [36.18, -86,8]
            ]).addTo(map);    
        });
    }
]);