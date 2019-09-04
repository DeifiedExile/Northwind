$(function(){
    //alert("Hello World");
});
$(document).ready(function () {
    
    //var toastAudio = new Audio("~/Media/toast.wav");

    $('#clickMe').on('click', function () {
        $('.toast').toast({ autohide: false }).toast('show');
       // toastAudio.currentTime = 0;
       // toastAudio.play();
    });
    $('.btnCloseToast').on('click', function () {
        $(this).parents().toast('hide');
    })

    $('#birthday').datepicker();

    $('#bloon').draggable();
});

