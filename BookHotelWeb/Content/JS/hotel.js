$("#hotelDetail").ready(function () {
    loadData();
    initEvent();
    //$("#roomPrice").text($("select-room").val())
    //$("#bookNow").attr("href", "/Payment/Index/" + value)

});
function initEvent() {
    // chọn select room 

    $('#selectRoom option[value=val2]').attr('selected', 'selected');
    $("#selectRoom").click(function (){
        // click button đặt phòng trong form detail hotel
        $("#bookNow").attr("href", "/Payment/AddItem/" + $("#selectRoom").val())
    })

    //$("#bookListHotel").click(function () {
    //    //$("#bookListHotel").attr("href", "/DetailHotel/Index/1")
    //})

    $("#btnBook").click(function (){
        var date = new Date($('#dateCheckin').val());
        var day = date.getDate();
        var month = date.getMonth() + 1;
        var year = date.getFullYear();
        var date1 = new Date($('#dateCheckout').val());
        var day1 = date1.getDate();
        var month1 = date1.getMonth() + 1;
        var year1 = date1.getFullYear();
        var dateCheckin = day + "/" + month + "/" + year;
        var dateCheckout = day1 + "/" + month1 + "/" + year1

        $("#dateCheckin").append(dateCheckin);
        $("#dateCheckin").append(dateCheckout);
    })


    //$("#dateCheckin").text(dateCheckin);
    //$("#dateCheckout").text(dateCheckout);
}
$("#payment").ready(function () {
    //loadData();
    //initEvent();
    //alert(getDateCheckin + "-" + getDateCheckout)
    $("#dateCheckin").text(dateCheckin);
    $("#dateCheckout").text(dateCheckout);
});
function getDateCheckin() {
    return dateCheckin;
}
function getDateCheckout() {
    return dateCheckout;
}

function loadData() {
    $.ajax({
        url: 'https://localhost:44300/DetailHotel/Index/97',
        type: 'GET',
        success: function (data) {
            $('#dateCheckin').html($(data).find('#dateCheckin').html());
        }
    })
}
