(function() {
    'use strict';

    angular
        .module('app.hello')
        .controller('Hello', ['dataservice', 'logger', HelloWorld]);

    /* @ngInject */
    function HelloWorld(dataservice, logger) {
        /*jshint validthis: true */
        var vm = this;
        vm.testData = {};
        vm.title = 'Hello World';
        vm.loading = true;

        activate();

        function activate() {
//            Using a resolver on all routes or dataservice.ready in every controller
//            var promises = [getAvengers()];
//            return dataservice.ready(promises).then(function(){
            return getAvengers().then(function() {
                //logger.info('Hello World View');
            });
        }

        function getAvengers() {
            vm.loading = true;
            return dataservice.getAvengers().then(function(data) {
                vm.testData = data;
                vm.loading = false;
                return vm.testData;
            });
        }
    }
})();
