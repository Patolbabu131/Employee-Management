//$(document).ready(function () {
//    ShowEmployeeData();
//});

//function ShowEmployeeData() {
//    $.ajax({
//        url: 'Ajax/EmployeeList',
//        method: 'GET',
//        success: function (result, status, xhr) {
//            var object='';
//            $.each(result, function (index, item) {
//                object += '<tr>';
//                object += '<td>'+item.emp_No+'</td>';
//                object += '<td>'+item.name+'</td>';
//                object += '<td>'+item.gender+'</td>';
//                object += '<td>'+item.dob+'</td>';
//                object += '<td>'+item.doj+'</td>';
//                object += '<td>' + item.contact_No + '</td>';
//                object += '<td> <a class="btn btn-primory" id='+item.emp_No+' onclick="Details(this.id)">Show</a></td>';
//                object += '</tr>';
//            });
//            $('#table_data').html(object);
//        }
//    });
//};

