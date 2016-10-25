(function() {
    'use strict';

    angular
        .module('app.screenSplash')
        .run(['routehelper',appRun]);

    /* @ngInject */
    function appRun(routehelper) {
        routehelper.configureRoutes(getRoutes());
    }


    function getRoutes() {
        return [
            {
                url: '/application/:id/createscreen',
                config: {
                    templateUrl: 'app/screen/screenSplash/screenSplash.html',
                    controller: 'ScreenSplash',
                    controllerAs: 'vm',
                    settings: {
                        nav: 1,
                        content: 'ScreenSplash'
                    }
                }
            }
        ];
    }
})();
