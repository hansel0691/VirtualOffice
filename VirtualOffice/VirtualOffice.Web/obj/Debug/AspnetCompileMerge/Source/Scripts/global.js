// general script functions
function viewport() {
    var e = window, a = 'inner';
    if (!('innerWidth' in window)) {
        a = 'client';
        e = document.documentElement || document.body;
    }
    return { width: e[a + 'Width'], height: e[a + 'Height'] };
}

$(document).ready(function(){

	// GENERAL:  Script to mimic arrows up/down toggle on panels
	$('.expand').click(function () {
		var $this = $(this);
		var $arrow = $this.find("span.glyphicon");

		if ($arrow.hasClass('glyphicon-chevron-down')) {
			$arrow.removeClass("glyphicon-chevron-down").addClass("glyphicon-chevron-up");
		}
		else {
			$arrow.removeClass("glyphicon-chevron-up").addClass("glyphicon-chevron-down");
		}
	});

});
