



$(function () {
    //$("#Catogary0 ul li ul").hide();
    //$("#Catogary1 ul li ul").hide();
    //$("#Catogary2 ul li ul").hide();
    //$("#Catogary3 ul li ul").hide();


   





    $(".SubCatogaries").hide();
    $("#Spnr").spinner({

        max: 10000,
        min: 500,
        step: 100,
    });
    $("#Slct").selectmenu(
        {
            width: 200,

        }
        );
    $(".LiveChatWrapper").hide();
    $(".FormsLgn").hide();
    $(".FormsRgstr").hide();


    $(".FormsRcr").hide();
  


});














$("#ExpColBtn").click(function () {
    $(".LiveChatWrapper").toggle();
    var val = $("#ExpColBtn").attr("value");
    if (val == "<<") {
        $("#ExpColBtn").attr("value", ">>");
    } else {
        $("#ExpColBtn").attr("value", "<<");
    }
});


$("#Catogary1 ul li a").hover(function () {
    $("#Catogary1 ul li ul").slideDown();
});


$("#Catogary2 ul li a").hover(function () {
    $("#Catogary2 ul li ul").slideDown();
});


$("#Catogary3 ul li a").hover(function () {
    $("#Catogary3 ul li ul").slideDown();
});



//$("#Catogary1 ul li a").mouseleave(function() {
//    $("#Catogary1 ul li ul").slideUp();
//});


//$("#Catogary2 ul li a").mouseleave(function () {
//    $("#Catogary2 ul li ul").slideUp();
//});


//$("#Catogary3 ul li a").mouseleave(function () {
//    $("#Catogary3 ul li ul").slideUp();
//});


$(".SliderThumbnailImg").hover(function () {


    var S = $(this).attr("src");

    $("#SliderMainImg").attr("src", S);
});


$("#Catogary1 ul li ul").hover(function () {

    $("#Catogary1 ul li ul").show();
});
$("#Catogary1 ul li ul").mouseleave(function () {

    $("#Catogary1 ul li ul").slideUp();
});
$("#Catogary2 ul li ul").hover(function () {

    $("#Catogary2 ul li ul").show();
});
$("#Catogary2 ul li ul").mouseleave(function () {

    $("#Catogary2 ul li ul").slideUp();
}); $("#Catogary3 ul li ul").hover(function () {

    $("#Catogary3 ul li ul").show();
});
$("#Catogary3 ul li ul").mouseleave(function () {

    $("#Catogary3 ul li ul").slideUp();
});






///////////////////////////////////////////////////////////////////////




$(document).ready(function () {
    $(window).bind('scroll', function () {
        var navHeight = $(window).height() - 70;
        if ($(window).scrollTop() > navHeight) {
            $('#navbars').addClass('fixed col-lg-12 col-md-12 col-sm-12  col-xs-12');
            //$('nav').addClass('fixed col-lg-12 col-md-12');
            //$('.SecondaryNav').addClass('fixed col-lg-12 col-md-12');
            //$('.LeftPanel').addClass('LeftPanelFix');
            //$('.footer').addClass('fixed');


        }
        else {
            $('#navbars').removeClass('fixed col-lg-12 col-md-12 col-sm-12  col-xs-12');
            //$('nav').removeClass('fixed');
            //$('.SecondaryNav').removeClass('fixed');
            //$('.LeftPanel').removeClass('LeftPanelFix');


        }
    });
});


var a = 1;
b = 70;

$(document).ready(function () {
    $(window).bind('scroll', function () {
        var navHeight = $(window).height() - b;

        $(window).scrollSensitivity = 11;

       if($(window).scrollTop(function() {

          


       }));

        //if ($(window).scrollMaxY(navHeight)) {


        //    $.ajax(
        //           {
        //               url: "/Dashboard/AllMenus?data=" + a,
        //               //url: "/Dashboard/AllMenus",
        //               //method: "get",
        //               //data: MenuObject,

        //               success: function (result) {
        //                   //alert(result);

        //                   $(".MainAreaMenus").html(result);
        //               }
        //           }
        //       )
        //    a++;
        //    b += 70;


        //}
    });
    });










//$(window).on("scroll", function () {
//    var scrollHeight = $(document).height();
//    var scrollPosition = $(window).height() + $(window).scrollTop();
//    if ((scrollHeight - scrollPosition) / scrollHeight === 0) {

//        $('nav').addClass('Normal');
//        $('.LeftPanel').addClass('PanelNormal');

//    }
//    else {
//        $('nav').addClass('fixed');
//        $('.LeftPanel').addClass('LeftPanelFix');


//    }
//});













$(function (event) {
    //event.preventDefault();
    $.ajax(
        {
            url: "/Dashboard/AllMenus?data=" + 9,
            //url: "/Dashboard/AllMenus",
            //method: "get",
            //data: MenuObject,
           
            success: function(result) {
                //alert(result);

                if (result.isEmptyObject) {
                    alert("empty");
                    
                } else {
                    $(".MainAreaMenus").html(result);

                }

               
            }
        }
    )
    

})




//function collision($div1, $div2) {
//    var x1 = $div1.offset().left;
//    var y1 = $div1.offset().top;
//    var h1 = $div1.outerHeight(true);
//    var w1 = $div1.outerWidth(true);
//    var b1 = y1 + h1;
//    var r1 = x1 + w1;
//    var x2 = $div2.offset().left;
//    var y2 = $div2.offset().top;
//    var h2 = $div2.outerHeight(true);
//    var w2 = $div2.outerWidth(true);
//    var b2 = y2 + h2;
//    var r2 = x2 + w2;

//    if (b1 < y2 || y1 > b2 || r1 < x2 || x1 > r2) return false;
//    return true;
//}


//window.setInterval(function () {
//    var aa = collision($('#LP'), $('#F'));
//    if (aa == true) {

//        $('.LeftPanel').removeClass('LeftPanelFix');

//    } else {
//        $('.LeftPanel').addClass('LeftPanelFix');

//    }
//}, 2);







//$(document).ready(function () {
//    $(window).bind('scroll', function () {
//        var navHeight = $(window).height() - 70;
//        if ($(window).scrollTop() > navHeight) {


//            $.ajax({
//                url: "/Dashboard/Index",
//                //method: "get",
//                //data: null,
//                success: function (result) {
//                    alert(result);
//                    //$("#tempdiv").html(result);
//                }
//            })



//        }
//        else {



//        }
//    });
//});















//////////Forms


$("#LogIn").click(function() {

    $(".FormsLgn").slideDown();
    $(".FormsRcr").hide();
    $(".FormsRgstr").hide();

});

$("#Register").click(function () {

    $(".FormsRgstr").slideDown();
    $(".FormsLgn").hide();


    $(".FormsRcr").hide();


});



$("#FgtPssLnk").click(function () {

    $(".FormsLgn").hide();
    $(".FormsRgstr").hide();
    $(".FormsRcr").slideDown();
});


$(".TxtBx").blur(function () {

    if ($(this).val() == "") {

        $(this).attr("class", "TxtBxErr");

    } else {
        $(this).attr("class", "TxtBx");

    }
});



$("#LogInBtn").click(function () {

    var un = $("#UserName").val();
    var p = $("#Password").val();
    if (un != "") {
        $("#UserName").attr("class", "TxtBx");
        if (p != "") {
            $("#Password").attr("class", "TxtBx");
            $(".FormsLgn").slideUp();
        }
        else {
            $("#Password").attr("class", "TxtBxErr");
        }

    }
    else {
        $("#UserName").attr("class", "TxtBxErr");
    }
});


$(".ClsBtn").click(
    function () {

        $(this).parents(".FormsRgstr").hide();
        $(this).parents(".FormsLgn").hide();
        $(this).parents(".FormsRcr").hide();



        //$(this).parents(".Parent").hide();


    });



///////////Forms




















////Spinner


$body = $("body");

$(document).on({
    ajaxStart: function () { $body.addClass("loading"); },
    ajaxStop: function () { $body.removeClass("loading"); }
});

////////////









