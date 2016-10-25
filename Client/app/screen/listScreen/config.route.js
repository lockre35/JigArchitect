(function() {
    'use strict';

    angular
        .module('app.listScreen')
        .run(['routehelper',appRun]);

    // appRun.$inject = ['routehelper'];

    /* @ngInject */
    function appRun(routehelper) {
        routehelper.configureRoutes(getRoutes());
    }

    function getRoutes() {
        return [
            {
                url: '/application/:applicationId/createscreen/list',
                config: {
                    templateUrl: 'app/screen/listScreen/listScreen.html',
                    controller: 'ListScreen',
                    controllerAs: 'vm',
                    title: '',
                    settings: {
                        nav: 3,
                        content: 'List Screen'
                    }
                }
            }
        ];
    }
})();
