(function() {
    'use strict';

    angular
        .module('app.schemaManagement')
        .controller('SchemaManagement', ['$q','schemaManagementService','logger',
          '$routeParams', SchemaManagement]);

    function SchemaManagement($q, SchemaManagementService, logger, $routeParams) {

      /*jshint validthis: true */
      var vm = this;
    }
})();
