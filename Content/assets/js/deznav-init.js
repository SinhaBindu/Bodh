
"use strict"

var dezSettingsOptions = {};

function getUrlParams(dParam) 
	{
		var dPageURL = window.location.search.substring(1),
			dURLVariables = dPageURL.split('&'),
			dParameterName,
			i;

		for (i = 0; i < dURLVariables.length; i++) {
			dParameterName = dURLVariables[i].split('=');

			if (dParameterName[0] === dParam) {
				return dParameterName[1] === undefined ? true : decodeURIComponent(dParameterName[1]);
			}
		}
	}

(function($) {
	
	"use strict"
	
	var direction =  getUrlParams('dir');
	
	if(direction == 'rtl')
	{
        direction = 'rtl'; 
    }else{
        direction = 'ltr'; 
    }
	
	dezSettingsOptions = {
		typography: "poppins",
			version: "light",
			layout: "vertical",
			primary: "color_1",
			headerBg: "color_1",
			navheaderBg: "color_3",
			sidebarBg: "color_3",
			sidebarStyle: "full",
			sidebarPosition: "fixed",
			headerPosition: "fixed",
			containerLayout: "full",
			direction: direction
		};
	
	
	
	new dezSettings(dezSettingsOptions); 

	jQuery(window).on('resize',function(){
        /*Check container layout on resize */
		///alert(dezSettingsOptions.primary);
        dezSettingsOptions.containerLayout = $('#container_layout').val();
        /*Check container layout on resize END */
        
		new dezSettings(dezSettingsOptions); 
		
	});
	if(direction == 'rtl' || body.attr('direction') == 'rtl'){
        direction = 'rtl';
			jQuery('.main-css').attr('href','https://tixia.dexignzone.com/xhtml/page-error-404.html');
		}else{
			direction = 'ltr';
			jQuery('.main-css').attr('href','https://tixia.dexignzone.com/xhtml/page-error-404.html');
		}
	
})(jQuery);

 	