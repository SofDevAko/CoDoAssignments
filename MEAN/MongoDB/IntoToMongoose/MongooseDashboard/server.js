// Require the Express Module
var express = require('express');
// Create an Express App
var app = express();
// Require the Mongoose Module
var mongoose = require('mongoose');
// Connect to the database
mongoose.connect('mongodb://localhost/mongoose_dashboard'); //mongoose_dashboard is the database for this project
// Let's create our schemas
var OwlSchema = new mongoose.Schema({
    name: { type: String, required: true },
    age: { type: Number, required: true },
    color: { type: String, required: true },
    length: { type: Number, required: true },
    wingspan: { type: Number, required: true },
    created_at: { type: Date, default: Date.now() },
    updated_at: { type: Date, default: Date.now() },
})
mongoose.model('Owl', OwlSchema); // We are setting this Schema in our Models as 'Owl'
var Owl = mongoose.model('Owl') // We are retrieving this Schema from our Models, named 'Owl'
// Use native promises
mongoose.Promise = global.Promise;

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
app.get('/', function (req, res) {
    // This is where we will retrieve the owls from the database and include them in the view page we will be rendering.

    Owl.find({}, null, { sort: { created_at: -1 } }, function (err, owls) { //find (any, no projection, option: sort by created_at by descending, callback)
        res.render('Index', { allowls: owls });
    })
});

app.get('/owls/new', function (req, res) { // Get form page to create a new Owl
    res.render('New');
});

app.post('/newowl', function (req, res) { // Add new Owl  (CREATE)
    var newowl = new Owl(req.body);
    newowl.save(function (err) {
        if (err) {
            res.render('New', { errors: newowl.errors })
        }
        else {
            res.redirect('/');
        }
    });
});

app.get('/owls/show/:id', function (req, res) { // Get specific Owl by ID (READ)
    Owl.findById(req.params.id, function (err, owl) {
        console.log(owl)
        console.log(owl.name)
        console.log(owl._id)
        res.render('View', { owl: owl });
    });
});
app.get('/owls/edit/:id', function (req, res) { // Get specific Owl by ID to edit
    Owl.findById(req.params.id, function (err, owl) {
        res.render('Edit', { owl: owl });
    });
});
app.post('/owls/update/:id', function (req, res) { // Update an Owl  (UPDATE)
    Owl.findByIdAndUpdate(req.params.id,{name:req.body.name, age:req.body.age, color:req.body.color, length:req.body.length, wingspan:req.body.wingspan},function (err) {
        if (err) {
            Owl.findById(req.params.id, function (err, owl) {
                res.render('Edit', { owl: owl });
            });
        }
        else {
            console.log("Updated!")
            res.redirect('/');
        }
    });
});
app.get('/owls/destroy/:id', function (req, res) {   // Delete a specific Owl by ID (DESTROY)
    Owl.findByIdAndRemove(req.params.id, function (err, owl) {
        if (err) {
            Owl.find({}, null, { sort: { created_at: -1 } }, function (err, owls) { });
            res.render('Index', { allowls: owls, errors: err })
        }
        else { res.redirect('/') }
    });
});

// Setting our Server to Listen on Port: 8000
app.listen(6789, function () {
    console.log("listening on port 6789");
})
