// Require the Express Module
var express = require('express');
// Create an Express App
var app = express();
// Require the Mongoose Module
var mongoose = require('mongoose');
// Connect to the database
mongoose.connect('mongodb://localhost/1955API'); //1955API is the database for this project
// define Schema variable
var Schema = mongoose.Schema;
// define User Schema
var UserSchema = new mongoose.Schema({
    name: {type: String, required:true, minlength:2 }});
const bodyParser = require('body-parser');
mongoose.Promise = global.Promise;
mongoose.model('User', UserSchema);
var User = mongoose.model('User');
// configure body-parser to read JSON
app.use(bodyParser.json());
var path = require('path');
// Setting our Static Folder Directory
app.use(express.static(path.join(__dirname, './static')));
app.get('/', function(req, res){
    User.find({}, function(err, users){
        if(err){
           console.log("Returned error", err);
            // respond with JSON
           res.json({message: "Error", error: err})
        }
        else {
            // respond with JSON
           res.json({message: "Success", data: users})
        }
     })
})    
app.get('/new/:name', function(req, res){
    var newuser = new User({name : req.params.name});
    newuser.save(function(err, user){
        if(err){
           console.log("Returned error", err);
            // respond with JSON
           res.json({message: "Error", error: err})
        }
        else {
            // respond with JSON
           res.redirect('/');
        }
     })
})    
app.get('/:name', function(req, res){
    User.findOne({name:req.params.name}, function(err, user){
        if(err){
           console.log("Returned error", err);
            // respond with JSON
           res.json({message: "Error", error: err})
        }
        else {
            // respond with JSON
            res.json({message: "Success", data: user})
        }
     })
})    
app.get('/remove/:name', function(req, res){
    User.remove({name : req.params.name}, function(err, users){
        if(err){
           console.log("Returned error", err);
            // respond with JSON
           res.json({message: "Error", error: err})
        }
        else {
            // respond with JSON
            res.redirect('/');
        }
     })
})    
app.listen(6789, function () {
    console.log("listening on port 6789");
})