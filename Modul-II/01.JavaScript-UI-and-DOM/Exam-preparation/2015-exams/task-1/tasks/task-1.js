function solve() {
    return function (selector, isCaseSensitive) {
        var root = document.querySelector(selector),
            divTemplate = document.createElement("div"),
            labeltemplate = document.createElement("label"),
            inputTemplate = document.createElement("input"),
            liTemplate = document.createElement("li"),
            btntemplate = document.createElement("button");

        root.setAttribute("class", "items-control");
        btntemplate.setAttribute("class", "button");
        liTemplate.setAttribute("class", "list-item");

        creteAddControls();
        createSearchControls();
        createResultControls();

        function creteAddControls() {
            var addControlsDiv = divTemplate.cloneNode(true),
                addLabel = labeltemplate.cloneNode(true),
                addInput = inputTemplate.cloneNode(true);

            addControlsDiv.setAttribute("class", "add-controls");
            addLabel.innerHTML = "Enter text";
            addInput.style.display = "inline-block";

            var addBtn = btntemplate.cloneNode(true);
            addBtn.addEventListener("click", function () {
                var content = addInput.value;
                createListItem(content);
                addInput.value = "";
            });
            addBtn.innerHTML = "Add";
            addControlsDiv.appendChild(addLabel);
            addControlsDiv.appendChild(addInput);
            addControlsDiv.appendChild(addBtn);

            root.appendChild(addControlsDiv);
        }

        function createSearchControls() {
            var searchDiv = divTemplate.cloneNode(true),
                searchLabel = labeltemplate.cloneNode(true),
                searchInput = inputTemplate.cloneNode(true);

            searchDiv.setAttribute("class", "search-controls");
            searchLabel.innerHTML = "Search:";
            searchInput.addEventListener("input", searchEventHandler);
            searchDiv.appendChild(searchLabel);
            searchDiv.appendChild(searchInput);

            root.appendChild(searchDiv);
        }

        function createResultControls() {
            var resultDiv = divTemplate.cloneNode(true),
                ul = document.createElement("ul");

            resultDiv.setAttribute("class", "result-controls");
            ul.style.listStyleType = "none";
            ul.setAttribute("class", "items-list");
            ul.addEventListener("click", deleteListHandler);
            resultDiv.appendChild(ul);

            root.appendChild(resultDiv);
        }

        function createListItem(content) {
            var ul = document.getElementsByClassName("items-list")[0],
                li = liTemplate.cloneNode(true),
                delBtn = btntemplate.cloneNode(true),
                strong = document.createElement('strong');

            delBtn.innerHTML = "X";
            strong.innerHTML = content;
            li.appendChild(strong);
            li.appendChild(delBtn);
            ul.appendChild(li);
        }

        function deleteListHandler(ev) {
            var target = ev.target,
             listToBeRemoved = ev.target.parentNode;

            if (target.className.indexOf("button") >= 0) {
                var targetParent = target.parentNode;
                while (targetParent.className.indexOf("items-list") < 0) {
                    targetParent = targetParent.parentNode;
                }
                targetParent.removeChild(listToBeRemoved);
            }
        }

        function searchEventHandler() {
            var content = this.value;
            toggleItems(content, isCaseSensitive);
        }

        function toggleItems(textValue, isCaseSensitive) {
            var itemsList = document.getElementsByClassName('list-item');

            [].forEach.call(itemsList, function (element) {
                var text = element.getElementsByTagName('strong')[0].innerHTML;
                if (!isCaseSensitive) {
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
    };
}

module.exports = solve;