$(document).ready(function(){
    $("#click button").click(function(){
        $("#click p").css("font-size" , "140%");
    });
    $("#hide button").click(function(){
        $("#hide p").hide("slow");
    });
    $("#show button").click(function(){
        $("#hide p").show("slow");
    });
    $("#toggle button").click(function(){
        $("#hide p").toggle("slow");
    });
    $("#slidedown button").click(function(){
        $("#slidedown p").slideDown("slow");
    });
    $("#slideup button").click(function(){
        $("#slidedown p").slideUp("fast");
    });
    $("#slidetoggle button").click(function(){
        $("#slidedown p").slideToggle("slow");
    });
    $("#fadein button").click(function(){
        $("#fadein p").fadeIn("slow");
    });
    $("#fadeout button").click(function(){
        $("#fadeout p").fadeOut("slow");
    });
    $("#addclass button").addClass("p");
    $("#before button").click(function(){
        $("#1").before($("#2"));
    });
    $("#after button").click(function(){
        $("#4").after($("#3"));
    });
    $("#append button").click(function(){
        $("#append p").append($("#append h1"));
    });
    $("#html button").click(function(){
        $("#html p").html($("#html button"));
    });
        $(".part#attr").attr("height","400");
    $("#val button").click(function(){
        var text = $(this).text();
        $("#val input").val(text);
    });
    $("#text button").click(function(){
        var text = $(this).text();
        $("#text input").val(text);
    });
    $( "button" ).click(function() {
        var value;
       
        switch ( $( "button" ).index( this ) ) {
            case 0 :
            value = $( "div" ).data( "blah" );
            break;
            case 1 :
            $( "div" ).data( "blah", "hello" );
            value = "Stored!";
            break;
            case 2 :
            $( "div" ).data( "blah", 86 );
            value = "Stored!";
            break;
            case 3 :
            $( "div" ).removeData( "blah" );
            value = "Removed!";
            break;
        }
    
    $( "span" ).text( "" + value );
    });
});