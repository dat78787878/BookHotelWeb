$(document).ready(function () {
    //$('#dataTable tbody').on('click', 'tr', function () {
    //    $(this).siblings('.bg-selected-row').removeClass("bg-selected-row");
    //    $(this).addClass("bg-selected-row");
    //});
    $('#dataTable').DataTable({
       
    });

    //$("#dataTable tbody tr").click(function () {

    //    $(this).siblings(".bg-selected-row").removeClass("bg-selected-row")
    //    $(this).addClass("bg-selected-row")

    //    $('iconEdit').click(function () {

    //    })
    //})
    $('#iconEdit').click(function () {
        $('#dialog').removeClass("h-hide-dialog")


    })
    $('.h-close').click(function () {
        $('#dialog').hide()
    })
    $('.btn-save').click(function () {
        $('#dialog').hide()
    })
    $('.btn-cancel').click(function () {
        $('#dialog').hide()
    })

    $('#deleteHotel').click(function () {
        $('.dialog-confirm').removeClass('hide-dialog')
    })
    
    $('#agreeDelete').click(function () {
        $('.dialog-confirm').addClass('hide-dialog')
    })

    


    
});


