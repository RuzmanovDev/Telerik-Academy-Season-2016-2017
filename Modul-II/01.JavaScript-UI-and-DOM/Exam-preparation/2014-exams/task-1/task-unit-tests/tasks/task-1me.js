/* globals module */
function solve() {

    function clear(node) {
        while (node.firstChild) {
            node.removeChild(node.firstChild);
        }
    }

    return function createImagesPreviewer(selector, items) {
        var element = document.querySelector(selector);

        var divTemplae = document.createElement("div");
        var imgTemplate = document.createElement("img");
        var h2Template = document.createElement("h2");
        var h4Template = document.createElement("h4");
        h4Template.style.marginBottom = 0;
        var liTemplate = document.createElement("li");
        liTemplate.className = "list-items";
        liTemplate.style.margin = "10px";

        // image preview
        var imagePreviewDiv = divTemplae.cloneNode(true);

        var titleForZoomedImage = h2Template.cloneNode(true);

        titleForZoomedImage.innerHTML = items[0].title;
        titleForZoomedImage.style.textAlign = "center";

        imagePreviewDiv.className = "image-preview";
        var zoomedImage = imgTemplate.cloneNode(true);
        zoomedImage.style.borderRadius = 10;
        setStylesToZoomedImage();

        imagePreviewDiv.appendChild(titleForZoomedImage);
        imagePreviewDiv.appendChild(zoomedImage);

        // image container
        var imageContainerDiv = divTemplae.cloneNode(true);
        imageContainerDiv.className = "image-container";

        var labelForSearch = document.createElement("label");
        labelForSearch.innerHTML = "Filter";
        labelForSearch.style.display = "block";
        labelForSearch.style.textAlign = "center";
        imageContainerDiv.appendChild(labelForSearch);

        // image items
        var imageList = document.createElement("ul");
        imageList.style.listStyleType = "none";
        imageList.setAttribute("id", "image-list");
        addContentToTheList();

        var searchInput = document.createElement("input");
        searchInput.style.width = "100px";
        imageContainerDiv.appendChild(searchInput);
        imageContainerDiv.appendChild(imageList);

        applyDivStyles();
        attachEventsOnImageList();

        function applyDivStyles() {
            setImagePreviewDivStyles();
            setImageContainerDivStyles();
        }

        function setImagePreviewDivStyles() {
            imagePreviewDiv.style.float = "left";
            imagePreviewDiv.style.width = 800;
            imagePreviewDiv.style.height = 300;
            imagePreviewDiv.style.display = "inline-block";
            imagePreviewDiv.style.margin = "40px";


        }

        function setImageContainerDivStyles() {
            imageContainerDiv.style.float = "left";
            imageContainerDiv.style.display = "inline-block";
            imageContainerDiv.style.width = 300;
            imageContainerDiv.style.height = "500px";
            imageContainerDiv.style.textAlign = "center";
            imageContainerDiv.style.overflowY = "scroll";
            imageContainerDiv.style.paddingRight = "20px";
        }

        function setStylesToZoomedImage() {
            zoomedImage.style.width = "300px";
            zoomedImage.setAttribute("src", items[0].url);
            zoomedImage.style.borderRadius = "10px";
            zoomedImage.style.padding = 10;
        }

        function addContentToTheList() {

            items.forEach(function (element) {
                var li = liTemplate.cloneNode(true),
                    image = imgTemplate.cloneNode(true),
                    header = h4Template.cloneNode(true);

                header.innerHTML = element.title;
                header.style.textAlign = "center";

                image.setAttribute("src", element.url);
                image.style.borderRadius = "5px";
                image.style.width = "100px";
                li.appendChild(header);
                li.appendChild(image);

                imageList.appendChild(li);
            })
        }

        function attachEventsOnImageList() {
            imageContainerDiv.addEventListener("click", function (ev) {
                var target = ev.target;

                if (target.src) {
                    var heading = target.previousSibling;
                    changeZoomedContent(target.src, heading.innerHTML);
                }
            })
        }

        function changeZoomedContent(src, title) {
            zoomedImage.src = src;
            titleForZoomedImage.innerHTML = title;
        }

        imageContainerDiv.addEventListener('mouseover', function (ev) {
            var target = ev.target;
            console.log(target.className);
            if (target.className.indexOf('image-container') < 0) {
                return;
            }
            target.style.background = 'black';
        });

        imageContainerDiv.addEventListener('mouseout', function (ev) {
            var target = ev.target;

            if (target.className.indexOf('image-container') < 0) {
                return;
            }

            target.style.background = '';
        });

        searchInput.addEventListener("input", function () {
            var text = this.value;

            //var liItems = document.getElementsByClassName("list-items");
            var heading = document.getElementsByTagName("h4");
            [].forEach.call(heading, function (element) {
                var elementText = element.innerHTML;
                var liParent = element.parentNode;
                if (elementText.toLowerCase().indexOf(text.toLowerCase()) < 0) {
                    liParent.style.display = "none";
                } else {
                    liParent.style.display = "";
                }
            });
        });

        clear(root);
        element.appendChild(imagePreviewDiv);
        element.appendChild(imageContainerDiv);
    }
}

module.exports = solve;