(function() {
    'use strict';

    angular
        .module('app.schemaCreation')
        .factory('schemaCreationService', ['$http', '$location', '$q',
          'exception', 'logger', 'config', schemaCreationService]);

    /* @ngInject */
    function schemaCreationService($http, $location, $q, exception,
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
