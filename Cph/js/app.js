var cph = cph || {};

cph.init = function() {
    // validation
    $.validator.setDefaults({
        highlight: function(element) {
            $(element).closest('.form-group').addClass('has-error');
        },
        unhighlight: function(element) {
            $(element).closest('.form-group').removeClass('has-error');
        },
        errorElement: 'span',
        errorClass: 'help-block',
        errorPlacement: function(error, element) {
            if (element.parent('.input-group').length) {
                error.insertAfter(element.parent());
            } else {
                error.insertAfter(element);
            }
        },
        onfocusout: function(element) { $(element).valid(); } // fix for 'required' fields
    });
    $.validator.addMethod('date', function(value, element) {
        if (this.optional(element)) return true;
        return moment(value, 'DD/MM/YYYY').isValid();
    });

    // datepicker
    $('.datepicker').datepicker({
        format: 'dd/mm/yyyy'
    });
        
    // markdown editor
    $('.markdown').pagedownBootstrap({
        preview: '.markdown-preview'
    });
};
cph.refreshValidation = function($form) {
    $.validator.unobtrusive.parse($form);
};

// Locker (collaborative edit)
cph.Locker = function(lockEntityId, opts) {
    var lock = $.connection.lockHub;
    lock.client.unlock = function(entityId) {
        if (entityId == lockEntityId) {
            setFormEnabled(true);
        }
    };
    lock.client.lock = function(entityId) {
        if (entityId == lockEntityId) {
            setFormEnabled(false);
        }
    };
    lock.client.update = function(entityId) {
        if (entityId == lockEntityId) {
            $.get(opts.ajaxUrl, function (html) {
                var wasDisabled = !isFormEnabled();
                        
                // update html
                opts.$editBox.html(html);
                if (wasDisabled) setFormEnabled(false);
                        
                // refresh stuff
                cph.init(jQuery);
                cph.refreshValidation(opts.$editBox);
            });
        }
    };
    $.connection.hub.start().done(function() {
        lock.server.lock(lockEntityId).done(function(ok) {
            if (!ok) setFormEnabled(false);
        });
    });
    function setFormEnabled(enabled) {
        opts.$editBox.find(':input, textarea').attr('disabled', !enabled);
        setLockWarning(!enabled);
    }
    function isFormEnabled() {
        opts.$editBox.find(':input:first').is(':enabled');
    }
    function setLockWarning(show) {
        if (show) {
            opts.$editBox.prepend('<div class="lock-warning col-md-12"><div class="alert alert-danger">Somebody else is working on this page now. Please wait...</div></div>');
            $('.page-header').css('margin-bottom', '20px');
        } else {
            opts.$editBox.find('.lock-warning').remove();
            $('.page-header').attr('style', '');
        }
    }
};

cph.init();