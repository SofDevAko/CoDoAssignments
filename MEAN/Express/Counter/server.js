
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

app.get("/", function (request, response) {
    var times;
    if (request.session.times) {
        times = request.session.times;
        times += 1;
        request.session.times = times;
        console.log("Increased times")
    }
    else {
        times = 1;
        request.session.times = times;
        console.log("Created times")

    }
    response.render('index', { session: times });
});
app.get("/double", function (request, response) {
    times = request.session.times;
    times += 1;
    request.session.times = times;
    console.log("Double times")
    response.redirect("/")
});
app.get("/reset", function (request, response) {
    request.session.destroy();
    console.log("Reset times")
    response.redirect("/")
});

app.listen(6789, function () {
    console.log("listening on port 6789");
});


