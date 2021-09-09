$(document).ready(function () {
    alert("Hello");
    loadData();
});
function loadData(){
    // //Lấy dữ liệu
    // // $('table tbody').empty();
    // var columns = $('table thead th');
    // $.ajax({
    //     type: "GET",
    //     url: "https://localhost:44300/api/Hotel",
    //     data: null,
    //     async: false,
    //     contentType: "application/json"
    // }).done(function(respone){
    //     $.each(respone, function (index, obj) { 
    //          var tr = $(`<tr></tr>`);
    //          $.each(columns, function (index, th){ 
    //             var td =  $(`<td><div><span>Hello<span></div></td>`);
    //             $(tr).append(td);
    //             $(tr).append(td);
    //          });
    //          $('table tbody').append(tr);
    //          $('table tbody').append(tr);
             
    //     });
    // }).fail(function(respone){s
    //     alert("Lỗi lấy dữ liệu từ server")
    // });
   // $('table tbody').empty();
    var columns = $('table thead th');
    $.ajax({
        method: 'GET',
        url: 'https://localhost:44300/api/Hotel',
        dataType : 'jsonp',
        async: false,
        contentType: "application/json"
    }).done(function (respone) {
        console.log(respone);
        
        // $.each(respone, function (index, obj) { 

        //     // var tr = $(`<tr></tr>`);
        //     // $.each(columns, function (index, th) {
        //     //     var td = $(`<td><div><span>Hello<span></div></td>`);
        //     //     $(tr).append(td);

        //     // });
        //     // $('table tbody').append(tr);
        
        // });
        alert("Thành công truy cập serve");
        // đấy hàm lấy dữ lie đây
    }).fail(function (respone){
         alert("Không lấy được dữ liệu từ api")
    })
}
