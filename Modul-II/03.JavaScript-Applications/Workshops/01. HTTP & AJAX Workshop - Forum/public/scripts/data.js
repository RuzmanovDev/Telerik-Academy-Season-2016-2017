import {requester} from './requester.js';

var data = (function () {
    const USERNAME_STORAGE_KEY = 'username-key';

    // start users
    function userLogin(user) {
        localStorage.setItem(USERNAME_STORAGE_KEY, user);
        return Promise.resolve(user);
    }

    function userLogout() {
        localStorage.removeItem(USERNAME_STORAGE_KEY);
        return Promise.resolve();
    }

    function userGetCurrent() {
        return Promise.resolve(localStorage.getItem(USERNAME_STORAGE_KEY));
    }

    // end users

    // start threads
    function threadsGet() {
        let url = 'api/threads';
        return requester.get(url);
    }

    function threadsAdd(title) {
        let username = localStorage.getItem(USERNAME_STORAGE_KEY);
        let url = 'api/threads';
        return requester.post(url, {
            data: {
                title: title,
                username: username
            }
        });
    }

    function threadById(id) {
        let url = `api/threads/${id}`;
        return requester.get(url);
    }

    function threadsAddMessage(threadId, content) {
        var url = `api/threads/${threadId}/messages`;
        let username = localStorage.getItem(USERNAME_STORAGE_KEY) || 'anonymous';
        let data = {
            userName: username,
            message: content,
            author: userGetCurrent()
        };

        return requester.post(url, {data: data})
    }

    // end threads

    // start gallery
    function galleryGet() {
        const REDDIT_URL = `https://www.reddit.com/r/aww.json?jsonp=?`;
        return requester.jsonP(REDDIT_URL);
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

export {data}