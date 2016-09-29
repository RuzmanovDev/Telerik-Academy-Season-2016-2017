/* globals $*/
var data = (function () {
    const STORAGE_AUTH_KEY = "SPECIAL_AUTH_KEY";
    // users
    function register(user) {
        var promise = new Promise(function (resolve, reject) {
            var url = 'api/users';
            var reqUser = {
                username: user.username,
                passHash: CryptoJS.SHA1(user.password).toString()
            };

            $.ajax(url, {
                method: 'POST',
                contentType: 'application/json',
                data: JSON.stringify(reqUser),
                success: function (res) {
                    resolve(res);
                }
            });
        });

        return promise;
    }

    function login(user) {
        var promise = new Promise(function (resolve, reject) {
            var url = 'api/users/auth';
            var reqUser = {
                username: user.username,
                passHash: CryptoJS.SHA1(user.password).toString()
            };

            $.ajax(url, {
                method: 'PUT',
                contentType: 'application/json',
                data: JSON.stringify(reqUser),
                success: function (res) {
                    localStorage.setItem(STORAGE_AUTH_KEY, res.result.authKey);
                    resolve(res);
                }
            });
        });

        return promise;
    }

    // todos
    function todosGet() {
        var promise = new Promise(function (resolve, reject) {
            var url = 'api/todos';
            $.ajax(url, {
                method: "GET",
                contentType: "application/json",
                headers: {
                    'x-auth-key': localStorage.getItem(STORAGE_AUTH_KEY)
                },
                success: function (res) {
                    resolve(res);
                }
            }).error(function (err) {
                reject(err);
            })
        });

        return promise;
    }

    function todosAdd(todo) {
        var promise = new Promise(function (resolve, reject) {
            var url = 'api/todos';
            $.ajax(url, {
                    method: "POST",
                    dataType: "application/json",
                    headers: {
                        'x-auth-key': localStorage.getItem(STORAGE_AUTH_KEY)
                    },
                    data: JSON.stringify(todo.result),
                    success: function (res) {
                        resolve(res);
                    },
                    error: function (err) {
                        reject(err);
                    }
                }
            )
        });

        return promise;
    }

    return {
        users: {
            register: register,
            login: login
        },
        todos: {
            get: todosGet,
            add: todosAdd,
        }
    }
}());
