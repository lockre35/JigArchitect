(function() {
    'use strict';

    angular
        .module('app.login')
        .factory('loginService', ['$http', '$location', '$q', 'exception',
          'logger', 'config', loginService]);

    /* @ngInject */
    function loginService($http, $location, $q, exception, logger, config) {
        var isPrimed = false;
        var primePromise;

        var service = {
            ready: ready,
            authenticate: authenticate
        };

        return service;

        function authenticate(name, password) {
            var model = {
              Username : name,
              Password : password
            };

            return $http.post(config.apiUrl + '/api/authentication', model,
              {headers: {'Content-Type': 'application/json'}})
              .then(getResult)
              .catch(function(message) {
                exception.catcher('Request failed');
                logger.error('Request failed');
              });

            function getResult(data, status, headers, config) {
              return data.data;
            }
        }

        function ready() {

        }

    }
})();
