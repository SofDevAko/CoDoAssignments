// Require the Express Module
var express = require('express');
// Create an Express App
var app = express();
// Require the Mongoose Module
var mongoose = require('mongoose');
// Connect to the database
mongoose.connect('mongodb://localhost/restful_task_api'); //restful_task_api is the database for this project
// define Schema variable
var Schema = mongoose.Schema;
// define Task Schema
var TaskSchema = new mongoose.Schema({
    title: {type: String},
    description : {type: String, default:""},
    completed: {type:Boolean, default:false},
    created_at: {type:Date, default:Date.now()},
    updated_at: {type:Date, default:Date.now()}
});
mongoose.model('Task', TaskSchema);
var Task = mongoose.model('Task');
const bodyParser = require('body-parser');
mongoose.Promise = global.Promise;

// configure body-parser to read JSON
app.use(bodyParser.json());
var path = require('path');
// Setting our Static Folder Directory
app.use(express.static(path.join(__dirname, './static')));
app.use(express.static( __dirname + '/HelloAngular/dist' ));

app.get('/tasks', (req, res)=>{
    Task.find({}, function(err, tasks){
        if(err){
           console.log("Returned error", err);
            // respond with JSON
           res.json({message: "Error", error: err})
        }
        else {
            // respond with JSON
           res.json({message: "Success", data: tasks})
        }
     })
})    
app.post('/tasks', (req, res)=>{
    var newtask = new Task({title: ""+req.body.title+"", description: ""+req.body.description+"", completed: req.body.completed, created_at:Date.now(), updated_at:Date.now()});
    console.log(newtask)
    newtask.save(function(err, task){
        if(err){
           console.log("Returned error", err);
            // respond with JSON
           res.json({message: "Error", error: err})
        }
        else {
            // respond with JSON
           res.json({newtask:newtask});
        }
     })
})    
app.get('/tasks/:id', (req, res)=>{
    Task.findById(req.params.id, function(err, task){
        if(err){
           console.log("Returned error", err);
            // respond with JSON
           res.json({message: "Error", error: err})
        }
        else {
            // respond with JSON
            res.json({message: "Success", data: task})
        }
     })
})    
app.delete('/tasks/:id', (req, res)=>{
    Task.findByIdAndRemove(req.params.id, function(err, task){
        if(err){
           console.log("Returned error", err);
            // respond with JSON
           res.json({message: "Error", error: err})
        }
        else {
            // respond with JSON
            res.json({message: "Success", task: task})
        }
     })
})    
app.put('/tasks/:id', (req, res)=>{
    Task.findByIdAndUpdate(req.params.id, {$set: {title:req.body.title, description: req.body.description, completed:req.body.completed, updated_at:Date.now()}} ,function(err, tasks){
        if(err){
           console.log("Returned error", err);
            // respond with JSON
           res.json({message: "Error", error: err})
        }
        else {
            // respond with JSON
            res.json({message: "Success"})
        }
     })
})    
app.listen(6789, function () {
    console.log("listening on port 6789");
})