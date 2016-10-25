(function () {
    'use strict';

    var app = angular.module('blocks.router');
    app.factory('authInterceptor', authInterceptor);

    authInterceptor.$inject = ['$rootScope','$q', '$window', '$location', 'logger'];

    function authInterceptor($rootScope, $q, $window, $location, logger) {
        return {
            request: function (config) {
                config.headers = config.headers || {};
                if ($window.localStorage.getItem('builder-token')) {
                    var token = $window.localStorage.getItem('builder-token');
                    //config.headers.Authorization = 'Bearer ' + $window.sessionStorage.token;
                    config.headers['Authorization'] = 'Bearer ' + token;
                }
                return config;
            },
            responseError: function (rejection) {
                if (rejection.status === 403 || rejection.status === 401) {
                    // handle the case where the user is not authenticated
                    // redirect to login
                    $window.localStorage.removeItem('builder-token');
                    var oldLocation = $location.path();
                    $location.path('/login').search({returnUrl: oldLocation});
                }
                return $q.reject(rejection);
            }
        };
    }

    app.config(['$httpProvider',interceptConfig]);

    function interceptConfig($httpProvider){
      $httpProvider.interceptors.push('authInterceptor');
    }
/*
    app.config(function ($httpProvider) {
        $httpProvider.interceptors.push('authInterceptor');
    });*/
})();
