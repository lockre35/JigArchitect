(function() {
    'use strict';

    angular
        .module('app.screenSplash')
        .controller('ScreenSplash', ['$q','screenSplashService','logger', '$routeParams', ScreenSplash]);

    ScreenSplash.$inject = ['$q', 'screenSplashService', 'logger', '$routeParams'];

    function ScreenSplash($q, screenSplashService, logger, $routeParams) {

        /*jshint validthis: true */
        var vm = this;

        vm.screens = [];
        vm.title = 'Dashboard';
        vm.loading = true;
        vm.applicationId = $routeParams.id;

        activate();

        function activate() {
            var promises = [getScreens()];
//            Using a resolver on all routes or dataservice.ready in every controller
//            return dataservice.ready(promises).then(function(){
            return $q.all(promises).then(function() {
                vm.loading = false;
            });
        }

        function getScreens() {
            return screenSplashService.getScreens().then(function(data) {
                vm.screens = data;
                return vm.screens;
            });
        }
    }
})();
