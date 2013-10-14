var cph = cph || {};

(function ($) {
    // datepicker
    $('.datepicker').datepicker({
        format: 'dd/mm/yyyy'
    });

    // validation
    $.validator.setDefaults({
        highlight: function (element) {
            $(element).closest('.form-group').addClass('has-error');
        },
        unhighlight: function (element) {
            $(element).closest('.form-group').removeClass('has-error');
        },
        errorElement: 'span',
        errorClass: 'help-block',
        errorPlacement: function (error, element) {
            if (element.parent('.input-group').length) {
                error.insertAfter(element.parent());
            } else {
                error.insertAfter(element);
            }
        },
        onfocusout: function(element) { $(element).valid(); } // fix for 'required' fields
    });
    $.validator.addMethod('date', function (value, element) {
        if (this.optional(element)) return true;
        return moment(value, 'DD/MM/YYYY').isValid();
    });
})(jQuery);