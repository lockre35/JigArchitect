(function() {
    'use strict';

    angular
        .module('app.applicationManagement')
        .directive('fileOnChange', fileOnChange);

    /* @ngInject */
    function fileOnChange () {
      var directive = {
        restrict: 'A',
        scope: { method:'&fileOnChange' },
        link: link
      };
      return directive;

      function link (scope, element, attrs) {
        var parent = element.parent();
        var fileInput = document.createElement('input');
        fileInput.type = 'file';
        $(fileInput).hide();
        parent.append(fileInput);
        var onChangeHandler = scope.method();
        element.bind('click', function(){$(fileInput).trigger('click')});
        $(fileInput).bind('change', function(event){
          scope.$apply(onChangeHandler(event))
        });
      }
    }
})();
