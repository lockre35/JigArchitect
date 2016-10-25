(function() {
    'use strict';

    angular
        .module('app.widgets')
        .directive('rbRamjet', rbRamjet);

    /* @ngInject */
    function rbRamjet () {
        // Wraps ramjet.js (https://github.com/Rich-Harris/ramjet)
        // Props to Rich Harris for this cool library

        // Usage:
        //  <div rb-ramjet elem-a-id='' elem-b-id='' show-elem-a=''"></div>
        // Creates:
        //  (whatever it feels like)<div data-cc-sidebar class="sidebar">
        var directive = {
            link: link,
            restrict: 'A',
            scope: {
              showElemA: '='
              // whenDoneAnimating: '&?'
            }
        };
        return directive;

        function link(scope, element, attrs) {
          var a = document.getElementById('A'),
            b = document.getElementById('B');

          // to repeat, run this from the console!
          // set the stage so ramjet copies the right styles...
          scope.$watch('showElemA', function(value){
              if(value){
                a.classList.remove('hidden');

                ramjet.transform( b, a, {
                  done: function () {
                    // this function is called as soon as the transition completes
                    a.classList.remove('hidden');
                  }
                });

                // ...then hide the original elements for the duration of the transition
                a.classList.add('hidden');
                b.classList.add('hidden');
              } else {
                b.classList.remove('hidden');

                ramjet.transform( a, b, {
                  done: function () {
                    // this function is called as soon as the transition completes
                    b.classList.remove('hidden');
                  }
                });

                // ...then hide the original elements for the duration of the transition
                b.classList.add('hidden');
                a.classList.add('hidden');
              }

          });
            // var $sidebarInner = element.find('.sidebar-inner');
            // var $dropdownElement = element.find('.sidebar-dropdown a');
            // element.addClass('sidebar');
            // $dropdownElement.click(dropdown);
            //
            // function dropdown(e) {
            //     var dropClass = 'dropy';
            //     e.preventDefault();
            //     if (!$dropdownElement.hasClass(dropClass)) {
            //         $sidebarInner.slideDown(350, scope.whenDoneAnimating);
            //         $dropdownElement.addClass(dropClass);
            //     } else if ($dropdownElement.hasClass(dropClass)) {
            //         $dropdownElement.removeClass(dropClass);
            //         $sidebarInner.slideUp(350, scope.whenDoneAnimating);
            //     }
            // }
        }
    }
})();
