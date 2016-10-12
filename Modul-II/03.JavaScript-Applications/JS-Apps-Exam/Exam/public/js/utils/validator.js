var validator = (function () {
    'use strict';

    function validateUserName(str) {
        if (typeof str !== 'string' || str.length < 6 || str.length > 30) {
            return false;
        }
        var patt = /([A-Za-z._])+/g;
        var result = patt.test(str);
        return result
    }

    function validatePassword(password) {
        if (typeof password !== 'string' || password.length < 6 || password.length > 30) {
            return false;
        }
        var patt = /([A-Za-z0-9])+/g;
        var result = patt.test(password);
        return result
    }

    function validateTitle(title) {
        if (typeof title !== 'string' || title.length < 6 || title.length > 100) {
            return false;
        }
        return true;
    }

    function validateDescription(str) {
        if (typeof str === 'undefined' || typeof str !== 'string') {
            return false;
        }
        return true;
    }

    function validateUrl(url) {

        if (!url || url.length === 0) {
            return;
        }
        //copied from http://stackoverflow.com/questions/5717093/check-if-a-javascript-string-is-an-url#answer-5717133
        var pattern = /((([A-Za-z]{3,9}:(?:\/\/)?)(?:[-;:&=\+\$,\w]+@)?[A-Za-z0-9.-]+|(?:www.|[-;:&=\+\$,\w]+@)[A-Za-z0-9.-]+)((?:\/[\+~%\/.\w-_]*)?\??(?:[-\+=&;%@.\w_]*)#?(?:[\w]*))?)/;
        if (!pattern.test(url)) {
            return {
                message: 'Invalid url'
            };
        }
    }

    return {
        validateUserName,
        validatePassword,
        validateTitle,
        validateDescription
    };
}());
