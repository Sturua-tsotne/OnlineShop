


$(document).ready(function () {

   
    function openNav() {
        document.getElementById("mySidenav").style.width = "250px";
        document.getElementById("main").style.marginLeft = "250px";
        document.body.style.backgroundColor = "rgba(0,0,0,0.4)";
    }

    function closeNav() {
        document.getElementById("mySidenav").style.width = "0";
        document.getElementById("main").style.marginLeft = "0";
        document.body.style.backgroundColor = "white";
    }
    //addimg

    function readURL(input) {
        if (input.files && input.files[0]) {
            var reader = new FileReader();

            reader.onload = function (e) {
                $('#blah').attr('src', e.target.result);
            }

            reader.readAsDataURL(input.files[0]);
        }
    }

    $("#imgInp input").change(function () {
        readURL(this);
    });


    //Search////////////////////////////////////////////////////////////////////////////////////////////////////////

    //$('#search').keyup(function () {
    //    var search = $(this);

    //    $.ajax({
    //        url: '/Home/Search',
    //        type: "Post",
    //        date: { 'search': search.val() },        
    //        success: function (respons) {
    //            $('#suggestions').remove();
    //            var htmlElement = "<ul Id='suggestions'" >
    //                S.each(respons, function (id, value) {
    //                    htmlElement += "<li>" + value + "</li>";
    //                });
    //            htmlElement += "</ul>"
    //            search.after(htmlElement);


    //        }
    //    })


    //})






});
