/* globals Navigo */

import {threadController} from './controllers/thread-controller.js';

var router = (()=> {
    function init() {
        let navigo = new Navigo(null, true);

        navigo
            .on('/threads/:id', (params)=>threadController.getById(params.id))
            .on('/threads', threadController.getAllThreads)
            .on('/gallery', threadController.getGallery)
            .on(function () {
                threadController.getAllThreads();
            })
            .resolve();
    }


    return {
        init
    }
})();

export {router}