function send(method, url, options) {
    options = options || {};

    var headers = options.headers || {},
        data = options.data || undefined;

    var promise = new Promise(function (resolve, reject) {
        $.ajax({
            url: url,
            method: method,
            contentType: 'application/json',
            headers: headers,
            data: JSON.stringify(data),
            success: function (res) {
                resolve(res);
            },
            error: function (err) {
                reject(err);
            }
        });
    });
    return promise;
}

function jsonPRequest(url) {
    return new Promise(function (resolve, reject) {
        $.ajax({
            url: url,
            jsonp: "callback",
            dataType: "jsonp",
            success: function (response) {
                resolve(response)
            },
            error: function (err) {
                reject(err);
            }
        })
    })
}

const requester = (()=> {
    function get(url, options) {
        return send('GET', url, options);
    }

    function post(url, options) {
        return send('POST', url, options);
    }

    function put(url, options) {
        return send('PUT', url, options);
    }

    function del(url, options) {
        return send('POST', url, options);
    }

    function jsonP(url) {
        return jsonPRequest(url);
    }

    return {
        get,
        post,
        put,
        del,
        jsonP
    }
})();

export {requester};