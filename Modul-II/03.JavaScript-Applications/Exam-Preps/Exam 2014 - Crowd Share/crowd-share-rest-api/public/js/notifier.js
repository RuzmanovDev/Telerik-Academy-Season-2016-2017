import toastr from 'bower_components/toastr/toastr.js';

export default {
    success: function (msg) {
        toastr.success(msg);
    },
    error: function (err) {
        toastr.error(err);
        console.error(err);
    }
}