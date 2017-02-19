function padding(pad, string) {
    if (typeof string === 'undefined')
        return pad;
    else {
        if ((string + "").length < pad.length) {
            return (pad + string).slice(-pad.length);
        }
        else return string;
    }
}

function GetFormattedDate(date) {
    if (date != undefined && date.length > 0) {
        var formattedDate = new Date(parseInt(date.substr(6)));
        if (formattedDate != undefined) {
            var fDate = formattedDate.getDate();
            var fMonth = formattedDate.getMonth();
            fMonth += 1;  // JavaScript months are 0-11
            var fYear = formattedDate.getFullYear();
            var fHour = (formattedDate.getHours());
            var fMinute = formattedDate.getMinutes();
            var fSecond = formattedDate.getSeconds();

            var ampm = "AM";

            if (fHour >= 12) {
                ampm = "PM";
                fHour = fHour % 12;
            }

            //return fDate + "/" + fMonth + "/" + fYear + " " + padding("00", fHour) + ":" + padding("00", fMinute) + ":" + padding("00", fSecond) + " " + ampm;
            return fDate + "/" + fMonth + "/" + fYear + " " + fHour + ":" + fMinute + ":" + fSecond + " " + ampm;
        }
    }
}

function GetFormattedStatus(status) {
    if (status == true) {
        var span = $("<span>");
        span.addClass("label label-success");
        span.html("Yes");
        return "<span class=\"label label-success\">Yes</span>";
    }
    else {
        var span = $("<span>");
        span.addClass("label label-danger");
        span.html("No");
        return "<span class=\"label label-danger\">No</span>";
    }
}
