$.fn.tabs = function () {
    var $container = $(this);

    $container.addClass("tabs-container");
    hideContent();

    $container.on("click", ".tab-item", function () {
        var $tabItem = $(this);
        hideContent();
        console.log($tabItem.parent(".current"));
        $container.find(".current").removeClass("current");
        $tabItem.find(".tab-item-content").show();
        $tabItem.addClass("current");
    });

    function hideContent() {
        $container.find(".tab-item-content").hide();
    }
};