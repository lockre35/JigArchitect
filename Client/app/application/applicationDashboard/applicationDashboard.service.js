(function() {
    'use strict';

    angular
        .module('app.dashboard')
        .factory('applicationDashboardService', ['$http', '$location', '$q', 'exception', 'logger', 'config', applicationDashboardService]);

    /* @ngInject */
    function applicationDashboardService($http, $location, $q, exception, logger, config) {
        var isPrimed = false;
        var primePromise;

        var service = {
            getApplicationDetails: getApplicationDetails,
            getRoles: getRoles,
            getScreens: getScreens,
            reset: reset
        };

        return service;



        function getApplicationDetails(applicationId) {
            return prime(applicationId)
                .then(getApplicationDetailsComplete)
                .catch(function(message) {
                    exception.catcher('XHR Failed for applications')(message);
                });

            function getApplicationDetailsComplete(data, status, headers, config) {
                return data;
            }
        }

        function getRoles(applicationId) {
            return prime(applicationId)
                .then(getRolesComplete)
                .catch(function(message) {
                    exception.catcher('XHR Failed for applications')(message);
                });

            function getRolesComplete(data, status, headers, config) {
                data.Roles.forEach(function(role){
                  var screens = 0;
                  var currentRole = role;
                  screens = data.Screens.filter(function(screen){
                    return screen.Roles.filter(function(innerRole){
                      if(innerRole === currentRole.Name)
                        return true;
                      return false;
                    }).length > 0;
                  }).length;
                  role.Screens = screens;
                });
                return data.Roles;
            }
        }

        function getScreens(applicationId) {
            return prime(applicationId)
                .then(getScreensComplete)
                .catch(function(message) {
                    exception.catcher('XHR Failed for applications')(message);
                });

            function getScreensComplete(data, status, headers, config) {
                data.Screens.forEach(function(screen){
                  screen.Role = screen.Roles[0];
                });
                return data.Screens;
            }
        }

        function prime(application) {
            // This function can only be called once.
            if (primePromise) {
                return primePromise;
            }
            logger.info('Priming data');
            primePromise = $http
              .get(config.apiUrl + '/api/applications/' + application)
              .then(success)
              .catch(function(message) {
                  exception.catcher('XHR Failed for applications')(message);
              });

            return primePromise;

            function success(data, status, headers, config) {
                isPrimed = true;
                return data.data.Response;
            }
        }

        function reset() {
          isPrimed = false;
          primePromise = null;
        }

    }
})();
