(function() {
    'use strict';

    angular
        .module('app.schemaCreation')
        .run(['routehelper',appRun]);

    /* @ngInject */
    function appRun(routehelper) {
        routehelper.configureRoutes(getRoutes());
    }

    function getRoutes() {
        return [
            {
                url: '/application/:applicationId/schemas/create',
                config: {
                    templateUrl: 'app/schema/schemaCreation/schemaCreation.html',
                    controller: 'SchemaCreation',
                    controllerAs: 'vm',
                    title: '',
                    settings: {
                        nav: 3,
                        content: 'Schema Creation'
                    }
                }
            }
        ];
    }
})();
