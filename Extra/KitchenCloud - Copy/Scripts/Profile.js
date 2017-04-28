$(function() {
    
    $(".ProfileStatsSubMenu").hide();
    $(".AccountStats").hide();
    $("#NewMenuM").hide();

    $("#NewMenuCatogory,#NewMenuCatogoryType, #NewMenuLocationCountry,#NewMenuLocationCity").selectmenu(
        {
            width: 200,

        }
        );


    $('.MenuTitle').slideUp();

    var a = 0;

    $("#AddTagTxtBx").keyup(function() {


        if (this.value.indexOf(",") !== -1) {
            if (a < 5) {
                var Tag = "<span class='MenuTags'>" + $("#AddTagTxtBx").val() + "</span>";
                $("#AddedTags").append(Tag);
                $("#AddTagTxtBx").val("");
                a++;
            } else {
                $("#AddTagTxtBx").addClass("TxtBxErr");
            }
        }
    });







});












$('.MenuImg').hover(function () {

      $(this).prev(".MenuTitle").slideDown();
    


});
$('.MenuImg').mouseleave(function () {

      $('.MenuTitle').slideUp();
    


});



//var a = 1;


//$(document).ready(function () {
//    $(window).bind('scroll', function () {
//        var navHeight = $(window).height() - 70;

//        if ($(window).scrollTop() < navHeight) {

//if (a > 20) {
//    a = 1;

//}
//            $.ajax(
//                         {

//                             url: "/Users/UserMenu?data=" + a,
//                             method: "get",

//                             success: function (result) {
//                                 $(".ProfileMenus").html(result);
//                             }
//                         }
//                     );


//        }
       
//        });

//});



var a = 1;
$body = $("body");

$("#PrfileMenuShow").click(function () {
    $.ajax(
           {
                             url: "/Sellers/SellerMenu?data=" + a,
                             method: "get",
                        

                             success: function (result) {


                                 ///want to append at last 

                                 $("#MenuArea").append(result);
                             }
                         }
                     );
        a++;

    }
       
        );




















$("").dialog();

$("#SettingsUpDownBtn").click(function () {

    $(".ProfileStatsSubMenu").toggle();

});

$("#StatTabs").tabs(
{

    heightStyle: "auto",

});
$("#ShowStat").click(function () {
    $(".AccountStats").show();
});

$(".ClsBtn").click(
    function () {

        $(this).parents(".AccountStats").hide();
    });


$("#NewMenuTabs").tabs(
{
    heightStyle: "auto",
    widthStyle:"auto",

});


$("#NewMenu,#CreateNewMenu").click(function () {
    $("#NewMenuM").show();
});









$(".ClsBtn").click(
    function () {

        $(this).parents(".NewMenu").hide();
    });















////Spinner


//$body = $("body");

//$(document).on({
//    ajaxStart: function () { $body.addClass("loading"); },
//    ajaxStop: function () { $body.removeClass("loading"); }
//});

//////////////


























//Reference: 
//http://www.onextrapixel.com/2012/12/10/how-to-create-a-custom-file-input-with-jquery-css3-and-php/
; (function ($) {

    // Browser supports HTML5 multiple file?
    var multipleSupport = typeof $('<input/>')[0].multiple !== 'undefined',
        isIE = /msie/i.test(navigator.userAgent);

    $.fn.customFile = function () {

        return this.each(function () {

            var $file = $(this).addClass('custom-file-upload-hidden'), // the original file input
                $wrap = $('<div class="file-upload-wrapper">'),
                $input = $('<input type="text" class="file-upload-input" />'),
                // Button that will be used in non-IE browsers
                $button = $('<button type="button" class="file-upload-button">Select a File</button>'),
                // Hack for IE
                $label = $('<label class="file-upload-button" for="' + $file[0].id + '">Select a File</label>');

            // Hide by shifting to the left so we
            // can still trigger events
            $file.css({
                position: 'absolute',
                left: '-9999px'
            });

            $wrap.insertAfter($file)
              .append($file, $input, (isIE ? $label : $button));

            // Prevent focus
            $file.attr('tabIndex', -1);
            $button.attr('tabIndex', -1);

            $button.click(function () {
                $file.focus().click(); // Open dialog
            });

            $file.change(function () {

                var files = [], fileArr, filename;

                // If multiple is supported then extract
                // all filenames from the file array
                if (multipleSupport) {
                    fileArr = $file[0].files;
                    for (var i = 0, len = fileArr.length; i < len; i++) {
                        files.push(fileArr[i].name);
                    }
                    filename = files.join(', ');

                    // If not supported then just take the value
                    // and remove the path to just show the filename
                } else {
                    filename = $file.val().split('\\').pop();
                }

                $input.val(filename) // Set the value
		          .attr('title', filename) // Show filename in title tootlip
		          .focus(); // Regain focus

            });

            $input.on({
                blur: function () { $file.trigger('blur'); },
                keydown: function (e) {
                    if (e.which === 13) { // Enter
                        if (!isIE) { $file.trigger('click'); }
                    } else if (e.which === 8 || e.which === 46) { // Backspace & Del
                        // On some browsers the value is read-only
                        // with this trick we remove the old input and add
                        // a clean clone with all the original events attached
                        $file.replaceWith($file = $file.clone(true));
                        $file.trigger('change');
                        $input.val('');
                    } else if (e.which === 9) { // TAB
                        return;
                    } else { // All other keys
                        return false;
                    }
                }
            });

        });

    };

    // Old browser fallback
    if (!multipleSupport) {
        $(document).on('change', 'input.customfile', function () {

            var $this = $(this),
                // Create a unique ID so we
                // can attach the label to the input
                uniqId = 'customfile_' + (new Date()).getTime(),
                $wrap = $this.parent(),

                // Filter empty input
                $inputs = $wrap.siblings().find('.file-upload-input')
                  .filter(function () { return !this.value }),

                $file = $('<input type="file" id="' + uniqId + '" name="' + $this.attr('name') + '"/>');

            // 1ms timeout so it runs after all other events
            // that modify the value have triggered
            setTimeout(function () {
                // Add a new input
                if ($this.val()) {
                    // Check for empty fields to prevent
                    // creating new inputs when changing files
                    if (!$inputs.length) {
                        $wrap.after($file);
                        $file.customFile();
                    }
                    // Remove and reorganize inputs
                } else {
                    $inputs.parent().remove();
                    // Move the input so it's always last on the list
                    $wrap.appendTo($wrap.parent());
                    $wrap.find('input').focus();
                }
            }, 1);

        });
    }

}(jQuery));

$('input[type=file]').customFile();












//////Spinner


//$body = $("body");

//$(document).on({
//    ajaxStart: function () { $body.addClass("loading"); },
//    ajaxStop: function () { $body.removeClass("loading"); }
//});

//////////////

