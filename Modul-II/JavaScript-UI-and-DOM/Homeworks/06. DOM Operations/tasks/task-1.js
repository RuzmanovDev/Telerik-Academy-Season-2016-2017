/* globals $ */

/* 

Create a function that takes an id or DOM element and an array of contents

* if an id is provided, select the element
* Add divs to the element
  * Each div's content must be one of the items from the contents array
* The function must remove all previous content from the DOM element provided
* Throws if:
  * The provided first parameter is neither string or existing DOM element
  * The provided id does not select anything (there is no element that has such an id)
  * Any of the function params is missing
  * Any of the function params is not as described
  * Any of the contents is neight `string` or `number`
    * In that case, the content of the element **must not be** changed   
*/

module.exports = function solve() {
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
    };
};