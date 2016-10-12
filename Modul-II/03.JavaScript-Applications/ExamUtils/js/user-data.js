/* globals requester */

var userData = (function () {
    'use strict';

    function login(user) {
        var url = 'api',
            headers = {
                'ContentType': 'application/json',
            };

        return requester.post(url, headers);
    }

    function register(user) {
        var url = `api`,
            headers = {
                'ContentType': 'application/json',
            };

        return requester.post(url, {
            headers: headers,
            data: user,
        });
    }

    function logout() {
        var url = 'api',
            headers = {
                'ContentType': 'application/json',
            };

        return requester.post(url, {headers});
    }

    return {
        login,
        register,
        logout
    }
}());