﻿$(function(){
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

    //$('#birthDate').datepicker();

    //$('#bloon').draggable();

    //$('.form-check-input').each(function () {
    //    $(this).prop('checked', false);
    //});

    //$('.blnCheck').on('change', function () {
        
    //    $('#img' + this.id).css('visibility', 'visible');

    //    $(this).is(':checked') ? $('#img' + this.id).removeClass().addClass('animated slideInUp') : $('#img' + this.id).addClass('animated slideOutUp');
    //});

    //var animEffect;
    //var selector = Math.floor((Math.random() * 5) + 1);
    //switch (selector) {
    //    case 1: animEffect = 'heartBeat';
    //        break;
    //    case 2: animEffect = 'wobble';
    //        break;
    //    case 3: animEffect = 'flip';
    //        break;
    //    case 4: animEffect = 'lightSpeedIn';
    //        break;
    //    case 5: animEffect = 'jackInTheBox';
    //        break;
    //}

    //$('#msgBDay').addClass(animEffect);

    //$('#checkAll').on('change', function () {
    //    $('.blnCheck').each(function () {
    //        $(this).click();
    //    });
    //});

    //$('#bDaySubmit').on('click', function () {
        
    //    if (!$('.blnCheck:checked').length > 0) {
    //        $('#toastBDay').toast({ autohide: false }).toast('show');
    //    }
    //});

});

