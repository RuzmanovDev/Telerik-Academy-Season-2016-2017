var data = (function () {
    var AUTH_KEY = 'adjfjfjasdajdjalks',
        USER_NAME = 'sadad';

    function getAllMaterials(searchPattern) {
        console.log(searchPattern);
        var url;
        if (!searchPattern) {
            url = 'api/materials';
        } else {
            url = `api/materials?filter=${searchPattern}`
        }
        return requester.get(url);
    }

    function getMaterialById(id) {
        var url = `api/materials/${id}`;

        return requester.get(url);
    }

    function addComment(comment, id) {
        var url = `api/materials/${id}/comments`,
            headers = {
                'ContentType': 'application/json',
                "x-auth-key": localStorage.getItem(AUTH_KEY)
            };
        var data = {
            "commentText": comment
        };

        return requester.put(url, {
            headers: headers,
            data: data
        })
    }

    function addNewMaterial(material) {
        console.log(material);
        var url = "api/materials",
            headers = {
                'ContentType': 'application/json',
                "x-auth-key": localStorage.getItem(AUTH_KEY)
            };

        return requester.post(url, {
            headers: headers,
            data: material
        })
    }

    function assignCategory(materialId, category) {

        var url = 'api/user-materials',
            headers = {
                'ContentType': 'application/json',
                "x-auth-key": localStorage.getItem(AUTH_KEY)
            };

        return requester.post(url, {
            headers: headers,
            data: {
                id: materialId,
                category: category
            }
        });
    }

    function changeCategory(materialId, category) {
        var url = 'api/user-materials',
            headers = {
                'ContentType': 'application/json',
                "x-auth-key": localStorage.getItem(AUTH_KEY)
            };

        return requester.put(url, {
            headers: headers,
            data: {
                id: materialId,
                category: category
            }
        });
    }

    function register(user) {
        var url = `api/users`,
            headers = {
                'ContentType': 'application/json',
            };
        return requester.post(url, {
            headers: headers,
            data: {
                "username": user.username,
                "password": user.password
            },
        });
    }

    function login(user) {
        var url = 'api/users/auth/',
            headers = {
                'ContentType': 'application/json',
            };

        return requester.put(url, {
            headers: headers,
            data: {
                username: user.username,
                password: user.password
            }
        })
    }

    function getUser(username) {
        var userToGet = '';
        if (!username) {
            userToGet = localStorage.getItem(USER_NAME);
        } else {
            userToGet = username;
        }

        var url = `api/profiles/${userToGet}`;

        return requester.get(url);
    }

    return {
        getAllMaterials,
        getMaterialById,
        addNewMaterial,
        assignCategory,
        changeCategory,
        addComment,
        register,
        login,
        getUser
    }

}());
