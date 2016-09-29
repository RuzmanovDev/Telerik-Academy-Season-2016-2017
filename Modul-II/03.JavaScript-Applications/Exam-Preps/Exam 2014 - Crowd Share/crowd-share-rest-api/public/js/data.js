import  'jquery';
import cookie from  'js/cookie.js'

function encode(username, password) {
    return sha1(username + password)
}

var cookieName = 'sessionKey';

function setSessionKey(sessionKey) {
    cookie.set(cookieName, sessionKey, 10);
}
function getSessionKey() {
    return cookie.get(cookieName);
}
function removeSessionKey() {
    cookie.remove(cookieName);
}
export  default {
    users: {
        register: function (username, password) {
            var authcode = encode(username, password),
                data = {
                    username: username,
                    authCode: authcode
                };

            return new Promise(function (resolve, reject) {
                var url = '/user';

                $.ajax({
                    url: url,
                    type: 'POST',
                    contentType: 'application/json',
                    data: JSON.stringify(data),
                    success: function (data) {
                        resolve(data);
                    },
                    error: function (err) {
                        reject(err)
                    }
                });
            })
        },
        login: function (username, password) {
            var authCode = encode(username, password),
                data = {
                    username,
                    authCode
                };

            return new Promise(function (resolve, reject) {
                $.ajax({
                    url: '/auth',
                    type: 'POST',
                    contentType: 'application/json',
                    data: JSON.stringify(data),
                    success: function (data) {
                        resolve(data)
                    },
                    error: function (err) {
                        reject(err);
                    }
                })
            })
                .then(function (data) {
                    setSessionKey(data.sessionKey);
                    return data.username;
                });
        },
        logout: function () {
            var headers = {'X-SessionKey': getSessionKey()};
            return new Promise(function (resolve, reject) {

                $.ajax({
                    url: '/user/',
                    type: 'PUT',
                    headers: headers,
                    contentType: 'application/json',
                    data: null,
                    success: function (data) {
                        resolve(data)
                    },
                    error: function (err) {
                        reject(err);
                    }
                })
            }).then(function () {
                return removeSessionKey();
            });
        }
    },
    posts: {
        all: function () {
            return new Promise(function (resolve, reject) {
                $.ajax({
                    url: '/post',
                    type: 'GET',
                    contentType: 'application/json',
                    success: function (data) {
                        resolve(data);
                    },
                    error: function (err) {
                        reject(err);
                    }
                })
            })
        },
        add: function (title, body) {
            var data = {title, body},
                headers = {'X-SessionKey': getSessionKey()};

            return new Promise(function (resolve, reject) {
                    $.ajax({
                        url: '/post',
                        type: 'POST',
                        headers: headers,
                        contentType: 'application/json',
                        data: JSON.stringify(data),
                        success: function (data) {
                            resolve(data);
                        },
                        error: function (err) {
                            reject(err);
                        }

                    })

                }
            )
        }
    }
}