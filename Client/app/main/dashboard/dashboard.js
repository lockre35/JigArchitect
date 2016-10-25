(function() {
    'use strict';

    angular
        .module('app.dashboard')
        .controller('Dashboard', ['$q','dashboardService','logger',Dashboard]);

    Dashboard.$inject = ['$q', 'dashboardService', 'logger'];

    function Dashboard($q, dashboardService, logger) {

        /*jshint validthis: true */
        var vm = this;

        vm.applicationCount = 0;
        vm.applications = [];
        vm.title = 'Dashboard';
        vm.loading = true;

        activate();

        function activate() {
            var promises = [getApplications(), getApplicationCount];
//            Using a resolver on all routes or dataservice.ready in every controller
//            return dataservice.ready(promises).then(function(){
            return $q.all(promises).then(function() {
                vm.loading = false;
                logger.info('Activated Dashboard View');
            });
        }

        function getApplications() {
            return dashboardService.getApplications().then(function(data) {
                vm.applications = data;
                return vm.applications;
            });
        }

        function getApplicationCount() {
            return dashboardService.getApplicationCount().then(function(data) {
                vm.applicationCount = data;
                return vm.applicationCount;
            });
        }
    }
})();
