function solve() {
    return function (fileContentsByName) {
        var $pContentInSidebar = $(".file-preview").find(".file-content");
        console.log($pContentInSidebar);
        var $liTemplate = $("<li />").addClass("item");
        var $items = $(".items");
        $items.on("click", ".file-item", function () {
            var $this = $(this);
            var itemName = $this.find(".item-name").text();
            var content = fileContentsByName[itemName];
            $pContentInSidebar.text(content);
        });

        $items.on("click", ".dir-item", function () {
            var $this = $(this);
            $this.toggleClass("collapsed");
        });

        var $addBtn = $(".add-btn");
        $addBtn.on("click", function () {
            var $input = $addBtn.next();
            $input.toggleClass("visible");
            $(this).toggleClass("visible");
        });

        // delete
        $items.on("click", ".del-btn", function () {
            var $this = $(this);
            var $parentToDelete = $this.parent(".item");

            $parentToDelete.remove();
        });

        $("input").keypress(function (ev) {
            var $this = $(this);
            var enterKeyCode = 13;

            if (ev.keyCode === enterKeyCode) {
                var text = $this.val();
                var indexOfSlash = text.indexOf('/');

                if (indexOfSlash > 0) {
                    var folder = text.substr(0, indexOfSlash);
                    var fileName = text.substr(indexOfSlash + 1);
                    var root;

                    var allFolders = $(".dir-item");
                    allFolders.each(function (i, e) {
                        var element = $(e);
                        var elementText = element.find(".item-name").html();
                        if (elementText === folder) {
                            console.log(element.find(".items"));
                            appendElementsToFolder(element.find(".items"), fileName);
                        }
                    });
                } else {
                    appendElementsToFolder($items, text);

                }

            }
        });
        function appendElementsToFolder(root, fileName) {
            var li = $liTemplate.clone(true);
            li.addClass("file-item");
            var fileName = $("<a />").addClass("item-name").html(fileName);
            var delbtn = $("<a />").addClass("del-btn");

            li.append(fileName);
            li.append(delbtn);
            root.append(li);
        }

    }
}

if (typeof module !== 'undefined') {
    module.exports = solve;
}