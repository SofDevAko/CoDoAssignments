$(document).ready(function() {
    $('button').click(function() {
        var city = $("#text").val();
        var url = "http://api.openweathermap.org/data/2.5/weather?q="+city+"&&appid=56d10a44ab4e1cdb09fbdb92ba9d8c4b";
 
        $.get(url, function(res) {
            var tempk = res.main.temp;
            var tempf = (9/5)*(tempk-273.15)+32;

            $("#result").html("<h1>"+city+"</h1><p>Temperature is: "+tempf+" Degrees Fahrenheit</p>")
        }, 'json');
       

        return false;
    });
});
