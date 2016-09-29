import {data} from "../data.js"
import{templateLoader} from "../template-loader.js";
import  {notifier} from "../notifier.js";

const threadController = (()=> {
    const root = $('#root'),
        navbar = root.find('nav.navbar'),
        contentContainer = $('#root #content');

    function getAllThreads() {
        return Promise.all([data.threads.get(), templateLoader.get('thread')])
            .then(function ([data,template]) {
                let html = template(data);
                $('#content').html(html);
            })
            .then(function () {
                contentContainer.on('click', '#btn-add-thread', (ev) => {
                    let title = $(ev.target).parents('form').find('input#input-add-thread').val() || null;
                    data.threads.add(title)
                        .then(function (data) {
                            console.log(data);
                            templateLoader.get('single-thread')
                                .then(function (template) {
                                    var content = template(data);
                                    $('#threads').append(content);
                                })
                        })
                        .then(notifier.success('Successfully added the new thread', 'Success', 'alert-success'))
                        .catch((err) => notifier.error(JSON.parse(err.responseText).err, 'Error', 'alert-danger'));
                });
            })
    }

    function getGallery() {
        return Promise.all([data.gallery.get(), templateLoader.get('gallery')])
            .then(function ([data,template]) {
                let html = template(data);
                $('#content').html(html);
            })
    }

    function getById(id) {
        return Promise.all([data.threads.getById(id), templateLoader.get('messages')])
            .then(function ([data,template]) {
                let html = template(data);
                $('#content').append(html);
            })
            .then(function () {

            })
    }

    return {
        getAllThreads,
        getGallery,
        getById
    }
})();


export {threadController}