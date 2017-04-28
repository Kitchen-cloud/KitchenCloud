$(function () {

    


});











$("#FoodCategory").change(function () {


    $.ajax({
        url: "/Sellers/FoodSubCategoryList/" + $("#FoodCategory").select("option:selected").val(),
        success: function (result) {

            $("#FoodSubCategory").html(result);
        }


    });


});






$("#CountryList").change(function () {


    $.ajax({
        url: "/Sellers/CitiesList/" + $("#CountryList").select("option:selected").val(),
        success: function (result) {


            $("#CityList").html(result);

        }


    });

});











var a = 0;

$("#AddTagTxtBx").keyup(function () {

    if (this.value.indexOf(",") !== -1)
    {
        if (a < 5)
        {
            var Tag = "<span class='badge' style='background-color:steelblue;padding:10px; margin-      top:10px;margin-right:10px;'> <span class='glyphicon glyphicon-tag'></span>" + $("#AddTagTxtBx").val() + "</span> ";


            $.ajax(
                {
                    url: "/Sellers/AddTag/?Tag=" + $("#AddTagTxtBx").val()
                });



            $("#AddedTags").append(Tag);
            $("#AddTagTxtBx").val("");


            a++;
        }
        else
        {
            $("#AddTagTxtBx").addClass("form-control-feedback");
        }
    }
});

