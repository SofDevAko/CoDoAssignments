var daysUntilMyBirthday = 60;
while (daysUntilMyBirthday>=0){
    if (daysUntilMyBirthday>30){
        console.log(daysUntilMyBirthday,'days to my birthday! Boooring!');
    }
    else if(daysUntilMyBirthday<=30 && daysUntilMyBirthday>5){
        console.log('My birthday is after',daysUntilMyBirthday,'days later!');
    }
    else if(daysUntilMyBirthday<=5 && daysUntilMyBirthday>0){
        console.log(daysUntilMyBirthday,'left to my birthday!!');
    }
    else{
        console.log("YAAAY It'S MY BIRTHDAAAAAAY!!!");
    }
    daysUntilMyBirthday--;
}