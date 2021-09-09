function getDateDiff(time1, time2) {

    var str1 = time1.split('-');
    var str2 = time2.split('-');
    //                yyyy   , mm       , dd
    var t1 = new Date(str1[0], str1[1], str1[2]);
    var t2 = new Date(str2[0], str2[1], str2[2]);

    var diffMS = t1 - t2;
    if (diffMS < 0) {
        alert("ban nhap nhay khong hop le");
        return 0;
    } else {
        var diffS = (((diffMS / 1000) / 60) / 60) / 24;
        return diffS;
    }


}
$(document).ready(function () {
   
    $('#btnSubmit').on('click', function () {
        var result1 = $('#date1').val();
        //    alert(result1);
        var check1 = 0;
        if (result1 === '') {
            check1 = 1;
        }
        var result2 = $('#date2').val();
        var check2 = 0;
        if (result2 === '') {
            check2 = 1;
        }
        if (check1 === 1 || check2 === 1) {
            alert('bạn chưa nhập ngày mời bạn nhập lại');
        }
        else {
            var diffS = getDateDiff(result2, result1);
            if (diffS === 0) {
                alert('ngày trả phòng không hợp lệ')
            }
            else {
                $('#day').html(diffS + ' đêm');

                var person = $('#person').val();
                var child = $('#child').val();
                var people = parseInt(person) + parseInt(child);
                $('#people').html(people + ' người');
                var amountR = $('#amountR').val();

                var price = $('#price1').text();
                $('#price').html(parseInt(price) * diffS);
                var p = $('#price').text();
               
                $('#vat').html(price * diffS / 10);
                var v = $('#vat').text();
                var total = parseInt(p) + parseInt(v);
         
                document.getElementById('total').value = total; 
                $('#deploy').html(price * diffS / 10 );
                $('#btnSubmit1').removeClass('an');
                $('#btnSubmit1').addClass('hien');
            }   
        }
    });
});
