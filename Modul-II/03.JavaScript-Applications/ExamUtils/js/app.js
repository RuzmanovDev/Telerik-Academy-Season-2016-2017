/* globals userController */

(function () {
    'use strict';

    var wrapper = '#wrapper';

    var sammyApp = Sammy(wrapper, function () {

        // User handling routes
        this.get('#/register', userController.register);
        this.get('#/login', userController.login);
        this.get('#/logout', userController.logout);


        this.get('#/', userController.login());

    });

    window.refreshState = () => sammyApp.refresh();

    sammyApp.run('#/');
}());
