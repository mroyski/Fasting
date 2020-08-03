// Format end time
let formatEndTime = (endTime) => {
    var endDate = endTime.getDate();
    endDate = ("0" + endDate).slice(-2);
    var endMonth = endTime.getMonth();
    endMonth = ("0" + endMonth).slice(-2);
    var endHours = endTime.getHours();
    endHours = ("0" + endHours).slice(-2);
    var endMinutes = endTime.getMinutes();
    endMinutes = ("0" + endMinutes).slice(-2);
    var endYear = endTime.getFullYear();
    var formattedDate = `${(endMonth)}/${endDate}/${endYear} ${endHours}:${endMinutes}`;
    return formattedDate;
}

let ratio = document.getElementById("Ratio");
var circadian = 16;
var start = document.getElementById("Start");
var startTime = start.value;
var date = new Date(Date.parse(startTime));

var end = document.getElementById("End");
var endTime = new Date(date.setHours(date.getHours() + circadian));
endTime.setMonth(endTime.getMonth() + 1);
end.value = formatEndTime(endTime);

start.addEventListener('click', e => {
    var newStart = start.value;
    var endTime = new Date(Date.parse(newStart));
    endTime.setHours(endTime.getHours() + circadian);
    endTime.setMonth(endTime.getMonth() + 1);
    end.value = formatEndTime(endTime);
});

ratio.addEventListener('click', e => {
    circadian = parseInt(ratio.value);
    var newStart = start.value;
    var endTime = new Date(Date.parse(newStart));
    endTime.setHours(endTime.getHours() + circadian);
    endTime.setMonth(endTime.getMonth() + 1);
    end.value = formatEndTime(endTime);
});