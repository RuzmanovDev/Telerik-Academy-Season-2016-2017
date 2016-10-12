/* globals toastr */

var notifier = (function () {
    'use strict';

    function success(message) {
        toastr.success(message);
    }

    function error(errorLog) {
        toastr.error(errorLog);
    }

    return {
        success,
        error
    }
}());

