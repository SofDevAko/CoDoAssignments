$(document).ready(function(){
    $("#left").on("click", '.btn',function(){
        var fn = $("#firstname").val();
        var ln = $("#lastname").val();
        var dsc = $("#desc").val();
        $("#right").append("<div class='card'><h1>"+fn+" "+ln+"</h1><a>Click here for description!</a></div>")

    $("#right").on("click", ".card", function(){
        if($(this).html() == "<h1>"+fn+" "+ln+"</h1><a>Click here for description!</a>"){
            $(this).html("<p>"+dsc+"</p>")
        }
        else if ($(this).html() == "<p>"+dsc+"</p>"){
            $(this).html("<h1>"+fn+" "+ln+"</h1><a>Click here for description!</a>");
        }
        else console.log("if error");
        });
    });
});