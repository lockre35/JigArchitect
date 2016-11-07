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
            getSchemas: getSchemas,
            getServices: getServices,
            reset: reset
        };

        return service;



        function getApplicationDetails(applicationId) {
            return $http
                .get(config.apiUrl + '/api/applications/' + applicationId)
                .then(getApplicationDetailsComplete)
                .catch(function(message) {
                    exception.catcher('XHR Failed for applications')(message);
                });

            function getApplicationDetailsComplete(data, status, headers, config) {
                if (!data.data.Response.Description) {
                  data.data.Response.Description = 'No Description';
                }
                return data.data.Response;
            }
        }

        function getSchemas(applicationId) {
            return $http
                .get(config.apiUrl + '/api/applications/' + applicationId + '/schemas')
                .then(getSchemasComplete)
                .catch(function(message) {
                    exception.catcher('XHR Failed for application schemas')(message);
                });

            function getSchemasComplete(data, status, headers, config) {
                return data.data.Response;
            }
        }

        function getServices(applicationId) {
            return $http
                .get(config.apiUrl + '/api/applications/' + applicationId)
                .then(getApplicationDetailsComplete)
                .catch(function(message) {
                    exception.catcher('XHR Failed for applications')(message);
                });

            function getApplicationDetailsComplete(data, status, headers, config) {
                return data.data.Response;
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
