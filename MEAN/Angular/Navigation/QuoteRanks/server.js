// Require the Express Module
var express = require('express');
// Create an Express App
var app = express();
// Require the Mongoose Module
var mongoose = require('mongoose');
// Connect to the database
mongoose.connect('mongodb://localhost/quote_ranks'); //quote_ranks is the database for this project
// define Schema variable
var Schema = mongoose.Schema;
// define Author Schema
var AuthorSchema = Schema({
    name: {type: String, minlength:[3]},
    quotes: [{type: Schema.Types.ObjectId, ref:'Quote'}],
},{timestamps: true});
var QuoteSchema = Schema({
    _quoter : {type: Schema.Types.ObjectId, ref: 'Author'},
    content : {type: String},
    likeCount : {type : Number, default:0}
},{timestamps: true})
mongoose.model('Author', AuthorSchema);
mongoose.model('Quote', QuoteSchema);
var Author = mongoose.model('Author');
var Quote = mongoose.model('Quote');
const bodyParser = require('body-parser');
mongoose.Promise = global.Promise;

// configure body-parser to read JSON
app.use(bodyParser.json());
app.use(bodyParser.urlencoded({extended : true}))
var path = require('path');
// Setting our Static Folder Directory
app.use(express.static(path.join(__dirname, './static')));
app.use(express.static( __dirname + '/QuoteRanksApp/dist' ));

app.get('/authors', (req, res)=>{
    Author.find({}, function(err, authors){
        if(err){
           console.log("Returned error", err);
            // respond with JSON
           res.json({message: "Error", error: err})
        }
        else {
            // respond with JSON
           res.json({message: "Success", data: authors})
        }
     })
})
app.post('/authors', (req, res)=>{   //CREATING AUTHOR
    var newauthor = new Author(req.body);
    newauthor.save(function(err, newauthor){
        if(err){
           console.log("Returned error", err);
            // respond with JSON
           res.json({message: "Error", error: err})
        }
        else {
            // respond with JSON
           res.json({newauthor:newauthor});
        }
     })
})    
app.post('/authors/:id/quotes', (req, res)=>{  //CREATING QUOTE
    var newquote = new Quote(req.body);
    Author.findById(req.params.id).populate('quotes').exec(function(err, author){
        if(err){
            res.json({status : 'author findbyid error'})
        }
        else{
            author.quotes.push(newquote);
            author.save()
            console.log(author)
            res.json({status : 'success', author : author})
        }
    })
})
app.get('/authors/:id/quotes', (req, res)=>{
    Author.findOne({_id:req.params.id}).populate('quotes').exec(function(err, author){
        if(err){
            res.json({status : 'error'})
        }
        else{
            console.log(author)
            res.json({status : 'success', author : author})
        }
    })
})
app.get('/authors/:id', (req, res)=>{
    Author.findById(req.params.id).populate('quotes').exec(function(err, author){
        if(err){
           console.log("Returned error", err);
            // respond with JSON
           res.json({message: "Error", error: err})
        }
        else {
            // respond with JSON
            res.json({author: author})
        }
     })
})    
app.delete('/authors/:id', (req, res)=>{
    Author.findByIdAndRemove(req.params.id, function(err, author){
        if(err){
           console.log("Returned error", err);
            // respond with JSON
           res.json({message: "Error", error: err})
        }
        else {
            Author.find({}, function(err, authors){
                if(err){
                   console.log("Returned error", err);
                    // respond with JSON
                   res.json({message: "Error", error: err})
                }
                else {
                    // respond with JSON
                   res.json({message: "Success", data: authors})
                }
             })
        }
     })
})    
app.put('/authors/:id', (req, res)=>{
    Author.findByIdAndUpdate(req.params.id, {$set: {title:req.body.title, description: req.body.description, completed:req.body.completed, updated_at:Date.now()}} ,function(err, upauthor){
        if(err){
           console.log("Returned error", err);
            // respond with JSON
           res.json({message: "Error", error: err})
        }
        else {
            // respond with JSON
            res.json({upauthor: upauthor})
        }
     })
})    
app.listen(6789, function () {
    console.log("listening on port 6789");
})