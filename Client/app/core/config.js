(function() {
    'use strict';

    var core = angular.module('app.core');

    core.config(['toastr',toastrConfig]);

    /* @ngInject */
    function toastrConfig(toastr) {
        toastr.options.timeOut = 4000;
        toastr.options.positionClass = 'toast-bottom-right';
    }

    var config = {
        appErrorPrefix: '[NG-Modular Error] ', //Configure the exceptionHandler decorator
        appTitle: 'Jig Application Builder',
        version: '0.0.1',
        apiUrl: 'http://localhost:61577'
        // apiUrl: 'http://192.168.2.156:5000'
        //apiUrl: 'http://192.168.2.201:8081'
        //apiUrl: 'http://192.168.2.28:8081'//desktop
        //apiUrl: 'http://192.168.0.38:8081'//i7laptop
    };

    core.value('config', config);

    core.config(['$logProvider','$routeProvider', 'routehelperConfigProvider', 'exceptionHandlerProvider', '$locationProvider', configure]);

    /* @ngInject */
    function configure ($logProvider, $routeProvider, routehelperConfigProvider, exceptionHandlerProvider, $locationProvider) {
        // turn debugging off/on (no info or warn)
        if ($logProvider.debugEnabled) {
            $logProvider.debugEnabled(true);
        }

        // Configure the common route provider
        routehelperConfigProvider.config.$routeProvider = $routeProvider;
        routehelperConfigProvider.config.docTitle = 'Jig Application Builder';
        var resolveAlways = { /* @ngInject */
            //ready: function(dataservice) {
            //    return dataservice.ready();
            //}
             ready: ['dataservice', function (dataservice) {
                return dataservice.ready();
             }]
        };
        routehelperConfigProvider.config.resolveAlways = resolveAlways;

        // Configure the common exception handler
        exceptionHandlerProvider.configure(config.appErrorPrefix);

        $locationProvider.html5Mode(true);
    }
})();
