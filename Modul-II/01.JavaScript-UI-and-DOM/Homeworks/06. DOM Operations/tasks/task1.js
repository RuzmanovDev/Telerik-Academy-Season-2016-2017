function solve() {
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
        return element;
    }

    function validateArgs(elementId, content) {
        if (arguments.length < 2
            || elementId === null
            || elementId === undefined
            || content === null
            || content === undefined
            || !Array.isArray(content)) {
            throw  new InvalidElement('InvalidElementPassed');
        }
    }

    return function (elementId, content) {
        var i,
            len,
            currentContent,
            div,
            fragment,
            element;

        validateArgs(elementId, content);
        element = getValidElement(elementId);

        fragment = document.createDocumentFragment();
        for (i = 0, len = content.length; i < len; i += 1) {
            currentContent = content[i];
            // validate current element
            if (typeof (currentContent) !== 'string' && typeof(currentContent) !== 'number') {
                throw  new InvalidElement('InvalidElementPassed');
            }
            div = document.createElement('div');
            div.innerHTML = currentContent;
            fragment.appendChild(div);
        }
        element.innerHTML = "";
        element.appendChild(fragment);
    }
}