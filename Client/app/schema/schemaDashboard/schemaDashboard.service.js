(function() {
    'use strict';

    angular
        .module('app.schemaDashboard')
        .factory('schemaDashboardService', ['$http', '$location', '$q',
          'exception', 'logger', 'config', schemaDashboardService]);

    /* @ngInject */
    function schemaDashboardService($http, $location, $q, exception,
      logger, config) {
        var isPrimed = false;
        var primePromise;

        var service = {
            // getSchemaDetails: getSchemaDetails,
            // saveSchemaDetails: saveSchemaDetails
        };

        return service;
    }
})();
