(function(){

    'use strict';

    angular
        .module("GentrificationCalcApp", [])
        .controller('MapCtrl', MapCtrl);

    function MapCtrl (){
        var mymap = L.map('mapid').setView([51.505, -0.09], 13);

    }


})();