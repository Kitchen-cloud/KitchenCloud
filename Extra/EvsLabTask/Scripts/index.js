$(function () {

    $(".lblM").hide();

   
});


$(".EditLnk").click(function (event) {
    event.preventDefault();
    $.ajax({
        url: "/Home/EditStudentLnk?data=" + $(this).attr("id"),
        method: "POST",
        success: function (result) {

            $("#EditFormSec").html(result);
        }
    });
});

$(".DeleteLnk").click(function (event) {

    event.preventDefault();
    $.ajax({
        url: "/Home/DeleteLnk?data=" + $(this).attr("id"),
        method: "get",
        success: function (result) {
            $("#CnfrmDialog").html(result);
        }
    });

});


$(".TxtBxM").focus(function () {


    $(".lblM").show();

});


$(".TxtBxM").blur(function () {


    $(".lblM").hide();

});



////Spinner


$body = $("body");

$(document).on({
    ajaxStart: function () { $body.addClass("loading"); },
    ajaxStop: function () { $body.removeClass("loading"); }
});

////////////