(function() {
    'use strict';

    angular
        .module('app.screenSplash')
        .factory('screenSplashService', ['$http', '$location', '$q', 'exception',
          'logger', 'config', screenSplashService]);

    /* @ngInject */
    function screenSplashService($http, $location, $q, exception, logger, config) {
        var isPrimed = false;
        var primePromise;

        var service = {
            getScreens: getScreens,
            ready: ready
        };

        return service;

        // Replace calls to stubs with $http.get()
        function getScreensStub() {
            var screens = [
              {
                name: 'List',
                description: 'Some short description about what the screen does.  May not be too helpful though...',
                icon: '/content/images/listIcon.png',
                path: 'list'
              },
              {
                name: 'Edit',
                description: 'Some short description about what the screen does.  May not be too helpful though...',
                icon: '/content/images/listIcon.png',
                path: ''
              },
              {
                name: 'Create',
                description: 'Some short description about what the screen does.  May not be too helpful though...',
                icon: '/content/images/listIcon.png',
                path: ''
              }
            ]
            return $q(function(resolve, reject) {
              var millisecondsToWait = 500;
              setTimeout(function() {
                  // Whatever you want to do after the wait
                  resolve(screens);
              }, millisecondsToWait);
            });
        }

        function getScreens() {
            var count = 0;
            return getScreensStub()
                .then(getScreensComplete)
                .catch(exception.catcher('XHR Failed for screens'));

            function getScreensComplete(data) {
                return $q.when(data);
            }
        }

        function prime() {
            // This function can only be called once.
            if (primePromise) {
                return primePromise;
            }

            primePromise = $q.when(true).then(success);
            return primePromise;

            function success() {
                isPrimed = true;
                logger.info('Primed data');
            }
        }

        function ready() {

        }

    }
})();
