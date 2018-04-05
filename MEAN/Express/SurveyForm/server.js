
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

app.get("/", function(req,res){
    res.render('index');
});
app.post("/submit", function(req,res){
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
app.get("/result", function(req,res){
    form = req.session.form;
    res.render('result', {form : form});
});
app.listen(6789, function () {
    console.log("listening on port 6789");
});