(function() {
    'use strict';

    angular
        .module('app.applicationDashboard')
        .controller('ApplicationDashboard', ['$q','applicationDashboardService','logger','$routeParams',ApplicationDashboard]);

    //ApplicationDashboard.$inject = ['$q', 'dataservice', 'logger', '$routeParams'];

    function ApplicationDashboard($q, applicationDashboardService, logger, $routeParams) {

        /*jshint validthis: true */
        var vm = this;

        vm.title = 'Application Dashboard';
        vm.applicationId = $routeParams.applicationName;
        vm.applicationDetails = {};
        vm.loading = true;
        vm.schemas = [];
        activate();

        function activate() {
            applicationDashboardService.reset();
            var promises = [getApplicationDetails(), getSchemas()];
            //var promises = [getApplicationScreens()];
//            Using a resolver on all routes or dataservice.ready in every controller
//            return dataservice.ready(promises).then(function(){
            return $q.all(promises).then(function() {
                vm.loading = false;
                logger.info('Activated Application Dashboard View');
            });
        }

        function getApplicationDetails() {
            return applicationDashboardService.getApplicationDetails(vm.applicationId).then(function(data) {
                vm.applicationDetails = data;
                return vm.applicationDetails;
            });
        }

        function getSchemas() {
          return applicationDashboardService.getSchemas(vm.applicationId).then(function(data) {
            vm.schemas = data;
            return vm.schemas;
          });
        }
    }
})();
