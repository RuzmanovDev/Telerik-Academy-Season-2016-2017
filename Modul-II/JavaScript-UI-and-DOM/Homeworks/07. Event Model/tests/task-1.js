module.export =function solve() {
    function InvalidElement(message) {
        this.message = message;
        this.name = "InvalidElement";
    }

    function getValidElement(element) {
        if (typeof element === "string") {
            element = document.getElementById(element);
        }
        if (!(element instanceof HTMLElement)) {
            throw  new InvalidElement('InvalidElementPassed');
        }
        if (!element) {
            throw  new InvalidElement('InvalidElementPassed');
        }

        return element;
    }

    return function (elementId) {
        var i,
            len,
            element,
            allButtons,
            currentButton;

        if (arguments.length < 1) {
            throw  new InvalidElement("ss");
        }

        element = getValidElement(elementId);

        allButtons = element.getElementsByClassName('button');

        for (i = 0, len = allButtons.length; i < len; i += 1) {
            currentButton = allButtons[i];
            currentButton.innerHTML = 'hide';

            currentButton.addEventListener('click',
                function (ev) {
                    var clickedButton = ev.target,
                        nextContent,
                        isContentVisible;

                    nextContent = clickedButton.nextElementSibling;

                    while (nextContent && nextContent.className.indexOf('content') < 0) {
                        nextContent = nextContent.nextElementSibling;
                    }

                    isContentVisible = nextContent.style.display === '';

                    if (isContentVisible) {
                        nextContent.style.display = 'none';
                        clickedButton.innerHTML = 'show';
                    } else {
                        nextContent.style.display = '';
                        clickedButton.innerHTML = 'hide';
                    }
                })
        }
    }
}
