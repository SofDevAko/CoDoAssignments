// Require the Express Module
var express = require('express');
// Create an Express App
var app = express();
// Require the Mongoose Module
var mongoose = require('mongoose');
// Connect to the database
mongoose.connect('mongodb://localhost/quoting_dojo'); //Quoting_dojo is the database for this project
// Let's create our schemas
var QuoteSchema = new mongoose.Schema({
    name: { type:String, required: true },
    quote: { type:String, required: true },
    created_at: { type:Date, default: Date.now() },
    updated_at: { type:Date, default: Date.now() },
   })
   mongoose.model('Quote', QuoteSchema); // We are setting this Schema in our Models as 'Quote'
   var Quote = mongoose.model('Quote') // We are retrieving this Schema from our Models, named 'Quote'
   
// Require body-parser (to receive post data from clients)
var bodyParser = require('body-parser');
// Integrate body-parser with our App
app.use(bodyParser.urlencoded({ extended: true }));
// Require path
var path = require('path');
// Setting our Static Folder Directory
app.use(express.static(path.join(__dirname, './static')));
// Setting our Views Folder Directory
app.set('views', path.join(__dirname, './views'));
// Setting our View Engine set to EJS
app.set('view engine', 'ejs');
// Routes
// Root Request
app.get('/', function(req, res) {
    res.render('Index');
});
app.get('/quotes', function(req, res) {
    // This is where we will retrieve the quotes from the database and include them in the view page we will be rendering.
    
    Quote.find({}, null, {sort: {created_at:  -1}}, function(err, quotes){ //find (any, no projection, option: sort by created_at by descending), callback)
    res.render('Quotes', {allquotes: quotes});
    })
});
// Add Quote Request 
app.post('/submit', function(req, res) {
    var newquote = new Quote({name: req.body.name, quote:req.body.quote});
    newquote.save(function(err){
        if(err){
            res.render('Index', {errors: newquote.errors})
        }
        else {
            res.redirect('/quotes');
        }
    });
})
// Setting our Server to Listen on Port: 8000
app.listen(6789, function() {
    console.log("listening on port 6789");
})
