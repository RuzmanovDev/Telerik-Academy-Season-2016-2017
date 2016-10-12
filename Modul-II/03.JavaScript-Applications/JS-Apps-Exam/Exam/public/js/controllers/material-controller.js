var materialController = (function () {
    var mainContainer = $('#wrapper');
    var AUTH_KEY = 'adjfjfjasdajdjalks',
        USER_NAME = 'sadad';

    function isUserLoggedIn() {
        if (localStorage.getItem(AUTH_KEY) && localStorage.getItem(USER_NAME)) {
            return true;
        } else {
            return false;
        }
    }

    function home(context) {
        var searchPattern = context.params.filter;
        console.log(searchPattern);
        Promise.all([templateGenerator.load('home'), data.getAllMaterials(searchPattern)])
            .then(function ([template,data]) {
                console.log(data);
                mainContainer.html(template(data));
            })

    }

    function getById(context) {
        var id = context.params.id;

        Promise.all([templateGenerator.load('materialDetails'), data.getMaterialById(id)])
            .then(function ([template,data]) {
                mainContainer.html(template(data));
            })
            .then(function () {
                $('#btn-add-comment').on('click', function () {
                    var comment = $('#comment').val();

                    data.addComment(comment, id)
                        .then(function () {
                            notifier.success("The comment was added");
                            // this comes from SAMMY it DOES NOT REFRESH THE WHOLE PAGE!!!!
                            window.refreshState();
                        })
                        .catch(function () {
                            notifier.error("You must be logged in to comment");
                        });
                    console.log(comment);
                });

                $('#btn-add-to-category').on('click', function () {
                    var cateogry = $('#category-to-add').val();
                    data.assignCategory(id, cateogry)
                        .then(function () {
                            notifier.success("Material added to the selected category")
                        })
                        .catch(function (err) {
                            notifier.error("Error occured please try again")
                        })
                })

                $('#btn-change-category').on('click', function () {
                    var categoryChange = $('#category-to-change').val();
                    data.changeCategory(id, categoryChange)
                        .then(function () {
                            notifier.success("You have changed the category of he material");
                        })
                        .catch(function () {
                            notifier.error("Error occured! Please try again!")
                        })
                })
            });
    }

    function createNew(context) {
        if (!isUserLoggedIn()) {
            notifier.error("you must be logged in in order to create new Material");
            context.redirect('#/login');
            return;
        }

        templateGenerator.load("createNewMaterial")
            .then(function (template) {
                mainContainer.html(template);
            })
            .then(function () {
                $('#btn-add-material').on('click', function (ev) {
                    var title = $("#material-title").val(),
                        description = $("#material-description").val(),
                        image = $('#material-img').val();

                    if (!validator.validateTitle(title)) {
                        notifier.error("The title must be text between 6 and 100 chars");
                        return;
                    }

                    if (!validator.validateDescription(description)) {
                        notifier.error("The description must be string!");
                        return;
                    }
                    var material = {title, description, image};
                    data.addNewMaterial(material)
                        .then(function () {
                            notifier.success("The material has been added");
                            context.redirect('#/home');
                        })
                        .catch(function () {
                            notifier.error("The material wasn't added");
                        });

                    ev.preventDefault();
                    return false;
                });
            })
    }

    function search(context) {
        templateGenerator.load('search')
            .then(function (template) {
                mainContainer.html(template);
            })
            .then(function () {
                $('#search-btn').on('click', function () {
                    var searchFor = $("#search-for").val();
                    console.log(searchFor);
                    context.redirect(`#/home?filter=${searchFor}`);
                })
            })
    }

    return {
        home,
        getById,
        createNew,
        search
    }
}());