
var express = require("express");
var session = require("express-session");
var path = require('path');
var app = express();
var bodyParser = require("body-parser");

app.use(bodyParser.urlencoded({ extended: true }));
app.use(session({ secret: 'Mellon' }));
app.use(express.static(path.join(__dirname, "./static")));

app.set('views', __dirname + '/views');
app.set('view engine', 'ejs');

app.get("/", function (req, res) {
    res.render('index');
});
app.post("/submit", function (req, res) {
    var form = {
        Name: req.body.Name,
        Location: req.body.Location,
        Language: req.body.Language,
        Comment: req.body.Comment,
        Name: req.body.Name,
    };
    req.session.form = form;
    res.redirect('/result');
});
app.get("/result", function (req, res) {
    form = req.session.form;
    res.render('result', { form: form });
});
var server = app.listen(6789, function () {
    console.log("listening on port 6789");
});
var io = require('socket.io').listen(server);
io.sockets.on('connection', function (socket) {
    console.log("Client/socket is connected!");
    console.log("Client/socket id is: ", socket.id);
    // all the server socket code goes in here
    socket.on( "posting_form", function (data){
        console.log( 'Someone posted a form!');
        console.log(data)
        var str = "You have passed the following info: ";
        for(var i=0; i < data.length; i++)
        {
            str += "'"+data[i].name+"'";
            str += ": ";
            str += "'"+data[i].value+"'";
            str += ", ";
        }
        socket.emit( 'server_response', {response:  str});
    })
    socket.on("random_number" , function(){
        var number = Math.floor(Math.random()*1000)+1;
        console.log(number);
        socket.emit('random_response',{response: number})
    });
})
