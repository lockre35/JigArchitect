(function() {
    'use strict';

    angular
        .module('app.dashboard')
        .run(['routehelper',appRun]);

    // appRun.$inject = ['routehelper'];
    /* @ngInject */
    function appRun(routehelper) {
        routehelper.configureRoutes(getRoutes());
    }

    function getRoutes() {
        return [
            {
                url: '/',
                config: {
                    templateUrl: 'app/main/dashboard/dashboard.html',
                    controller: 'Dashboard',
                    controllerAs: 'vm',
                    title: 'dashboard',
                    settings: {
                        nav: 1,
                        content: 'Dashboard'
                    }
                }
            }
        ];
    }
})();
