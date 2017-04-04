var hoverContent = $(".container-fluid .navbar-inverse .navbar-nav .hover-wrapper .hover-content");

hoverContent.mouseenter(function() {
    var menuParent = hoverContent.parent();

    if(!menuParent.hasClass("active")) {
        menuParent.addClass("submenu-parent");
    }
})

hoverContent.mouseleave(function() {
    var menuParent = hoverContent.parent();

    if(menuParent.hasClass("submenu-parent")) {
       menuParent.removeClass("submenu-parent");
    }
})