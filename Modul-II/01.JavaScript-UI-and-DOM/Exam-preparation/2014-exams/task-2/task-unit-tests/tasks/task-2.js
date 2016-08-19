/* globals $ */
function solve() {
    $.fn.gallery = function (numberOfColumns) {
        var $gallery = $(this),
            cols = +numberOfColumns || 4,
            $gallerList = $gallery.find(".gallery-list");


        $gallery.addClass("gallery");

        // hide selected
        var $catImagesTabView = $gallery.find(".selected").hide();
        $catImagesTabView.find(".current-image").on("click", function () {
            $catImagesTabView.hide();
            $disabledBg.hide();
            $gallerList.removeClass("blurred");

        });

        generateGrid();
        var $disabledBg = $("<div />").addClass("disabled-background");

        $gallery.append($disabledBg);
        $disabledBg.hide();

        //attach event
        $gallery.on("click", ".image-container", function () {
            var $imageContainer = $(this);
            console.log($imageContainer);
            var clickedSrc = $imageContainer.find("img").attr('src');
            var previousSrc = $imageContainer.prev().find("img").attr("src");
            if (!previousSrc) {
                previousSrc = "imgs/12.jpg";
            }
            var nextSrc = $imageContainer.next().find("img").attr("src");
            if (!nextSrc) {
                nextSrc = "imgs/1.jpg";
            }
            // console.log("clicked-image src: " + clickedSrc);
            // console.log("prev-image src: " + previousSrc);
            // console.log("next-image src: " + nextSrc);
            showTabs(clickedSrc, nextSrc, previousSrc);
            $gallerList.addClass("blurred");

        });

        function generateGrid() {
            var $imageContainer = $gallery.find(".image-container");

            $imageContainer.each(function (index) {
                if (index != 0 && index % cols === 0) {
                    $(this).addClass("clearfix");
                }
            })

        }

        function showTabs(clickedSrc, nextSrc, previousSrc) {
            $catImagesTabView.find(".previous-image").find("img").attr('src', previousSrc);
            $catImagesTabView.find(".current-image").find("img").attr('src', clickedSrc);
            $catImagesTabView.find(".next-image").find("img").attr('src', nextSrc);

            $catImagesTabView.show();

            $disabledBg.show();
        }
    };
}
module.exports = solve;