    'use strict';
    (function() {

    angular
        .module('app.login')
        .controller('Login', ['$q','loginService','logger', '$window',
          '$location', '$routeParams', '$scope', Login]);

    Login.$inject = ['$q', 'dashboardService', 'logger', '$window',
      '$location', '$routeParams', '$scope'];

    function Login($q, loginService, logger, $window, $location, $routeParams, $scope) {
        var parent = $scope.$parent.vm;
        /*jshint validthis: true */
        var vm = this;
        vm.shell = parent;
        vm.name = '';
        vm.password = '';
        vm.errorMessage = '';
        vm.infoMessage = '';
        vm.returnUrl = $routeParams.returnUrl;
        vm.title = 'Login';
        vm.loading = false;
        vm.loggingIn = false;
        vm.authenticate = authenticate;
        activate();

        function activate() {
          if($routeParams.returnUrl){
            vm.infoMessage = 'It appears that you are no longer authenticated.  '
              + 'Please log into continue.';
          }
        }

        function authenticate() {
          vm.loggingIn = true;
          return loginService.authenticate(vm.name, vm.password)
            .then(function(data) {
              if(data.authenticated){
                vm.shell.loggedIn = true;
                $window.localStorage.setItem('builder-token', data.token);
                // var encodedProfile = data.token.split('.')[1];
                // var profile = JSON.parse(atob(encodedProfile))._doc;
                // if(!profile)
                //   profile = JSON.parse(atob(encodedProfile));

                vm.errorMessage = '';
                logger.success('Welcome ' + data.name + '!');
                if(vm.returnUrl){
                  $location.path(vm.returnUrl).search({returnUrl: null});;
                } else {
                  $location.path('/');
                }
              } else {
                $window.localStorage.removeItem('builder-token');

                // Handle login errors here
                vm.infoMessage = '';
                vm.errorMessage = 'Invalid user or password';
                vm.loggingIn = false;
              }
          });
        }
    }
})();
