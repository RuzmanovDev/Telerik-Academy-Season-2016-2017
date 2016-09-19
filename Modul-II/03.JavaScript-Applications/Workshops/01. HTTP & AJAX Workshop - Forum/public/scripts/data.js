var data = (function () {
    const USERNAME_STORAGE_KEY = 'username-key';

    // start users
    function userLogin(user) {
        localStorage.setItem(USERNAME_STORAGE_KEY, user);
        return Promise.resolve(user);
    }

    function userLogout() {
        localStorage.removeItem(USERNAME_STORAGE_KEY)
        return Promise.resolve();
    }

    function userGetCurrent() {
        return Promise.resolve(localStorage.getItem(USERNAME_STORAGE_KEY));
    }

    // end users

    // start threads
    function threadsGet() {
        return new Promise((resolve, reject) => {
            $.getJSON('api/threads')
                .done(resolve)
                .fail(reject);
        })
    }

    function threadsAdd(title) {
        return new Promise(function (resolve, reject) {
            let username = userGetCurrent()
                .then(function (username) {
                    $.ajax("api/threads", {
                        type: 'POST',
                        contentType: 'application/json',
                        data: JSON.stringify({
                            title: title,
                            username: username
                        }),
                        success: function (data) {
                            resolve(data);
                        },
                        error: function (err) {
                            reject(err);
                        }
                    });
                });

        });
    }

    function threadById(id) {
        return new Promise(function (resolve, reject) {
            var url = `api/threads/${id}`;
            $.ajax(url, {
                type: 'GET',
                contentType: 'application/json',
                success: function (data) {
                    resolve(data);
                },
                error: function (err) {
                    reject(err);
                }
            });
        });
    }

    function threadsAddMessage(threadId, content) {
        var url = `api/threads/${threadId}/messages`;

        return new Promise(function (resolve, reject) {
            let username = localStorage.getItem(USERNAME_STORAGE_KEY) || 'annonymous';
            $.ajax(url, {
                type: "POST",
                contentType: "application/json",
                data: JSON.stringify({
                    userName: username,
                    message: content,
                    author: userGetCurrent()
                }),
                success: function (data) {
                    resolve(data);
                },
                error: function (err) {
                    reject(err);
                }
            });
        })
    }

    // end threads

    // start gallery
    function galleryGet() {
        const REDDIT_URL = `https://www.reddit.com/r/aww.json?jsonp=?`;
        return new Promise(function (resolve, reject) {
            $.ajax({
                url: REDDIT_URL,
                jsonp: "callback",
                dataType: "jsonp",
                success: function (response) {
                    resolve(response)
                },
                error: function (err) {
                    reject(err);
                }
            })
        });
    }

    // end gallery

    return {
        users: {
            login: userLogin,
            logout: userLogout,
            current: userGetCurrent
        },
        threads: {
            get: threadsGet,
            add: threadsAdd,
            getById: threadById,
            addMessage: threadsAddMessage
        },
        gallery: {
            get: galleryGet,
        }
    }
})();