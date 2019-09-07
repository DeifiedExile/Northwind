$(function(){
    //alert("Hello World");
});
$(document).ready(function () {
    console.log('here');
    
    //toastAudio.src = "~/media/toast.wave";

    $('.clickMe').on('click', function () {
        console.log($(this).data('sale'));
        $('.toast').toast({ autohide: false }).toast('show');
        if ($(this).data('sale') === 1) {
            $('#discountCode').html('daily2019');
            $('#tstTitle').html('Your Daily Discount Code');
        }
        else if ($(this).data('sale') === 10) {
            $('#discountCode').html('dec2019');
            $('#tstTitle').html('Your Decade Discount Code');
        }
        else if ($(this).data('sale') === "6e6f74206120726f626f74") {
            $('#discountCode').html('gorn2019');
            $('#tstTitle').html('Your Consumables Discount Code');
        }
        //toastAudio.currentTime = 0;
        //toastAudio.play();
    });
    $('.btnCloseToast').on('click', function () {
        $(this).parents().toast('hide');
    })
    $(document).on('keyup', function (e) {
        if (e.which === 27) {
            $('.toast').toast('hide');
        }
    })

    $('#birthday').datepicker();

    $('#bloon').draggable();
});

