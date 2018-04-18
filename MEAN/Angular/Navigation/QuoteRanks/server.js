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

// define Quote Schema
var QuoteSchema = Schema({
    _author : {type: Schema.Types.ObjectId, ref: 'Author'},
    content : {type: String, required: true, minlength:[3, "Quote should be at least 3 characters"]},
    likeCount : {type : Number, default:0}
},{timestamps: true})

// define Author Schema
var AuthorSchema = Schema({
    name: {type: String, required: true, minlength:[3, "Author Name should be at least 3 characters"]},
    quotes: [{type: Schema.Types.ObjectId, ref:'Quote'}],
},{timestamps: true});

mongoose.model('Quote', QuoteSchema);
mongoose.model('Author', AuthorSchema);

var Quote = mongoose.model('Quote');
var Author = mongoose.model('Author');

const bodyParser = require('body-parser');
mongoose.Promise = global.Promise;

// configure body-parser to read JSON
app.use(bodyParser.json());
app.use(bodyParser.urlencoded({extended : true}))
var path = require('path');
// Setting our Static Folder Directory
app.use(express.static(path.join(__dirname, './static')));
app.use(express.static( __dirname + '/QuoteRanksApp/dist' ));

app.get('/authors', (req, res)=>{  //GET All Authors for homepage
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
app.post('/authors/quotes', (req, res)=>{  //CREATING QUOTE
    var newquote = new Quote(req.body);
    Author.findOne({_id:req.body._author}).exec(function(err, author){
        if(err){
            res.json({status : 'author find one error'})
        }
        else{
            newquote.save(function(err, newquote){
                if(err) {
                    console.log("Returned error", err);
                    res.json({message: "Error", error: err})}
            })
            author.quotes.push(newquote);
            author.save(function(err, author){
                if(err) {
                    console.log("Returned error", err);
                    res.json({message: "Error", error: err})}
            })
            res.json({status : 'success', author : author})
        }
    })
})
app.get('/authors/:id/quotes', (req, res)=>{   //READ Author
    Author.findOne({_id:req.params.id}).populate('quotes').exec(function(err, author){
        if(err){
            res.json({status : 'author find one error'})
        }
        else{
            res.json({status : 'success', author : author})
        }
    })
})
app.get('/authors/quotes/:id', (req, res)=>{   //READ Quote
    Quote.findOne({_id:req.params.id}, function(err, quote){
        if(err){
            res.json({status : 'quote find one error'})
        }
        else{
            res.json({quote : quote})
        }
    })
})
app.put('/authors/quotes/:id', (req, res)=>{   //UPDATE Quote for like counts
    Quote.findOne({_id:req.params.id}, function(err, quote){
        if(err){
            res.json({status : 'quote find one error'})
        }
        else{
            quote.likeCount = req.body.likeCount;
            quote.save();
            Author.findOne({_id:quote._author}).populate('quotes').exec(function(err, author){
                if(err){
                    res.json({status : 'author find one error'})
                }
                else{
                    res.json({status : 'success', author : author})
                }
            })
        }
    })
})
app.delete('/authors/quotes/:id', (req, res)=>{   //DELETE Quote
    let quote = Quote.findById(req.params.id)
    Quote.findByIdAndRemove(req.params.id, function(err, quote){
        if(err){
            res.json({status : 'quote find remove error'})
        }
        else{
            Author.findOne({_id:quote._author}).populate('quotes').exec(function(err, author){
                if(err){
                    res.json({status : 'author find one error'})
                }
                else{
                    res.json({status : 'success', author : author})
                }
            })
        }
    })
})
app.delete('/authors/:id', (req, res)=>{    //DELETE Author
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
app.put('/authors/:id', (req, res)=>{   //UPDATE Author
    Author.findByIdAndUpdate(req.params.id, {$set: req.body} ,function(err, author){
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
app.listen(6789, function () {
    console.log("listening on port 6789");
})