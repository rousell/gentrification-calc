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
            '$scope', 'leaflet', '$http',
    function ($scope, leaflet, $http) {
        leaflet.map.then(function (map) {
            L.tileLayer('http://api.tiles.mapbox.com/v4/{id}/{z}/{x}/{y}.png?access_token={accessToken}', {
                attribution: 'Map data &copy; <a href="http://openstreetmap.org">OpenStreetMap</a> contributors, <a href="http://creativecommons.org/licenses/by-sa/2.0/">CC-BY-SA</a>, Imagery © <a href="http://mapbox.com">Mapbox</a>',
                maxZoom: 18,
                id: 'mapbox.streets',
                accessToken: 'pk.eyJ1IjoibHJvdXNlIiwiYSI6ImNpaHBnYmkxaDA0NGJ0c20yMG5sMmZlenIifQ.NVpXXlzfBCtK00m36zp68Q'
            }).addTo(map);

            map.setView([36.1666, -86.7833], 12);

            L.marker([36.1666, -86.7833]).addTo(map);

            var redcircle = L.circle([36.1666, -86.783], 500,{
                color: 'red',
                fillColor: '#f03',
                fillOpacity: 0.5
            }).addTo(map);

            redcircle.bindPopup("This will have information.")

            var popup = L.popup();
            function onMapClick(e) {
                popup
                    .setLatLng(e.latlng)
                    .setContent("You clicked the map at " + e.latlng.toString())
                    .openOn(map);
            }
            map.on('click', onMapClick);

            L.TopoJSON = L.GeoJSON.extend({  
                addData: function(jsonData) {    
                    if (jsonData.type === "Topology") {
                        for (key in jsonData.objects) {
                            geojson = topojson.feature(jsonData, jsonData.objects[key]);
                            L.GeoJSON.prototype.addData.call(this, geojson);
                        }
                    }    
                    else {
                        L.GeoJSON.prototype.addData.call(this, jsonData);
                    }
                }  
            });
            // Copyright (c) 2013 Ryan Clark

            //Checking to See if API Returns ZipCode Model Information
            var self = this;

            self.getZipCodes = function () {
                $http.get("api/ZipCode")
                    .then(function (response) {
                        console.log(response);
                    })
            }

            self.getZipCodes();

            

            //Topo Layer Logic
            var topoLayer = new L.TopoJSON();

            $.getJSON('api/JsonFile')
                .done(addTopoData);

            function addTopoData(topoData, style){
                topoLayer.addData(topoData, { style: style });
                topoLayer.addTo(map);
                topoLayer.eachLayer(handleLayer);
            }

            //Styling of Topo Layer
            //topoLayer.eachLayer(handleLayer);

            function handleLayer(layer) {
                //var randomValue = Math.random(),
                //fillColor = colorScale(randomValue).hex();

                layer.setStyle({
                    //fillColor: fillColor,
                    //fillOpacity: 1,
                    color: 'navy',
                    weight: 1,
                    opacity: 1,
                    dashArray: '3'
                });

                /*layer.on({
                    mouseover: enterLayer,
                    mouseout: leaveLayer
                });*/
            }

        });


    }
]);