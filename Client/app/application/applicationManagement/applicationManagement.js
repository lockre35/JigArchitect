(function() {
    'use strict';

    angular
        .module('app.applicationManagement')
        .controller('ApplicationManagement', ['$q', '$location',
          'applicationManagementService','logger','$routeParams', ApplicationManagement]);

    //ApplicationManagement.$inject = ['$q', 'dataservice', 'logger', '$routeParams'];

    function ApplicationManagement($q, $location, applicationManagementService,
      logger, $routeParams) {

        /*jshint validthis: true */
        var vm = this;

        vm.screens = [];
        vm.title = 'Application Management';
        vm.applicationId = $routeParams.applicationName;
        vm.applicationName = '';
        vm.applicationDetails = {};
        vm.loading = true;
        vm.saving = false;
        vm.uploadFile = uploadFile;
        vm.imageUploading = false;
        vm.saveApplicationDetails = saveApplicationDetails;
        activate();

        function activate() {
            var promises = [getApplicationDetails()];
//            Using a resolver on all routes or dataservice.ready in every controller
//            return dataservice.ready(promises).then(function(){
            return $q.all(promises).then(function() {
                vm.loading = false;
                logger.info('Activated Application Dashboard View');
            });
        }

        function getApplicationDetails() {
            return applicationManagementService.getApplicationDetails(vm.applicationId).then(function(data) {
                vm.applicationDetails = data;
                vm.applicationName = data.Name;
                return vm.applicationDetails;
            });
        }

        function saveApplicationDetails() {
          vm.saving = true;
          return applicationManagementService.saveApplicationDetails(vm.applicationId, vm.applicationDetails)
            .then(function(data) {
              vm.saving = false;
              logger.success('Application Details Saved!');
              $location.path('/application/' + vm.applicationId).search({returnUrl: null});
          });
        }

        function uploadFile(event){
          vm.imageUploading = true;
          var files = event.target.files;
          if(files[0]){
            var photofile = files[0];
            var reader = new FileReader();
            reader.onload = function(e) {
              // handle onload
              vm.applicationDetails.Icon = reader.result;
              vm.imageUploading = false;
             };
            reader.readAsDataURL(photofile);
          }
        };
    }
})();
