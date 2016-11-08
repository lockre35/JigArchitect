(function() {
    'use strict';

    angular
        .module('app.schemaDashboard')
        .run(['routehelper',appRun]);

    /* @ngInject */
    function appRun(routehelper) {
        routehelper.configureRoutes(getRoutes());
    }

    function getRoutes() {
        return [
            {
                url: '/application/:applicationName/schemas/:schemaId',
                config: {
                    templateUrl: 'app/schema/schemaDashboard/schemaDashboard.html',
                    controller: 'SchemaDashboard',
                    controllerAs: 'vm',
                    title: '',
                    settings: {
                        nav: 3,
                        content: 'Schema Dashboard'
                    }
                }
            }
        ];
    }
})();
