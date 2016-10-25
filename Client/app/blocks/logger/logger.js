(function() {
    'use strict';

    angular
        .module('blocks.logger')
        .factory('logger', logger);

    logger.$inject = ['$log', '$injector'];

    function logger($log, $injector) {

        var service = {
            mdToastr : null,
            showToasts: true,

            error   : error,
            info    : info,
            success : success,
            warning : warning,

            // straight to console; bypass toastr
            log     : $log.log,
            getToaster : getToaster,
            buildToast : buildToast
        };

        return service;
        /////////////////////

        function error(message, data, title) {
            var toast = service.buildToast('Error!', message);
            service.getToaster().show(toast);
            $log.error('Error: ' + message, data);
        }

        function info(message, data, title) {
            var toast = service.buildToast('Info:', message)
            service.getToaster().show(toast);
            //toastr.info(message, title);
            $log.info('Info: ' + message, data);
        }

        function success(message, data, title) {
            var toast = service.buildToast('Success!', message);
            service.getToaster().show(toast);
            $log.info('Success: ' + message, data);
        }

        function warning(message, data, title) {
            var toast = service.buildToast('Warning!', message);
            service.getToaster().show(toast);
            $log.warn('Warning: ' + message, data);
        }

        function getToaster() {
          if (!service.mdToastr) {
            service.mdToastr = $injector.get("$mdToast");
          }
          return service.mdToastr;
        }

        function buildToast(title, message) {
          var toast = getToaster().simple()
            .textContent(title + " " + message)
            .action('OK')
            .highlightAction(true)
            .position("bottom right");

          return toast;
        }
    }
}());
