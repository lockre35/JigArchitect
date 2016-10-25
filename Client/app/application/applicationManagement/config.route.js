(function() {
    'use strict';

    angular
        .module('app.applicationManagement')
        .run(['routehelper',appRun]);

    // appRun.$inject = ['routehelper'];

    /* @ngInject */
    function appRun(routehelper) {
        routehelper.configureRoutes(getRoutes());
    }

    function getRoutes() {
        return [
            {
                url: '/application/:applicationName/manage',
                config: {
                    templateUrl: 'app/application/applicationManagement/applicationManagement.html',
                    controller: 'ApplicationManagement',
                    controllerAs: 'vm',
                    title: '',
                    settings: {
                        nav: 3,
                        content: 'Application Management'
                    }
                }
            }
        ];
    }
})();
