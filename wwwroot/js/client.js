$(function(){
    //alert("Hello World");
});
$(document).ready(function () {
    
    var toastAudio = new Audio();
    toastAudio.src = "/Media/toast.wav";

    $('.showDiscount').on('click', function () {
        
        $('.toast').toast({ autohide: false }).toast('show');
        $('#discountCode').html($(this).data('sale'));
        $('#tstTitle').html($(this).data('title'));
       
        toastAudio.currentTime = 0;
        toastAudio.play();
    });

    $('.btnCloseToast').on('click', function () {
        $(this).parents().toast('hide');
    });

    $(document).on('keyup', function (e) {
        if (e.which === 27) {
            $('.toast').toast('hide');
        }
    });


    //var ctx = $('#myChart').getContext('2d');
    //var myChart = new myChart(ctx,
    //    {
    //        type: 'bar',
    //        dara: {
    //            labels: []
    //        }
    //    })


});


