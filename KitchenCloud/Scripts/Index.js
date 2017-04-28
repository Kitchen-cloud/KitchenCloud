$(function () {


    //$("#Spnr").spinner({max: 1000,min: 100,});

    //$("#Slct").selectRecipe();
    //$(window).bind('scroll', function () {
    //    var navHeight = $(window).height() - 70;
    //    if ($(window).scrollTop() > navHeight) {
    //        $('#navbars').addClass('fixed col-lg-12 col-md-12 col-sm-12  col-xs-12');


    //    }
    //    else {
    //        $('#navbars').removeClass('fixed col-lg-12 col-md-12 col-sm-12  col-xs-12');



    //    }
    //});




    $("#feedbackbtn").click(function () {
        //feedbackmodal
        alert("Yes");
    });




    $("#CountryList").change(function () {


        $.ajax({
            url: "/Dashboard/CitiesList/" + $("#CountryList").select("option:selected").val(),
            success: function (result) {


                $("#CityList").html(result);

            }


        });

    });






    //$.ajax(
    //    {
    //        url: "/Dashboard/AllRecipes?data=" + 9,
    //        success: function (result) {
    //            if (result.isEmptyObject) {
    //                alert("empty");

    //            } else {
    //                $(".MainAreaRecipes").html(result);

    //            }
    //        }
    //    }
    //);


    $("#SidePanelCityList").change(function () {
        Search();
    });


    $("#Spnr").spinner({
        min: 100, step: 100, max: 10000,
        change: function () {
            alert("Yesss");
        }
    });



    $("#hpgslr").bjqs(
        {
            width: 955,
            height: 150,
            animtype: 'fade',
            animspeed: 9000,
            showcontrols: false,
            showmarkers: false,
            usecaptions: false,

        }
    );
    $(".notifycls").click(function () {
        $(this).parent("#notify").hide();
    });

});




$(".InboxMsg").click(function () {

    alert($(this).data("chatwithid"));
    $.ajax({
        url: "/Chat/ChatWith/" + $(this).data("chatwithid"),
        method: "Get",
        success: function (result) {
            alert(result);
            // $("#inbox", $("#MessageAppMain").contents()).append("No Messages");
            $("#MessageAppMain").html(result);
        }


    });
});








function FixPanel() {

    $("#sdepnl").attr("style", "position:fixed;width: 280px;box - shadow: 0px 0px 10px 0px lightgray;")

}

function UnFixPanel() {
    $("#sdepnl").attr("style", "width: 280px;box - shadow: 0px 0px 10px 0px lightgray;")

}






function Search() {

    alert("Yes")
    var byName = "";
    var byPrice = "";
    var byLocation = $("#SidePanelCityList").select("option:selected").val();
    var byOnlineSellers = "";
    var byMealFor = "";
    if ($("#SrchByNm").val() !== "") {
        byName = $("#SrchByNm").val();
    }
    if ($("#Spnr").val() !== "") {
        byPrice = $("#Spnr").val();
    }
    if ($("#Ols").val() !== null) {
        byOnlineSellers = true;
    }
    if ($(".personfor").val() != null) {
        byMealFor = $(".personfor").val();
    }

    var searchKeys = {
        "ByName": byName,
        "ByPrice": byPrice,
        "ByLocation": byLocation,
        "ByOnlineSellers": byOnlineSellers,
        "ByMealFor": byMealFor
    }
    GO(searchKeys);
}

function GO(searchKeys) {
    if (searchKeys !== null) {
        $.ajax({
            url: "/Dashboard/Search",
            data: searchKeys,
            method: "POST",
            success: function (reslut) {
                $(".MainAreaRecipes").html(reslut);
            }
        });
    }
}

//$body = $("body");

//$(document).on({
//    ajaxStart: function () { $body.addClass("loading"); },
//    ajaxStop: function () { $body.removeClass("loading"); }
//});

