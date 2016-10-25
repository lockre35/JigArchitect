(function() {
    'use strict';

    angular
        .module('app.listScreen')
        .controller('ListScreen', ['$q','logger','$routeParams',
        'datamodelService', 'listScreenService', '$timeout', ListScreen]);

    //ApplicationDashboard.$inject = ['$q', 'dataservice', 'logger', '$routeParams'];

    function ListScreen($q, logger, $routeParams, datamodelService, listScreenService, $timeout) {

        /*jshint validthis: true */
        var vm = this;

        vm.title = 'Application Dashboard';
        vm.applicationId = $routeParams.applicationId;
        vm.dataModel = {};
        vm.tables = {};
        vm.table = {};
        vm.screen = {};
        vm.loading = true;
        vm.getTableDetails = getTableDetails;
        vm.querySearch = querySearch;
        vm.addField = addField;
        vm.removeField = removeField;
        vm.togglePreview = togglePreview;
        activate();

        function activate() {
          return getDataModel()
            .then(getListScreen)
            .then(getTables)
            .then(function(){
              vm.loading = false;
              logger.info('Activated create list screen');
            });
        }

        function togglePreview(){
          vm.showPreview = !vm.showPreview;
        }

        function querySearch (query) {
          var fields = [];
          if(vm.table.Name){
            vm.table.Columns.forEach(function(col){
              var smallData = {};
              smallData.FullName = table.ParentSchemaName + '.' + table.Name;
              smallData.TableName = table.Name;
              smallData.Type = col.NativeDataTypeName;
              smallData.ColumnName = col.Name;
              fields.push(smallData);
            });
          }

          var results = query ? fields.filter( createFilterFor(query) ) : [];
          return results;
        }

        function createFilterFor(query) {
          var lowercaseQuery = angular.lowercase(query);
          return function filterFn(obj) {
            return (angular.lowercase(obj.ColumnName).indexOf(lowercaseQuery) === 0
              || angular.lowercase(obj.FullName).indexOf(lowercaseQuery) === 0);
          };
        }

        function addField(){
          var field = {};
          vm.screen.Fields.Field.push(field);
        }

        function removeField(field){
          var index = vm.screen.Fields.Field.indexOf(field);
          vm.screen.Fields.Field.splice(index, 1);
        }

        function getTableDetails() {
          var splitDataSource = vm.screen._DataSourceName.split(".");
          return datamodelService.getTable(splitDataSource[0], splitDataSource[1]).then(function(data) {
            vm.table = data;
            return vm.table;
          });
        }

        function getTables() {
          return datamodelService.getTables().then(function(data) {
            vm.tables = data;
            getTableDetails();
            return vm.tables;
          });
        }

        function getDataModel() {
            return datamodelService.getDataModel(vm.applicationId).then(function(data) {
                vm.dataModel = data;
                return vm.dataModel;
            });
        }

        function getListScreen() {
            return listScreenService.getListScreen().then(function(data) {
                vm.screen = data;
                return vm.screen;
            });
        }
    }
})();
