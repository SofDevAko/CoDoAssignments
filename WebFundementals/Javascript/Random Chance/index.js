function randomChance(money){
    var win = 0;
    while(money>0){
        console.log(money);
        if (Math.floor((Math.random()*100)+1)==1){
           money += Math.floor((Math.random()*51)+50);
          win += 1;
        }
        money-=1;
    }
    console.log(win, "times you won!");
    return money;
    
}
randomChance(100);