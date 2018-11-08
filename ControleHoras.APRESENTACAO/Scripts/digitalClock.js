function digitalClock(startDateTime) { // YYYY (M-1) D H m s ms (start time and date from DB)

    //http://www.alessioatzeni.com/blog/css3-digital-clock-with-jquery/

    var startStamp = startDateTime.getTime();

    var newDate = new Date();
    var newStamp = newDate.getTime();

    var timer;

    newDate = new Date();
    newStamp = newDate.getTime();
    var diff = Math.round((newStamp - startStamp) / 1000);
    var d = Math.floor(diff / (24 * 60 * 60)); /* though I hope she won't be working for consecutive days :) */
    diff = diff - (d * 24 * 60 * 60);
    var h = Math.floor(diff / (60 * 60));
    diff = diff - (h * 60 * 60);
    var m = Math.floor(diff / (60));
    //diff = diff - (m * 60);
    //var s = diff;

    $('#Date').html((d < 10 ? "0" : "") + d); //dias
    $("#hours").html((h < 10 ? "0" : "") + h); //horas
    $("#min").html((m < 10 ? "0" : "") + m); // minutos
    //$("#sec").html((s < 10 ? "0" : "") + s); //segundos

    setInterval(digitalClock, 60000);
}