// Require the Express Module
var express = require('express');
// Require the Session Module
var session = require('express-session');
// Create an Express App
var app = express();
// Require the Mongoose Module
var mongoose = require('mongoose');
// Require the Bcrypt
var bcrypt = require('bcrypt')
// Connect to the database
mongoose.connect('mongodb://localhost/login_registration'); //login_registration is the database for this project
// define Schema variable
var Schema = mongoose.Schema;
// define User Schema
var UserSchema = new mongoose.Schema({
    email: {
        type: String, unique: true, validate: [{
            validator: function (mail_address) {
                var re = /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
                return re.test(String(mail_address).toLowerCase());
            }, message: "{ VALUE } is not a valid email address!"
        }],
        required: [true, "Email is required!"]
    },
    first_name: { type: String, required: [true, "First Name is required!"] },
    last_name: { type: String, required: [true, "Last Name is required!"] },
    password: {
        type: String,
        required: true,
        minlength: 8,
        maxlength: 32,
        validate: {
            validator: function (value) {
                return /^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[$@$!%*?&])[A-Za-z\d$@$!%*?&]{8,32}/.test(value);
            },
            message: "You must have at least 1 number, uppercase and special character in the password!"
        }
    },
    confirm_password: {
        type: String,
        required: true,
        minlength: 8,
        maxlength: 32,
        validate: {
            validator: function (value) {
                if (value === this.password) {
                    return true;
                }
                else {
                    return false;
                }
            },
            message: "Your confirm password must match password!"
        }
    },
    birthday: {
        type: Date, validate: function (date) {
            return date < Date.now();
        }, message: "You should be born in past!"
    },
}, { timestamps: true });

UserSchema.pre('save', function (next) {
    var newuser = this;
    // Email uniqueness checker
    mongoose.models["User"].findOne({ email: newuser.email }, function (err, results) {
        if (err) {
            return next(err);
        } else if (results) { //there was a result found, so the email address exists
            user.invalidate("email", "email must be unique");
            return next(new Error("email must be unique"));
        } else {
            // Password cryptor
            // hash the password
            const saltRounds = 10;
            var salt = bcrypt.genSaltSync(saltRounds);
            var hash = bcrypt.hashSync(newuser.password, saltRounds);
            newuser.password = hash;
            next();
            }
    });
});

mongoose.model('User', UserSchema);
var User = mongoose.model('User');
app.use(session({ secret: 'Mellon' }));
const bodyParser = require('body-parser');
// mongoose.Promise = global.Promise;
// configure body-parser to read JSON
app.use(bodyParser.urlencoded({ extended: true }));
var path = require('path');
// Setting our Static Folder Directory
app.use(express.static(path.join(__dirname, './static')));
app.set('view engine', 'ejs')

app.get('/', (req, res) => {
    res.render('Index')
});

app.post('/registeruser', (req, res) => {
    var newuser = new User({ first_name: "" + req.body.first_name + "", last_name: "" + req.body.last_name + "", email: req.body.email, birthday: req.body.birthday, password:req.body.password, confirm_password:req.body.confirm_password});
    newuser.save(function (err, newuser) {
        if (err) {
            console.log("Returned error", err);
            // respond with JSON
            res.render("Index",{ message: "Error" })
        }
        else {
            // respond with JSON
            res.render("Index",{ message: "Success" });
        }
    })
});

app.post('/loginuser', (req,res)=>{
    User.findOne({ email: req.body.email }, function (err, user) {
        if(err){console.log(err)}
        else{
            bcrypt.compare(req.body.password, user.password )
            .then(result => {
                if(result == true)
                {
                    req.session.userid = user._id;
                    res.locals.session_user = user;
                    console.log(req.session.userid);
                    res.redirect('/');
                }
                else{
                    console.log("Could not log in!");
                    res.redirect('/');
                }
            })
            .catch(error => {console.log(error)});
        }
    })
});

app.listen(6789, function () {
    console.log("listening on port 6789");
})