var array = [1,"apple", -3, "orange", 0.5];

function numbersOnly(array){
    var newarray = [];
    for (var i = 0; i < array.length; i++){
        if (typeof array[i]==="number"){
            newarray.push(array[i]);
        }
    }
    return newarray;
}