(function () {
    var sammyApp = Sammy('#content', function () {

        this.get('#/', homeController.all);

        this.get('#/login', userController.login);

        this.get('#/register', userController.register);

        this.get('#/todos', todosController.all);

        this.get('#/todos/add', todosController.add);
        //
        // this.get('#/events',eventsController.all);
    });

    $(function () {
        sammyApp.run('#/')
    });
}());