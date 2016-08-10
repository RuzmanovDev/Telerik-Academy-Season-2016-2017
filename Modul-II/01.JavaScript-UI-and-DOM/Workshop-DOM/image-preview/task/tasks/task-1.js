/* globals module */
function solve() {
    return function (selector, items) {
        var container = document.querySelector(selector),
            // create div template
            divTemplate = document.createElement('div'),
            imagePreviewDiv = divTemplate.cloneNode(true),
            imageContainerDiv = divTemplate.cloneNode(true),
            searchInput = document.createElement('input')
                .setAttribute('type', 'text'),
            // .setAttribute('id', 'search-input'),
            // label for searchInput
            labelForSearch = document.createElement('label'),
            headeingTemplate = document.createElement('h2');

        labelForSearch.setAttribute('for', 'search-input').innerHTML = 'Search: ';

        var mainHeading = headeingTemplate.cloneNode(true);
        mainHeading.innerHTML = 'Test';

        setStylesToContainer();
        setDivAttributes();
        setDivStyles();
        appendElementsToDom();

        function setStylesToContainer() {
            container.style.height = '500px';
        }

        function setDivAttributes() {
            imagePreviewDiv.setAttribute('class', 'image-preview');
            imageContainerDiv.setAttribute('class', 'image-container');
        }

        function setDivStyles() {
            // image previuew
            imagePreviewDiv.style.float = 'left';
            imagePreviewDiv.style.width = '500px';
            imagePreviewDiv.style.height = '300';

            //image container
            imageContainerDiv.style.float = 'left';
            imageContainerDiv.style.overflow = 'scroll';
            imageContainerDiv.style.height = '500px';
            imageContainerDiv.style.textAlign = 'center';
            //debug
            imagePreviewDiv.style.boarder = '1px solid black';
            imageContainerDiv.style.boarder = '1px solid black';
        }

        function appendElementsToDom() {
            imageContainerDiv.appendChild(labelForSearch);
            imageContainerDiv.appendChild(searchInput);

            imagePreviewDiv.appendChild(mainHeading);
            container.appendChild(imagePreviewDiv);
            container.appendChild(imageContainerDiv);
        }
    }
}

//module.exports = solve;