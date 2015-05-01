

// Numeric only control handler
$(document).ready(function(){
    $(".numericOnly").keypress(function (e) {
        
        if (String.fromCharCode(e.keyCode).match(/[^0-9]/g)) return false;
    });
});

