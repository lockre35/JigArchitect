(function() {
    'use strict';

    angular
        .module('app.widgets')
        .directive('rbSlider', rbSlider);

    /* @ngInject */
    function rbSlider () {
        // Wraps ramjet.js (https://github.com/Rich-Harris/ramjet)
        // Props to Rich Harris for this cool library

        // Usage:
        //  <div rb-slider show-elem="vm.showPreview" duration=".5s"></div>
        // Creates:
        //  (whatever it feels like)<div data-cc-sidebar class="sidebar">
        var directive = {
            link: link,
            restrict: 'A',
            scope: {
              showElem: '='
              // whenDoneAnimating: '&?'
            }
        };
        return directive;

        function link(scope, element, attrs) {



          attrs.duration = (!attrs.duration) ? '1s' : attrs.duration;
          attrs.easing = (!attrs.easing) ? 'ease-in-out' : attrs.easing;
          element.css({
            'overflow':'hidden',
            'height':'0px',
            'transitionProperty':'height',
            'transitionDuration':attrs.duration,
            'transitionTimingFunction':attrs.easing,
          });

          //element.wrapInner('<div class="slideable_content" style="margin:0 !important; padding:0 !important" ></div>')

          scope.$watch('showElem', function(value){
              if(value) {
                element.css({
                  height: element.get(0).scrollHeight + 'px'
                })
                // element[0].style.height = height + 'px';
              } else {
                element[0].style.height = '0px';
              }
          });
      }
    }
})();
