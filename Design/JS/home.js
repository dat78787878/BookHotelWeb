
$('#selection-day').change(
    function(){
        var nhanphong = $('#time-nhan-phong').val()
        var arr_s = nhanphong.split('-')
        var so_ngay = $('#selection-day').val()
        so_ngay = parseInt(so_ngay) + parseInt(arr_s[2])
        var re = arr_s[0] + '-' + arr_s[1] + '-' + so_ngay
        $('#time-tra-phong').val(re)
    }
);

