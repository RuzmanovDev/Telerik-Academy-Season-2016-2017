var todosController = (function () {
    function all(context) {
        var todos;
        data.todos.get()
            .then(function (resTodos) {
                todos = resTodos.result;
                console.log(todos);
                return templates.get('todos');
            })
            .then(function (template) {
                context.$element().html(template(todos));
            })
    }

    function add(context) {
        templates.get('todo-add')
            .then(function (template) {
                context.$element().html(template());
                $('#btn-todo-add').on("click", function () {
                    var textOfTodo = $('#tb-todo-add-content').val(),
                        category = $('#tb-todo-category').val();
                    console.log(textOfTodo);
                    console.log(category);

                    var todo = {
                        category: category,
                        text: textOfTodo
                    };

                    data.todos.add(todo)
                        .then(function () {
                            toastr.success("TODO ADDED");
                            context.redirect('#/todos');
                        })
                });
            })
    }

    return {
        all: all,
        add: add
    }
}());