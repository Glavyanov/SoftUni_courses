jQuery(function ($) {
	$.validator.addMethod('number', function (value, element) {
		return this.optional(element) || /^(?:-?\d+)(?:(\.|,)\d+)?$/.test(value);
	});

	$.validator.addMethod('range', function (value, element, param) {
		value = /,/.test(value) ? value.replace(/,/g, '.') : value;
		return this.optional(element) || (value >= param[0] && value <= param[1]);
	});
});