import 'jquery'
import templates from 'js/templates.js'
import validator from 'js/validator.js'
import notifier from 'js/notifier.js'
import data from 'js/data.js'


var mainContainer = $('#main');

function login(context) {
    templates.load('login')
        .then(function (htmlContent) {
            mainContainer.html(htmlContent);
        })
        .then(function () {
            $('#btn-login').on('click', function () {
                var username = $('#user-name').val(),
                    password = $('#inputPassword').val();
                data.users.login(username, password)
                    .then(function (username) {
                        notifier.success(`User ${username} logged in`);
                        context.redirect('#/posts');
                    })
                    .catch(function (err) {
                        notifier.error(err);
                    })
            });
        });


}

function register(context) {
    templates.load('register')
        .then(function (htmlContent) {
            mainContainer.html(htmlContent);
        })
        .then(function () {
            $('#btn-register').on('click', function () {
                var username = $('#user-name').val(),
                    password = $('#inputPassword').val();

                validator.stringLength(password, 6, 40)
                    .then(function () {
                        return data.users.register(username, password)
                    })
                    .then(function (data) {
                        console.log(data);
                        notifier.success(`User registered`);
                        context.redirect('#/login');
                    })
                    .catch(function (err) {
                        notifier.error(err);
                    });
            });
        });
}
function logout(context) {
    data.users.logout()
        .then(function (data) {
            notifier.success('Logged out');
            context.redirect('#/login');
        })
        .catch(function (err) {
            notifier.error(err);
        });
}

export default {
    login,
    register,
    logout
}