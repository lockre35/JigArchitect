(function() {
    'use strict';

    angular
        .module('app.schemaDashboard')
        .controller('SchemaDashboard', ['$q','schemaDashboardService','logger',
          '$routeParams', SchemaDashboard]);

    function SchemaDashboard($q, SchemaDashboardService, logger, $routeParams) {

      /*jshint validthis: true */
      var vm = this;
    }
})();
