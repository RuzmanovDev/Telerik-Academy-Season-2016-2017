import {data} from './data.js';
import {router} from './routing.js';
import {notifier} from './notifier.js';
import{templateLoader} from './template-loader.js';

$(() => { // on document ready
    const GLYPH_UP = 'glyphicon-chevron-up',
        GLYPH_DOWN = 'glyphicon-chevron-down',
        root = $('#root'),
        navbar = root.find('nav.navbar'),
        mainNav = navbar.find('#main-nav'),
        contentContainer = $('#root #content'),
        loginForm = $('#login'),
        logoutForm = $('#logout'),
        usernameSpan = $('#span-username'),
        usernameInput = $('#login input');

    router.init();

    (function checkForLoggedUser() {
        data.users.current()
            .then((user) => {
                if (user) {
                    usernameSpan.text(user);
                    loginForm.addClass('hidden');
                    logoutForm.removeClass('hidden');
                }
            });
    })();

    // start threads

    navbar.on('click', 'li', (ev) => {
        let $target = $(ev.target);
        $target.parents('nav').find('li').removeClass('active');
        $target.parents('li').addClass('active');
    });

    contentContainer.on('click', '.btn-add-message', (ev) => {
        let $target = $(ev.target),
            $container = $target.parents('.container-messages'),
            thId = $container.attr('data-thread-id'),
            msg = $container.find('.input-add-message').val();

        data.threads.addMessage(thId, msg)
            .then(function (data) {
                let newPost = data.messages[data.messages.length - 1];
                console.log(newPost);
                templateLoader.get('message')
                    .then(function (template) {
                        var content = template(newPost);
                        $('#msg-add-form').append(content);
                    })
            })
            .then(notifier.success('Successfully added the new message', 'Success', 'alert-success'))
            .catch((err) => notifier.error(JSON.parse(err.responseText).err, 'Error', 'alert-danger'));
    });

    contentContainer.on('click', '.btn-close-msg', (ev) => {
        let msgContainer = $(ev.target).parents('.container-messages').remove();
    });

    contentContainer.on('click', '.btn-collapse-msg', (ev) => {
        let $target = $(ev.target);
        if ($target.hasClass(GLYPH_UP)) {
            $target.removeClass(GLYPH_UP).addClass(GLYPH_DOWN);
        } else {
            $target.removeClass(GLYPH_DOWN).addClass(GLYPH_UP);
        }

        $target.parents('.container-messages').find('.messages').toggle();
    });
    // end threads

    // start login/logout
    navbar.on('click', '#btn-login', (ev) => {
        let username = usernameInput.val() || 'anonymous';
        data.users.login(username)
            .then((user) => {
                usernameInput.val('');
                usernameSpan.text(user);
                loginForm.addClass('hidden');
                logoutForm.removeClass('hidden');
            })
    });
    navbar.on('click', '#btn-logout', (ev) => {
        data.users.logout()
            .then(() => {
                usernameSpan.text('');
                loginForm.removeClass('hidden');
                logoutForm.addClass('hidden');
            })
    });
    // end login/logout
});