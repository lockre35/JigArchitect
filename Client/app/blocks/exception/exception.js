(function() {
    'use strict';

    angular
        .module('blocks.exception')
        .factory('exception', ['logger', exception]);

    /* @ngInject */
    function exception(logger) {
        var service = {
            catcher: catcher
        };
        return service;

        function catcher(message) {
            return function(reason) {
                logger.error(message, reason);
            };
        }
    }
})();
