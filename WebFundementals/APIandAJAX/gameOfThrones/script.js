$(document).ready(function(){
    $(document.body).on("click","img", function(){
        var name = $(this).attr("id");
        if (name == "stark"){
            var url = 362;
        }
        else if(name == "targaryen"){
            var url = 378;
        }
        else if(name == "lannister"){
            var url = 229;
        }
        else if(name == "baratheon"){
            var url = 17;
        }
        $.get("https://anapioficeandfire.com/api/houses/"+url+"", 'json', function(result){
            var housename = result.name;
            var words = result.words;
            var title = "Titles: "
            for (i=0; i < result.titles.length;i++){
                title += result.titles[i];
                if (i < result.titles.length-1){
                    title += ", ";
                }
            }
            $("#result").html("Name: "+housename+"<br>Words: "+words+"<br><br>"+title+""); 
            console.log(result);
        });
        
    });
});
