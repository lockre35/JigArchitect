(function() {
    'use strict';

    angular
        .module('app.applicationManagement')
        .factory('applicationManagementService', ['$http', '$location', '$q', 'exception',
          'config', 'logger', applicationManagementService]);

    /* @ngInject */
    function applicationManagementService($http, $location, $q, exception, config,
      logger) {

        var service = {
            saveApplicationDetails: saveApplicationDetails,
            getApplicationDetails: getApplicationDetails
        };

        return service;

        function getApplicationDetails(application) {
            return $http
                .get(config.apiUrl + '/api/applications/' + application)
                .then(getApplicationDetailsComplete)
                .catch(function(message) {
                    exception.catcher('XHR Failed for applications')(message);
                });

            function getApplicationDetailsComplete(data, status, headers, config) {
                return data.data.Response;
            }
        }

        function saveApplicationDetails(application, detailModel) {
          return $http.post(config.apiUrl + '/api/applications/' + application, detailModel,
            {headers: {'Content-Type': 'application/json'}})
            .then(getResult)
            .catch(function(message) {
              exception.catcher('Request failed');
              logger.error('Request failed');
            });

          function getResult(data, status, headers, config) {
            return data.data.Response;
          }
        }
    }
})();
