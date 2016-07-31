/* globals module */
function solve() {
    return function (selector, items) {
        var element = selector;

        var container = document.querySelector(element);
        container.style.height = '500px';
        console.log(container);

        var liTemplate = document.createElement('li');
        liTemplate.className = 'list-item';
        var h4Template = document.createElement('h4');
        var imageTemplate = document.createElement('img');
        imageTemplate.className = 'smallImages';

        var leftContainer = document.createElement("div");
        leftContainer.setAttribute('class', 'left-container');
        var heading = document.createElement('h1');
        heading.innerHTML = '';
        var projector = document.createElement('div');
        projector.className = 'projector';
        var projectorImage = document.createElement('img');
        projectorImage.setAttribute('src','');

        projectorImage.style.width='300px';
        projector.appendChild(projectorImage);
        leftContainer.appendChild(heading);
        leftContainer.appendChild(projector);
        setStylesLeftContainer();

        var rightContainer = document.createElement('div');
        rightContainer.setAttribute('class', 'right-container');
        //creating label
        var label = document.createElement('label');
        label.style.display = 'block';
        label.style.textAlign = 'center';

        label.innerHTML = 'Filter';

        var searchInput = document.createElement('input');


        rightContainer.appendChild(label);
        rightContainer.appendChild(searchInput);

        var imageList = document.createElement('ul');
        imageList.style.listStyleType = 'none';
        addItemsToList(imageList);

        rightContainer.appendChild(imageList);
        setStylesRightContainer();


        container.appendChild(leftContainer);
        container.appendChild(rightContainer);


        // adding events
        addEventToTheUlNavigation();

        function setStylesRightContainer() {
            rightContainer.style.float = 'left';
            rightContainer.style.overflow = 'scroll';
            rightContainer.style.height = '500px';
            rightContainer.style.textAlign = 'center'
        }

        function setStylesLeftContainer() {
            leftContainer.style.width = '600px';
            leftContainer.style.float = 'left';

        }

        function addItemsToList(imageList) {

            items.map(
                function (currentElement) {
                    var heading = h4Template.cloneNode(true);
                    heading.innerHTML = currentElement.title;
                    heading.className= 'list-headings';
                    heading.style.textAlign = 'center';

                    var li = liTemplate.cloneNode(true);
                    var image = imageTemplate.cloneNode(true);
                    image.setAttribute('src', currentElement.url);
                    image.style.width = '200px';
                    image.style.borderRadius = '10px';
                    image.style.margin = '0 auto';
                    li.appendChild(heading);
                    li.appendChild(image);

                    imageList.appendChild(li);
                }
            )
        }

        function addEventToTheUlNavigation() {
            imageList.addEventListener('click',
                function (ev) {
                    var link = ev.target,
                        parent;

                    // if (link.className.indexOf('list-item') < 0) {
                    //     return;
                    // }
                    console.log(link);

                    parent = link;
                    while (parent && parent.className.indexOf("list-item") < 0) {
                        parent = parent.parentNode;
                    }
                    projectorImage.src = link.src;
                    console.log(link.innerHTML);
                    heading.innerHTML = link.innerHTML;
                })
        }
    };
}

module.exports = solve;