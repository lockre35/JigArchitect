(function() {
    'use strict';

    angular
        .module('app.applicationDashboard')
        .run(['routehelper',appRun]);

    // appRun.$inject = ['routehelper'];

    /* @ngInject */
    function appRun(routehelper) {
        routehelper.configureRoutes(getRoutes());
    }

    function getRoutes() {
        return [
            {
                url: '/application/:applicationName',
                config: {
                    templateUrl: 'app/application/applicationDashboard/applicationDashboard.html',
                    controller: 'ApplicationDashboard',
                    controllerAs: 'vm',
                    title: '',
                    settings: {
                        nav: 3,
                        content: 'Application Dashboard'
                    }
                }
            }
        ];
    }
})();
