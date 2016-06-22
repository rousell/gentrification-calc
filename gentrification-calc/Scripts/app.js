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
            '$scope', 'leaflet', '$http', '$q',
    function ($scope, leaflet, $http, $q) {

        $scope.ZipCodes = [];
        $scope.mathArray = [];
        $scope.getZipCodes = function () {
            var def = $q.defer();
            $http.get("api/ZipCode")
                .then(function successCallBack(response) {
                    for (var i = 0; i < response.data.length; i++) {
                        var currentZip = response.data[i].ZipCodeDigit;

                        //$scope.getMedianPrice(currentZip);

                        $scope.getMedianPrice(currentZip).then(function (price) {
                            //$scope.mathArray.medianprice = p;
                            $scope.mathArray.push({
                                zip: currentZip,
                                medianprice: price
                            })
                        });
                    }
                    console.log("Testing MathArray Output, ", $scope.mathArray);
                    def.resolve($scope.mathArray);
                }, function errorCallBack(response) {
                    def.reject(response);
                    //console.log("GetMedianPrice Rejecting Data: ", response);
                });
            return def.promise;
        }
        $scope.getZipCodes();

        $scope.getPopYears = function () {
            $http.get("api/PopulationYear")
                .then(function (response) {
                    //console.log('All PopYears Data', response);
                })
        }
        $scope.getPopYears();

        $scope.getPopYearsByZip = function (zip) {
            $http.get("api/PopulationYear/" + zip)
                .then(function (response) {
                    //console.log('PopYearsByZip ', response);
                })
        }

        $scope.getBuildingPermits = function(){
            $http.get("https://data.nashville.gov/resource/p5r5-bnga.json")
                .then(function (response) {
                    //console.log(response);
                })
        }
        $scope.getBuildingPermits();

        $scope.getMedianPrice = function (zip) {
            var def = $q.defer();
            $http.get("https://www.quandl.com/api/v3/datasets/ZILL/Z" + zip + "_MLP.json?api_key=ib6K5S8PzwzPiZFWir8a")
                .then(function successCallBack(response) {
                    //var response.data.dataset.data[0]);
                    var startDatePrice;
                    var endDatePrice;
                    var priceDiff;
                    for (i = 0; i < response.data.dataset.data.length; i++) {
                        //console.log(response.data.dataset.data[i][0]);
                        if (response.data.dataset.data[i][0] === "2011-12-31") {
                            startDatePrice = response.data.dataset.data[i][1];
                        }
                        if (response.data.dataset.data[i][0] === "2014-12-31") {
                            endDatePrice = response.data.dataset.data[i][1];
                        }
                    }
                    priceDiff = endDatePrice - startDatePrice;

                    def.resolve(priceDiff);
                }, function errorCallBack(response) {
                    def.reject(response);
                    //console.log("GetMedianPrice Rejecting Data: ", response);
                });
            return def.promise;
        }

        //Promise to Load in Leaflet Map
        leaflet.map.then(function (map) {
            L.tileLayer('http://api.tiles.mapbox.com/v4/{id}/{z}/{x}/{y}.png?access_token={accessToken}', {
                attribution: 'Map data &copy; <a href="http://openstreetmap.org">OpenStreetMap</a> contributors, <a href="http://creativecommons.org/licenses/by-sa/2.0/">CC-BY-SA</a>, Imagery © <a href="http://mapbox.com">Mapbox</a>',
                maxZoom: 18,
                id: 'mapbox.streets',
                accessToken: 'pk.eyJ1IjoibHJvdXNlIiwiYSI6ImNpaHBnYmkxaDA0NGJ0c20yMG5sMmZlenIifQ.NVpXXlzfBCtK00m36zp68Q'
            }).addTo(map);

            //Variables
            var self = this;

            map.setView([36.1666, -86.7833], 12);

            //Event Handler for popup on map click
            var popup = L.popup();
            function onMapClick(e) {
                popup
                    .setLatLng(e.latlng)
                    .setContent("You clicked the map at " + e.latlng.toString())
                    .openOn(map);
            }
            map.on('click', onMapClick);

            //GeoJSON to TopoJSON replacement in browser
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
            /*self.getZipCodes = function () {
                $http.get("api/ZipCode")
                    .then(function (response) {
                        console.log(response);
                    })
            }*/

            //Core Topo Layer Logic
            var topoLayer = new L.TopoJSON();

            $.getJSON('api/JsonFile')
                .done(addTopoData);

            function addTopoData(topoData, style){
                topoLayer.addData(topoData, { style: style });
                topoLayer.addTo(map);
                topoLayer.eachLayer(handleLayer);
            }

            $scope.color = function (num) {
                return num > 200000 ? '#800026' :
                       num > 150000 ? '#BD0026' :
                       num > 100000 ? '#E31A1C' :
                       num > 50000 ? '#FC4E2A' :
                       num > 25000 ? '#FD8D3C' :
                       num > 10000 ? '#FEB24C' :
                       num > 5000 ? '#FED976' :
                                 '#FFEDA0';
            }

            //Styling of Topo Layer with additional Layer Logic
            function handleLayer(layer) {
                //var randomValue = Math.random(),
                //fillColor = colorScale(randomValue).hex();

                //console.log("This is the information on Layers: ", layer);

                var median;

                for (var i = 0; i < $scope.mathArray.length; i++) {
                    if ($scope.mathArray[i] == layer.feature.properties.ZCTA5CE10) {
                        $scope.mathArray[i].medianprice.then(function (p) {
                            median = p;
                            console.log(median);
                        });
                    }
                }

                

                layer.setStyle({
                    fillColor: '#FFEDA0',
                    //fillOpacity: 1,
                    color: 'navy',
                    weight: 1,
                    opacity: 1,
                    dashArray: '3'
                });

                layer.on({
                    mouseover: enterLayer,
                    mouseout: leaveLayer
                });
            }

            var testName = "testName";

            //Event Handlers for Mouseover and Mouseout on Layers
            function enterLayer() {
                //$testName.text(testName).show();
                //console.log("This is ", this.feature.properties.ZCTA5CE10);

                $scope.getPopYearsByZip(this.feature.properties.ZCTA5CE10);
                $scope.getMedianPrice(this.feature.properties.ZCTA5CE10);

                info.update(this.feature.properties);

                this.bringToFront();
                this.setStyle({
                    weight: 2,
                    opacity: 1
                });
            }
            function leaveLayer() {
                //$testName.hide();

                info.update();

                this.bringToBack();
                this.setStyle({
                    weight: 1,
                    opacity: .5
                });
            }

            //Custom Info Control
            var info = L.control();

            info.onAdd = function (map) {
                this._div = L.DomUtil.create('div', 'info'); // create a div with a class "info"
                this.update();
                return this._div;
            };

            // method that we will use to update the control based on feature properties passed
            info.update = function (props) {
                this._div.innerHTML = '<h4>Gentrification Calculation</h4>' + (props ?
                    '<b>' + props.ZCTA5CE10 + '</b><br />Click for more infomation '
                    : 'Hover over a zipcode')
            };

            info.addTo(map);

            //Data Calculation Attempt



        });
    }
]);