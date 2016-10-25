(function() {
    'use strict';

    angular
        .module('app.listScreen')
        .factory('listScreenService', ['$http', '$location', '$q', 'exception',
          'logger', 'config', listScreenService]);

    /* @ngInject */
    function listScreenService($http, $location, $q, exception, logger, config) {
        var isPrimed = false;
        var primePromise;

        var service = {
            getListScreen: getListScreen,
            ready: ready
        };

        return service;

        // Replace calls to stubs with $http.get()
        function getScreensStub() {
            var listScreen = {
                  "Fields": {
                      "Field": [
                          {
                              "_Type": "Hidden",
                              "_Name": "EventID"
                          },
                          {
                              "_Type": "Text",
                              "_Name": "Login_UserName",
                              "_Title": "User"
                          },
                          {
                              "_Type": "Text",
                              "_Name": "LoggingStatus_Dom",
                              "_Title": "Status"
                          },
                          {
                              "_Type": "Text",
                              "_Name": "SQLServerName",
                              "_Title": "SQL Server"
                          },
                          {
                              "_Type": "Text",
                              "_Name": "Message",
                              "_Title": "Message"
                          }
                      ]
                  },
                  "_Name": "ListLogEvent",
                  "_Type": "List",
                  "_Title": "Events",
                  "_Paging": "True",
                  "_DataSourceName": "Log.Event",
                  "_ConfirmFieldName": "SQLStoredProcName",
                  "_OrderBy": "OccurrenceDatetime",
                  "_EditButtonScreen": "Null",
                  "_CreateButtonScreen": "NULL",
                  "_DeleteButtonScreen": "NULL"
              };

            return $q(function(resolve, reject) {
              var millisecondsToWait = 500;
              setTimeout(function() {
                  // Whatever you want to do after the wait
                  resolve(listScreen);
              }, millisecondsToWait);
            });
        }

        function getListScreen() {
            var count = 0;
            return getScreensStub()
                .then(getScreensComplete)
                .catch(exception.catcher('XHR Failed for screens'));

            function getScreensComplete(data) {
              data._Paging = data._Paging === "True";
              data.Fields.Field.forEach(function(field){
                field.searchText = field._Name;
              })
              return $q.when(data);
            }
        }

        function prime() {
            // This function can only be called once.
            if (primePromise) {
                return primePromise;
            }

            primePromise = $q.when(true).then(success);
            return primePromise;

            function success() {
                isPrimed = true;
                logger.info('Primed data');
            }
        }

        function ready() {

        }

    }
})();
