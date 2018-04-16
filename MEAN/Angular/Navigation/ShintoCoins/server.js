// Require the Express Module
var express = require('express');
// Create an Express App
var app = express();
// Require the Mongoose Module
var mongoose = require('mongoose');
// Connect to the database
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
app.use(express.static( __dirname + '/ShintoCoins/dist' ));

app.listen(6789, function () {
    console.log("listening on port 6789");
})