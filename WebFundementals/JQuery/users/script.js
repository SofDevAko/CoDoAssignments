$(document).ready(function(){
    $(document.body).on('click', "#submit", function(){
        var fn = ($("input#1").val());
        var ln = ($("input#2").val());
        var em = ($("input#3").val());
        var ph = ($("input#4").val());
        $("tbody").append("<tr><td>"+fn+"</td><td>"+ln+"</td><td>"+em+"</td><td>"+ph+"</td></tr>")
    });
});