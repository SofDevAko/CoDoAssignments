
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
var server = app.listen(6789, function () {
    console.log("listening on port 6789");
});
var io = require('socket.io').listen(server);
var messages = [];
io.sockets.on('connection', function (socket) {
    console.log("Client/socket is connected!");
    console.log("Client/socket id is: ", socket.id);
    // all the server socket code goes in here
    
    socket.on("new_message" , function(req){
        var new_message = {
            name: ""+req.msg.name+"",
            id: ""+socket.id+"",
            message: ""+req.msg.message+""
        }
        messages.push(new_message);
        io.emit('message_added', {new_message: new_message})
    });
    socket.on("new_connection" , function(data){
        socket.emit('updated', {messages: messages});
        socket.broadcast.emit( "user_joined" , {data:data});
    });
})
