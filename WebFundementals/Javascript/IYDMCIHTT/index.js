var hour = 8;
var minute = 50;
var period = 'AM';
var min = '';
var per = '';
if (minute < 30 && period =='AM'){
    min = 'just after';
    per = 'in the morning.';
}
else if(minute < 30 && period =='PM'){
    min = 'just after';
    per = 'in the evening.';
}
else if(minute >= 30 && period =='PM'){
    min = 'almost';
    hour += 1;
    per = 'in the evening.'
}
else if(minute >= 30 && period =='AM'){
    min = 'almost';
    hour += 1;
    per = 'in the morning.'
}
console.log("It's", min, hour, per)