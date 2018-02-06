$(document).ready(function(){
    for(i=1; i<152; i++){
       $('#left').append("<img id='"+i+"' src='http://pokeapi.co/media/img/"+i+".png/'/>")     
    };
    $("#left").on("click", "img", function(){
        var id = $(this).attr('id');
        var res = $.get("https://pokeapi.co/api/v2/pokemon/"+id+"/", function(res){
            var name = res.name;
            var sl = res.types.length; 
            var ul = "<ul>";
                for(var i=0; i < sl; i++){
                    ul += "<li>"+res.types[i].type.name+"</li>";
                }
                ul += "</ul>";
            var height = res.height;
            var weight = res. weight;
           $("#right p").html("<h1>"+name+"</h1><br><img id='" +id+ "' src='http://pokeapi.co/media/img/"+id+".png/'><br><h3>Types:</h3>"+ul+"<br><h3>Height: </h3><p>"+height+"</p><h3>Weight: </h3><p>"+weight+"");

        },"json");
    });
});
