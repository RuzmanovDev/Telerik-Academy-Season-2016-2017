/* globals toastr */

const notifier = (()=> {

    function success(msg) {
        toastr.success(msg);
    }

    function error(err) {
        toastr.error(err);
    }

    return {
        success,
        error
    }
})();

export {notifier}