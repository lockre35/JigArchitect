(function() {
    'use strict';

    angular
        .module('app.schemaManagement')
        .run(['routehelper',appRun]);

    // appRun.$inject = ['routehelper'];

    /* @ngInject */
    function appRun(routehelper) {
        routehelper.configureRoutes(getRoutes());
    }

    function getRoutes() {
        return [
            {
                url: '/application/:applicationName/schemas/:schemaId/manage',
                config: {
                    templateUrl: 'app/schema/schemaManagment/schemaManagment.html',
                    controller: 'SchemaManagement',
                    controllerAs: 'vm',
                    title: '',
                    settings: {
                        nav: 3,
                        content: 'Schema Management'
                    }
                }
            }
        ];
    }
})();
