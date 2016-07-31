function solve() {
    return function (selector, isCaseSensitive) {
        var element = selector,
            container,
            fragment;


        container = document.querySelector(element);

        fragment = document.createDocumentFragment();
        // div container
        var addControl = document.createElement('div');

        addControl.setAttribute('class', 'add-controls');

        // label
        var label = document.createElement('label');
        label.innerHTML = "Enter text";

        addControl.appendChild(label);

        // input
        var input = document.createElement('input');
        // input.setAttribute('class', '');
        addControl.appendChild(input);


        // search button
        var button = document.createElement('button');
        button.setAttribute('class', 'button');
        button.innerHTML = 'Add';


        //search control
        var searchControls = document.createElement('div');
        searchControls.setAttribute('class', 'search-controls');

        var searchLabel = document.createElement('label');
        searchLabel.innerHTML = 'Search:';
        var searchInput = document.createElement('input');
        searchInput.setAttribute('class', 'search-input');

        searchControls.appendChild(searchLabel);
        searchControls.appendChild(searchInput);

        // result controls

        var resultControl = document.createElement('div');
        resultControl.setAttribute('class', 'result-controls');

        var ul = document.createElement('ul');
        ul.setAttribute('class', 'items-list');
        ul.addEventListener('click', clickEventUl, false);

        resultControl.appendChild(ul);


        // appending elements
        fragment.appendChild(addControl);
        fragment.appendChild(searchControls);
        fragment.appendChild(resultControl);

        container.appendChild(fragment);
        container.setAttribute('class', 'items-control');

        // add event
        button.addEventListener("click", function () {
            var text = input.value;
            var item = createLisItem(text);
            ul.appendChild(item);
        }, false);
        addControl.appendChild(button);

        addEventToSearchTextBox();

        function addEventToSearchTextBox() {
            searchInput.addEventListener("input", searchElementEventHandler, false);
        }

        function searchElementEventHandler() {
            var textValue = this.value;

            toggleItems(textValue,isCaseSensitive);
        }

        function toggleItems(textValue,isCaseSensitive) {
            var itemsList = ul.getElementsByClassName('list-item');

            [].forEach.call(itemsList, function (element) {
                var text = element.getElementsByTagName('strong')[0].innerHTML;
                if (!isCaseSensitive){
                    text = text.toLowerCase();
                    textValue = textValue.toLowerCase();
                }
                if (text.indexOf(textValue) < 0) {
                    element.style.display = 'none';
                } else {
                    element.style.display = '';
                }
            })
        }

        function clickEventUl(ev) {
            var delbtn = ev.target,
                parent;

            if (delbtn.className.indexOf("button") < 0) {
                return;
            }

            parent = delbtn;
            while (parent && parent.className.indexOf("list-item") < 0) {
                parent = parent.parentNode;
            }

            if (!parent) {
                return;
            }

            ul.removeChild(parent);
        }

        function createLisItem(text) {
            var liTemplate = document.createElement("li");
            liTemplate.className = "list-item";

            var buttonTemplate = document.createElement("button");
            buttonTemplate.className = "button";
            buttonTemplate.innerHTML = 'X';

            var li = liTemplate.cloneNode(true);
            var strong = document.createElement('strong');
            strong.innerHTML = text;
            li.appendChild(strong);

            li.appendChild(buttonTemplate.cloneNode(true));

            return li;
        }
    };
}

//module.exports = solve;