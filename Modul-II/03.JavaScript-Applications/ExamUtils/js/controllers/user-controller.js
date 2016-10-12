/* globals templateGenerator, notifier, userData */

var userController = (function () {
    'use strict';

    var mainContainer = $('#wrapper'),
        AUTH_KEY = 'adjfjfjasdajdjalks';

    function login() {
        templateGenerator.load('login')
            .then(function (template) {
                mainContainer.html(template);
            })
            .then(function () {
                $('#btn-login').on('click', function () {
                    var $username = $('#user-name'),
                        $password = $('#input-password'),
                        username = $username.val(),
                        password = $password.val();

                    var user = {
                        username,
                        password
                    };

                    userData.login(user)
                        .then(function (success) {
                            localStorage.setItem(AUTH_KEY, success.outKey);
                        })
                        .then(function (user) {
                            notifier.success(`User ${user.username} is logged in!`)
                        })
                        .catch(function (errorLog) {
                            notifier.error(errorLog);
                        })
                })
            })

    }

    function register() {
        templateGenerator.load('register')
            .then(function (template) {
                mainContainer.html(template);
            })
            .then(function () {
                $('#btn-register').on('click', function (ev) {
                    var $username = $('#user-name'),
                        $password = $('#input-password'),
                        username = $username.val(),
                        password = $password.val();

                    var user = {
                        username,
                        password
                    };

                    userData.register(user)
                        .then(function (user) {
                            notifier.success(`${user.username} successfully registered!`);
                        }).catch(function (errorLog) {
                        notifier.error(errorLog);
                        console.log(errorLog);
                    });

                });
            })
    }

    function logout() {
        userData.logout()
            .then(function () {
                localStorage.removeItem(AUTH_KEY);
            })
            .then(function (data) {
                notifier.success(`You have logged out successfully!`);
            })
            .catch(function (errorLog) {
                notifier.error('You are not logged in!');
                console.log(errorLog);
            });
    }

    return {
        login,
        register,
        logout
    }
}());