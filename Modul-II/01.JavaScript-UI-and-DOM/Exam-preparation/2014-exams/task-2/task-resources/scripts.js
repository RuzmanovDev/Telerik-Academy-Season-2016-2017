/* globals $ */
$.fn.gallery = function (numberOfColumns) {
    var $gallery = $(this),
        cols = +numberOfColumns || 4,
        $gallerList = $gallery.find(".gallery-list"),
        $imgList = $gallerList.find("img");

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
        var imgSources = calculateSources($imageContainer);
        showTabs(imgSources.currentSrc, imgSources.nextSrc, imgSources.prevSrc);
        $gallerList.addClass("blurred");
    });

    $gallery.on('click', '.previous-image', clickOnPrevImage);
    $gallery.on('click', '.next-image', clickOnNextImage);

    function clickOnNextImage() {
        var $this = $(this);
        console.log($this);
        var data = $this.find("img").attr("src");
        var $container = $gallerList.find("img[src$='" + data + "']").parent();
        var imgSources = calculateSources($container);
        showTabs(imgSources);
    }

    function clickOnPrevImage() {
        var $this = $(this);
        console.log($this);
        var data = $this.attr("src");
        var $container = $gallerList.find("img[src*='data']").parent();
        var imgSources = calculateSources($container);
        showTabs(imgSources);
    }

    function calculateSources($current) {
        var clickedSrc = $current.find("img").attr('src');
        var previousSrc = $current.prev().find("img").attr("src");
        if (!previousSrc) {
            previousSrc = "imgs/12.jpg";
        }
        var nextSrc = $current.next().find("img").attr("src");
        if (!nextSrc) {
            nextSrc = "imgs/1.jpg";
        }

        return {
            currentSrc: clickedSrc,
            nextSrc: nextSrc,
            prevSrc: previousSrc
        }
    }

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