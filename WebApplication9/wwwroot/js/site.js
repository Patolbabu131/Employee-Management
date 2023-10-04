// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets
//$(document).ready(function () {
//    $("button").click(function () {
//         $("h1").toggle();
//    });
//});

//$(document).ready(function () {
//    $("#btn").click(function () {
//        alert("This is an alert message!");
//    });
//});



//$(document).ready(function () {
//    $("h1").hover(function () {
//        $(this).css("color", "green");
//    }, function () {
//        $(this).css("color", "aliceblue");
//    });
//});




//$(function () {
//    var PlaceHolderElement = $('#PlaceHolderHere');
//    $('button[data-toggle="model"]').click(function (event) {
//        debugger;
//        var url = $(this).data('url');
//        $.get(url).done(function (data) {

//            PlaceHolderElement.html(data);
//            PlaceHolderElement.find('model').model('show');

//        })
//    })

//    PlaceHolderElement.on('click', '[data-save="model"]',function(event){
//        var form = $(this).parents('.model').find('form');
//        var actionUrl = form.attr('action');
//        var sendData = form.serialize();
//        $.post(actionUrl, sendData).done(function(data){
//            PlaceHolderElement.find('.model').model('hide');
//        })
//})
//})

//create operation 

function Create_Emp() {

    var emp_name = $("#name").val();
    var emp_gender = $("#gender").val();
    var emp_DOB = $("#DOB").val();
    var emp_DOJ = $("#DOJ").val();
    var emp_Contact_No = $("#Contact_No").val();
    var obj = {
        name: emp_name,
        gender: emp_gender,
        DOB: emp_DOB,
        DOJ: emp_DOJ,
        Contact_No: emp_Contact_No,

    }
    SubmitForm(obj);
}


function SubmitForm(obj) {

    $.ajax({
        type: "post",
        url: "/employee/Create_Emp",
        data: obj,
        success: function (responce) {
            if (responce == "success") {
                $("#partialModal").modal('hide'); 
            }
            alert("Employee Added Successfuly..");
            window.location.reload();

        },
        error: function (err) {
            console.error(err);
        }


    })
}


//function Create_Sal(id) {

//    var sal_Emp_No = id;
//    var sal_base = $("#Basic").val();
//    var sal_da = $("#DA").val();
//    var sal_hra = $("#HRA").val();
//    var sal_fa = $("#FA").val();
//    var sal_me = $("#ME").val();
//    var sal_sm = $("#SM").val();
//    var sal_sy = $("#SY").val();
//    var sal_month = $("#month").val();
//    var sal_year = $("#year").val();

//    var obj = {
//        id: sal_Emp_No,
//        Basic: sal_base,
//        DOB: emp_DOB,
//        DOJ: emp_DOJ,
//        Contact_No: emp_Contact_No,

//    }
//    SubmitForm(obj);
//}

