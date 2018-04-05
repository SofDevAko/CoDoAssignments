
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
let count = 0;
io.sockets.on('connection', function (socket) {
    console.log("Client/socket is connected!");
    console.log("Client/socket id is: ", socket.id);
    // all the server socket code goes in here
    socket.on( "update_click", function (){
        console.log(count)
        count += 1;
        io.emit( 'server_response', {response:  count});
    })
    socket.on("reset_click" , function(){
        count = 0;
        io.emit('server_response',{response: count})
    });
    socket.on("login" , function(){
        socket.emit('server_response',{response: count})
    });
})
