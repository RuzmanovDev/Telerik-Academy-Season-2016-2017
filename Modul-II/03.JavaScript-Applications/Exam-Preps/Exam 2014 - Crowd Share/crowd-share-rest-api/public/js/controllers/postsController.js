import template from 'js/templates.js'
import data from 'js/data.js'
import 'jquery'
import * as jsGrid from 'bower_components/jsgrid/dist/jsgrid.js';
import  notifier from 'js/notifier.js';

var mainContainer = $('#main');

export  default {
    all: function all(context) {

        var size = +context.params['size'] || 4,
            page = +context.params['page'] || 0;

        Promise.all([data.posts.all(), template.load('posts')])
            .then(function ([dataContent,htmlContent]) {

                mainContainer.html(htmlContent(
                    {
                        posts: dataContent
                    }));

                $("#posts").jsGrid({
                    width: "100%",
                    height: "400px",

                    sorting: true,
                    paging: true,
                    pageSize: size,
                    pageIndex: 2,
                    data: dataContent,

                    fields: [
                        {name: "id", type: "text", width: 150},
                        {name: "title", type: "text", width: 50},
                        {name: "body", type: "text", width: 200, height: "100%"},
                        {name: "user.username", type: "text", title:'Username'},
                    ]
                });

                $('#add-post').on('click', function () {
                    var title = $('#post-title').val(),
                        content = $('#post-content').val();

                    data.posts.add(title, content)
                        .then(function (data) {
                            notifier.success(data);
                            context.redirect('#/posts');
                        }, function (err) {
                            context.redirect('#/login');
                        })
                });

                $('#main').on('click', '#btn-filter', function (ev) {
                    var size = $('#dd-page-size option:selected').text(),
                        page = 0;
                    context.redirect(`#/posts/${size}/${page}`);
                });
            });


        // data.posts.all().then(function (dataContent) {
        //     template.load('posts')
        //         .then(function (htmlContent) {
        //             var pagesLen = ((dataContent.length / size) | 0) + 1,
        //                 pages = [];
        //
        //             for (var i = 0; i < pagesLen; i += 1) {
        //                 pages.push({
        //                     size: size,
        //                     page: i,
        //                     displayPage: i + 1
        //                 });
        //             }
        //             dataContent = dataContent.slice(page * size, (page + 1) * size);
        //             console.log(dataContent);
        //             mainContainer.html(htmlContent(
        //                 {
        //                     pages: pages,
        //                     posts: dataContent
        //                 }))
        //         }).then(function () {
        //
        //         $('#main').on('click', '#btn-filter', function (ev) {
        //             var size = $('#dd-page-size option:selected').text(),
        //                 page = 0;
        //             context.redirect(`#/posts/${size}/${page}`);
        //         });
        //
        //         $('#add-post').on('click', function () {
        //             var title = $('#post-title').val(),
        //                 content = $('#post-content').val();
        //
        //             data.posts.add(title, content)
        //                 .then(function (data) {
        //                     notifier.success(data);
        //                     context.redirect('#/posts');
        //                 }, function (err) {
        //                     context.redirect('#/login');
        //                 })
        //         })
        //     });
        // });

    }
}