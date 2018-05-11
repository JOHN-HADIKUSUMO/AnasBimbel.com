$(function () {
 "use strict";

 var $window = $(window),
 $body = $('body');

 jQuery(document).ready(function($){

    	//Scroll-to-up
    	$('#scroll-up').hide();
    	$window.on("scroll", function () {
    		if ($window.scrollTop() > 300) {
    			$('#scroll-up').fadeIn();
    		} else {
    			$('#scroll-up').fadeOut();
    		}
    	});
    	$('#scroll-up').on("click", function () {
    		$("html, body").animate({
    			scrollTop: 0
    		}, 1000);
    		return false;
    	});

    }(jQuery));
});