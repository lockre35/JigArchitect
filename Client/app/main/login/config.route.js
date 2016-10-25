(function() {
    'use strict';

    angular
        .module('app.login')
        .run(['routehelper',appRun]);

    // appRun.$inject = ['routehelper'];
    /* @ngInject */
    function appRun(routehelper) {
        routehelper.configureRoutes(getRoutes());
    }

    function getRoutes() {
        return [
            {
                url: '/login',
                config: {
                    templateUrl: 'app/main/login/login.html',
                    controller: 'Login',
                    controllerAs: 'vm',
                    title: '',
                    settings: {
                        nav: 4,
                        content: 'Login'
                    }
                }
            }
        ];
    }
})();
