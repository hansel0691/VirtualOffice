// JavaScript Document
// Scripts for landing login form validation

$(document).ready(function() {
	var form = $("#form").validate({
		debug: true,
		rules: {
			"exampleInputEmail1": {
				required: true,
				email: true
			},
			"exampleInputPassword1": {
				required: true,
				minlength: 6,
			},
			"checkbox": {
				required: true,
			},
		},
		errorElement: "span",
		errorClass: "has-error",
		validClass: "has-success",

		highlight: function(element, errorClass, validClass) {
			$(element).closest('.form-group').addClass(errorClass).removeClass(validClass);
			//$(element.form).find("label[for=" + element.id + "]").addClass(errorClass);
		},
		unhighlight: function(element, errorClass, validClass) {
			$(element).closest('.form-group').removeClass(errorClass).addClass(validClass);
			//$(element.form).find("label[for=" + element.id + "]").removeClass(errorClass);
		},

		/*errorPlacement: function(error, element) {
			error.appendTo( element.parent('div').find('.help-block') );
		},*/

		submitHandler: function() {
			var url = "home.html";
			$(location).attr('href',url);
		},

		invalidHandler: function() {
			var errors = form.numberOfInvalids();
			if (errors) {
				$('.alert').addClass('in alert-danger');
				//alert(errors);
				var message = (errors === 1) ? 'You missed 1 field. It has been highlighted' : 'You missed ' + errors + ' fields. They have been highlighted';
				$(".alert .msg").html(message);
				$('.alert').show();
			} else {
				$(".alert").hide();
			}
			//alert("This is error!");
		}
	});
});
