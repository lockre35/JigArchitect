(function() {
    'use strict';

    angular
        .module('app.layout')
        .controller('Shell', Shell);

    Shell.$inject = ['$timeout', 'config', 'logger', '$mdSidenav', '$window', '$location'];

    function Shell($timeout, config, logger, $mdSidenav, $window, $location) {
        /*jshint validthis: true */
        var vm = this;

        vm.title = config.appTitle;
        vm.busyMessage = 'Please wait ...';
        vm.isBusy = true;
        vm.showSplash = true;
        vm.toggleSidenav = toggleSidenav;
        vm.loggedIn = false;
        vm.logout = logout;

        activate();

        function activate() {
            if ($window.localStorage.getItem('builder-token')){
              vm.loggedIn = true;
            }
            logger.success(config.appTitle + ' loaded!', null);
//            Using a resolver on all routes or dataservice.ready in every controller
//            dataservice.ready().then(function(){
//                hideSplash();
//            });
            hideSplash();
        }

        function logout(menuId){
            vm.loggedIn = false;
            if ($window.localStorage.getItem('builder-token')){
              $window.localStorage.removeItem('builder-token');
              $mdSidenav(menuId).toggle();
              $location.path('/login');
            }
        }

        function hideSplash() {
            //Force a 1 second delay so we can see the splash.
            $timeout(function() {
                vm.showSplash = false;
            }, 1000);
        }

        function toggleSidenav(menuId) {
            if ($window.localStorage.getItem('builder-token')){
              vm.loggedIn = true;
            } else {
              vm.loggedIn = false;
            }
            $mdSidenav(menuId).toggle();
        }
    }
})();
