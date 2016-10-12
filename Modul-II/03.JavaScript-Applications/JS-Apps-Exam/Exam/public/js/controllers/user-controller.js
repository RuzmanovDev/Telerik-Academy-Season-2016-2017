/* globals templateGenerator, notifier, userData */

var userController = (function () {
    'use strict';

    var mainContainer = $('#wrapper'),
        AUTH_KEY = 'adjfjfjasdajdjalks',
        USER_NAME = 'sadad';

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

                    data.login(user)
                        .then(function (success) {
                            var response = success.result;
                            var username = response.username;
                            var authKey = response.authKey;
                            console.log(success);

                            localStorage.setItem(USER_NAME, username);
                            localStorage.setItem(AUTH_KEY, authKey);
                            notifier.success(`User ${user.username} is logged in!`)
                        })
                        .catch(function (errorLog) {
                            notifier.error(errorLog);
                            console.log(errorLog);
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

                    if (!validator.validateUserName(username)) {
                        notifier.error("The user name must be between 6 and 30")
                        return;
                    }

                    if (!validator.validatePassword(password)) {
                        notifier.error("The password must be between 6 and 30 symbols. And can contain only leter and digits!")
                        return;
                    }
                    var user = {
                        username,
                        password
                    };

                    data.register(user)
                        .then(function (user) {
                            notifier.success(`${username} successfully registered!`);
                        }).catch(function (errorLog) {
                        notifier.error(errorLog);
                        console.log(errorLog);
                    });

                });
            })
    }

    function logout() {
        localStorage.removeItem(AUTH_KEY);
        localStorage.removeItem(USER_NAME);

        notifier.success(`You have logged out successfully!`);
    }

    function usrProfile(context) {
        var username = context.params.username;

        Promise.all([templateGenerator.load('userProfile'), data.getUser(username)])
            .then(function ([template, userInfo]) {
                mainContainer.html(template(userInfo));
            })


    }

    return {
        login,
        register,
        logout,
        usrProfile
    }
}());