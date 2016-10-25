(function() {
    'use strict';

    angular
        .module('app.core')
        .factory('datamodelService', ['$http', '$location', '$q', 'exception', 'logger', 'config', '$window', datamodelService]);

    /* @ngInject */
    function datamodelService($http, $location, $q, exception, logger, config, $window) {

        var service = {
            getDataModel: getDataModel,
            getTables: getTables,
            getTable: getTable
        };

        return service;

        function getTable(schemaName, tableName){
          return getDataModel($window.sessionStorage.getItem('builder-dataModelId'))
            .then(returnTable);

          function returnTable(data, status, headers, config) {
            var result = data.Tables.filter(function(obj) {
              return obj.ParentSchemaName === schemaName
                && obj.Name == tableName;
            });

            return result[0];
          }
        }

        function getTables(){
          return getDataModel($window.sessionStorage.getItem('builder-dataModelId'))
            .then(returnTables);

          function returnTables(data, status, headers, config) {
            var tables = data.Tables.map(function(table){
              var smallData = {};
              smallData.FullName = table.ParentSchemaName + '.' + table.Name;
              smallData.Name = table.Name;
              smallData.ParentSchemaName = table.ParentSchemaName;
              return smallData;
            });
            return tables;
          }
        }

        function getDataModel(applicationId) {
          if($window.sessionStorage.getItem('builder-dataModelId') !== applicationId){
            $window.sessionStorage.removeItem('builder-dataModelId');
            $window.sessionStorage.removeItem('builder-dataModel');
          }

          if($window.sessionStorage.getItem('builder-dataModelId')) {
            return getDataModelFromSession()
              .then(returnSessionData);
          } else {
            return $http
              .get(config.apiUrl + '/api/application/' + applicationId + '/schema')
              .then(dataModelRequestComplete)
              .catch(function(message) {
                  exception.catcher('Loading data model failed')(message);
              });
          }

          function dataModelRequestComplete(data) {
            $window.sessionStorage.setItem('builder-dataModel', data.data.objectModel);
            $window.sessionStorage.setItem('builder-dataModelId', applicationId);
            return JSON.parse(data.data.objectModel);
          }

          function getDataModelFromSession(){
            return $q(function(resolve, reject) {
              setTimeout(function() {
                var parsedObject = JSON.parse($window.sessionStorage.getItem('builder-dataModel'));
                resolve(parsedObject);
              }, 1);
            });
          }

          function returnSessionData(data, status, headers, config) {
            return data;
          }
        }
    }
})();
