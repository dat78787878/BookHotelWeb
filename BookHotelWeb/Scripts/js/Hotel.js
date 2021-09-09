$(document).ready(function () {
    initEvent();
});

function initEvent() {
    
}
function loadData() {
    var columns = $('table thead th');
    $.ajax({
        method: 'GET',
        url: 'https://localhost:44300/api/Hotel',
        dataType: 'json',
        async: false,
        contentType: "application/json"
    }).done(function (respone) {
        $.each(respone, function (index, obj) {
            if (obj["IdHotel"] === 1) {
                $('#hotelName').append(obj["HotelName"]);
                $('#hotelAddress').append(obj["HotelAddress"]);
                $('<img/>', { src: '/DataBase/images/hotels/hanoi/' + obj["Image1"] + ".jpg" }).appendTo($('#img-1'));
                $('<img/>', { src: '/DataBase/images/hotels/hanoi/' + obj["Image2"] + ".jpg" }).appendTo($('#img-2'));
                $('<img/>', { src: '/DataBase/images/hotels/hanoi/' + obj["Image3"] + ".jpg" }).appendTo($('#img-3'));
                $('<img/>', { src: '/DataBase/images/hotels/hanoi/' + obj["Image4"] + ".jpg" }).appendTo($('#img-4'));
                $('<img/>', { src: '/DataBase/images/hotels/hanoi/' + obj["Image5"] + ".jpg" }).appendTo($('#img-5'));
                $('<img/>', { src: '/DataBase/images/hotels/hanoi/' + obj["Image6"] + ".jpg" }).appendTo($('#img-6'));
                $('<img/>', { src: '/DataBase/images/hotels/hanoi/' + obj["Image7"] + ".jpg" }).appendTo($('#img-7'));
                $('<img/>', { src: '/DataBase/images/hotels/hanoi/' + obj["Image8"] + ".jpg" }).appendTo($('#img-8'));
                $('#hotelDescription').append(obj["HotelIntroduce"]);
                $('#hotelEvaluate').append(obj["Evaluate"]);
                return;
            }
        });
        //alert("Thành công truy cập serve");
        // đấy hàm lấy dữ lie đây
    }).fail(function (respone) {
        alert("Không lấy được dữ liệu từ api")
    });
    $.ajax({
        method: 'GET',
        url: 'https://localhost:44300/api/Room',
        dataType: 'json',
        async: false,
        contentType: "application/json"

    }).done(function (respone) {
        $.each(respone,function (index,obj) {
            if (obj["IdRoom"] === 1) {
                $('#roomPrice').append(obj["Price"]);
                return;
            }
        })
    }).fail(function (respone) {
        alert("Không lấy được dữ liệu từ api")
    });



}
