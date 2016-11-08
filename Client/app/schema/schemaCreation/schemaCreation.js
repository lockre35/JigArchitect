(function() {
    'use strict';

    angular
        .module('app.schemaCreation')
        .controller('SchemaCreation', ['$q','schemaCreationService','logger',
          '$routeParams', 'applicationManagementService', SchemaCreation]);

    function SchemaCreation($q, schemaCreationService, logger, $routeParams,
      applicationManagementService) {

      /*jshint validthis: true */
      var vm = this;
      vm.loading = true;
      vm.applicationId = $routeParams.applicationId;
      vm.schemaId = $routeParams.schemaId;
      activate();

      function activate() {
          var promises = [getApplicationDetails()];
          return $q.all(promises).then(function() {
              vm.loading = false;
          });
      }

      function getApplicationDetails() {
          return applicationManagementService
            .getApplicationDetails(vm.applicationId).then(function(data) {
              vm.applicationName = data.Name;
              return vm.applicationName;
          });
      }
    }
})();
