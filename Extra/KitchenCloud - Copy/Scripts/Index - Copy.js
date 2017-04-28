
$(function() {
    $("#SubCatogary1").hide();
    $("#SubCatogary2").hide();
    $("#SubCatogary3").hide();
});



$("#Catogary1").mouseenter(function() {
    $("#SubCatogary1").slideDown();
});

$("#Catogary2").mouseenter(function () {
    $("#SubCatogary2").slideDown();
});

$("#Catogary3").mouseenter(function () {
    $("#SubCatogary3").slideDown();
});

$("#Catogary1").mouseleave(function() {
    $("#SubCatogary1").slideUp();
});

$("#Catogary2").mouseleave(function () {
    $("#SubCatogary2").slideUp();
});

$("#Catogary3").mouseleave(function () {
    $("#SubCatogary3").slideUp();
});



