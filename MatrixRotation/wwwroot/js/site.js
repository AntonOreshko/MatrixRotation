window.newSize = 3;
(function ($) {
    $('.spinner .btn:first-of-type').on('click', function () {
        var val = parseInt($('.spinner input').val(), 10) + 1;
        if (val <= 10) {
            $('.spinner input').val(val);
            window.newSize = val;
        }

    });
    $('.spinner .btn:last-of-type').on('click', function () {
        var val = parseInt($('.spinner input').val(), 10) - 1;
        if (val >= 2) {
            $('.spinner input').val(val);
            window.newSize = val;
        }
    });
})(jQuery);