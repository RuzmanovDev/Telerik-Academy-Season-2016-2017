/* globals userController */

(function () {
    'use strict';

    var wrapper = '#wrapper';

    var sammyApp = Sammy(wrapper, function () {
        this.get('#/', function (context) {
            context.redirect('#/home');
        });
        this.get('#/home', materialController.home);

        // User handling routes
        this.get('#/register', userController.register);
        this.get('#/login', userController.login);
        this.get('#/logout', userController.logout);

        this.get('#/profiles', userController.usrProfile);
        this.get('#/profiles/:username', userController.usrProfile);

        this.get('#/materials/:id', materialController.getById);

        this.get('#/createNewMaterial',materialController.createNew);

        this.get('#/search', materialController.search)

    });

    // this comes from SAMMY it DOES NOT REFRESH THE WHOLE PAGE!!!!
    window.refreshState = () => sammyApp.refresh();

    sammyApp.run('#/');
}());
