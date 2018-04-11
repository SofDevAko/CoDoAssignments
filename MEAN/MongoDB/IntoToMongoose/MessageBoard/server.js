// Require the Express Module
var express = require('express');
// Create an Express App
var app = express();
// Require the Mongoose Module
var mongoose = require('mongoose');
// Connect to the database
mongoose.connect('mongodb://localhost/message_board'); //message_board is the database for this project
// define Schema variable
var Schema = mongoose.Schema;
// define Post Schema
var PostSchema = new mongoose.Schema({
name: {type: String, required:true, minlength:4 },
text: {type: String, required: true, minlength:4 }, 
comments: [{type: Schema.Types.ObjectId, ref: 'Comment'}]
}, {timestamps: true });
// define Comment Schema
var CommentSchema = new mongoose.Schema({
commenter: {type: String, required:true, minlength:4 },
_post: {type: Schema.Types.ObjectId, ref: 'Post'},
text: {type: String, required: true, minlength:4  }
}, {timestamps: true });
// set our models by passing them their respective Schemas
mongoose.model('Post', PostSchema);
mongoose.model('Comment', CommentSchema);
// store our models in variables
var Post = mongoose.model('Post');
var Comment = mongoose.model('Comment');
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
app.get('/', function (req, res) {
    Post.find({}).populate('comments').exec(function(err,posts){
        res.render('Index', { posts: posts });
    })
});
app.post('/newpost', function (req, res) { // Add new post  (CREATE)
    var newpost = new Post(req.body);
    newpost.save(function (err) {
        if (err) {
            Post.find({}).populate('comments').exec(function(err,posts){
                res.render('Index', {errors: newpost.errors , posts: posts });
            })
        }
        else {
            res.redirect('/');
        }
    });
});
// route for getting a particular post and comments
app.get('/posts/:id', function (req, res){
 Post.findOne({_id: req.params.id})
 .populate('comments')
 .exec(function(err, post) {
      res.render('post', {post: post});
        });
});
// route for creating one comment with the parent post id
app.post('/posts/:id', function (req, res){
  Post.findOne({_id: req.params.id}, function(err, post){
         var comment = new Comment(req.body);
         comment._post = post._id;
         post.comments.push(comment);
         comment.save(function(err){
                 post.save(function(err){
                       if(err) { console.log('Error'); } 
                       else { res.redirect('/'); }
                 });
         });
   });
 });
// Setting our Server to Listen on Port: 6789
app.listen(6789, function () {
    console.log("listening on port 6789");
})