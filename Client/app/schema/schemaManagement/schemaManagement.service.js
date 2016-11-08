(function() {
    'use strict';

    angular
        .module('app.schemaManagement')
        .factory('schemaManagementService', ['$http', '$location', '$q',
          'exception', 'logger', 'config', schemaManagementService]);

    /* @ngInject */
    function schemaManagementService($http, $location, $q, exception,
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
