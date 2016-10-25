(function() {
    'use strict';

    angular
        .module('app.hello')
        .run(['routehelper',appRun]);

    // appRun.$inject = ['routehelper']

    /* @ngInject */
    function appRun(routehelper) {
        routehelper.configureRoutes(getRoutes());
    }

    function getRoutes() {
        return [
            {
                url: '/hello',
                config: {
                    templateUrl: 'app/hello/hello.html',
                    controller: 'Hello',
                    controllerAs: 'vm',
                    title: 'hello',
                    settings: {
                        nav: 2,
                        content: 'Hello'
                    }
                }
            }
        ];
    }
})();
