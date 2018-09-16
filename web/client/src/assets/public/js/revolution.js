(function($){
  "use strict";

    var tpj=jQuery;
      var revapi2;
      tpj(document).ready(function() {
        if(tpj("#rev_slider_2_1").revolution == undefined){
          revslider_showDoubleJqueryError("#rev_slider_2_1");
        }else{
          revapi2 = tpj("#rev_slider_2_1").show().revolution({
            sliderType:"standard",
            sliderLayout:"fullwidth",
            dottedOverlay:"none",
            delay:9000,
            navigation: {
              keyboardNavigation:"off",
              keyboard_direction: "horizontal",
              mouseScrollNavigation:"off",
                             mouseScrollReverse:"default",
              onHoverStop:"off",
              bullets: {
                enable:true,
                hide_onmobile:false,
                style:"hermes",
                hide_onleave:false,
                direction:"horizontal",
                h_align:"center",
                v_align:"bottom",
                h_offset:0,
                v_offset:50,
                                space:10,
                tmp:''
              }
            },
            visibilityLevels:[1240,1024,778,480],
            gridwidth:1570,
            gridheight:1000,
            lazyType:"none",
            shadow:0,
            spinner:"spinner3",
            stopLoop:"off",
            stopAfterLoops:-1,
            stopAtSlide:-1,
            shuffle:"off",
            autoHeight:"off",
            disableProgressBar:"on",
            hideThumbsOnMobile:"off",
            hideSliderAtLimit:0,
            hideCaptionAtLimit:0,
            hideAllCaptionAtLilmit:0,
            debugMode:false,
            fallbacks: {
              simplifyAll:"off",
              nextSlideOnWindowFocus:"off",
              disableFocusListener:false,
            }
          });
        }
      }); 
  })(jQuery);