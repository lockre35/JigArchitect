(function() {
    'use strict';

    angular.module('app', [
        /*
         * Order is not important. Angular makes a
         * pass to register all of the modules listed
         * and then when app.dashboard tries to use app.data,
         * its components are available.
         */

        /*
         * Everybody has access to these.
         * We could place these under every feature area,
         * but this is easier to maintain.
         */
        'app.core',
        'app.widgets',

        /*
         * Feature areas
         */
        'app.login',
        'app.hello',
        'app.dashboard',
        'app.layout',
        'app.applicationDashboard',
        'app.applicationManagement',
        'app.screenSplash',
        'app.listScreen',
        'app.schemaManagement',
        'app.schemaCreation',
        'app.schemaDashboard'
    ]);

})();
