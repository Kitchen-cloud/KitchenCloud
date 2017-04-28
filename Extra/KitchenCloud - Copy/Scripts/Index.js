$(function () {


    //$("#Spnr").spinner({max: 1000,min: 100,});

    //$("#Slct").selectmenu();
    //$(window).bind('scroll', function () {
    //    var navHeight = $(window).height() - 70;
    //    if ($(window).scrollTop() > navHeight) {
    //        $('#navbars').addClass('fixed col-lg-12 col-md-12 col-sm-12  col-xs-12');


    //    }
    //    else {
    //        $('#navbars').removeClass('fixed col-lg-12 col-md-12 col-sm-12  col-xs-12');



    //    }
    //});


    $.ajax(
        {
            url: "/Dashboard/AllMenus?data=" + 9,
            success: function (result) {
                if (result.isEmptyObject) {
                    alert("empty");

                } else {
                    $(".MainAreaMenus").html(result);

                }
            }
        }
    );

});




