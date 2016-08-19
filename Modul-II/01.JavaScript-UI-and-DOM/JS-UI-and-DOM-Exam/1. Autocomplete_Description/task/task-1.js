/* globals document, window, console */

function solve() {
    return function (selector, initialSuggestions) {
        var container = document.querySelector(selector);
        initialSuggestions = initialSuggestions || [];
        var input = container.getElementsByClassName("tb-pattern")[0];
        var suggestionsList = container.getElementsByClassName("suggestions-list")[0];
        var autocompleateList = container.getElementsByClassName("suggestion");
        var addButton = container.getElementsByClassName("btn-add")[0];


        //templates
        var liTemplate = document.createElement("li");
        liTemplate.className = "suggestion";

        var linkTemplate = document.createElement("a");
        linkTemplate.className = "suggestion-link";
        // end of templates

        addSuggestionsToList(initialSuggestions);
        // hide the elements
        initialyHideElements();
        function initialyHideElements() {
            [].forEach.call(autocompleateList, function (element) {
                element.style.display = "none";
            })
        }

        input.addEventListener("input", showSuggestions, false);

        addButton.addEventListener("click", function () {
            var textFromInput = input.value;
            var links = container.getElementsByClassName("suggestion-link");
            var isContained = false;
            [].forEach.call(links, function (element) {
                var textFromelement = element.innerHTML;
                if (textFromelement.toLowerCase() === textFromInput.toLowerCase()) {
                    isContained = true;
                }
            });
            if (!isContained) {
                addSuggestionsToList([textFromInput]);
            }

        });
        suggestionsList.addEventListener("click", function (ev) {

            if (ev.target.className === "suggestion-link") {
                var text = ev.target.innerHTML;
                input.value = text;
            }
        });

        // add autocompleateEventListener
        function autoCompleateEventListener() {

        }

        function addSuggestionsToList(elements) {
            var docFragment = document.createDocumentFragment();

            elements.forEach(function (element) {
                var content = linkTemplate.cloneNode(true);
                content.innerHTML = element;
                var li = liTemplate.cloneNode(true);
                li.appendChild(content);
                docFragment.appendChild(li);
            });

            suggestionsList.appendChild(docFragment);
        }

        function showSuggestions() {
            var text = this.value.toLowerCase();
            [].forEach.call(autocompleateList, function (element) {
                var links = element.getElementsByClassName("suggestion-link")[0];
                var textInLinks = links.innerHTML.toLowerCase();
                // console.log(text);
                // console.log(textInLinks);
                if (text === "" || textInLinks.indexOf(text) < 0) {
                    // element.style.dispay = "none";
                    initialyHideElements();
                } else {
                    element.style.display = "";
                }
            });
        }
    };
}

module.exports = solve;