from flask import Flask, request, redirect, render_template, session, flash
from mysqlconnection import MySQLConnector
import md5, os, binascii, re
EMAIL_REGEX = re.compile(r'^[a-zA-Z0-9.+_-]+@[a-zA-Z0-9._-]+\.[a-zA-Z]+$')
NAME_REGEX = re.compile(r'^[a-zA-Z]+$')
USER_REGEX = re.compile(r'^[a-zA-Z0-9.+_-]+$')
app = Flask(__name__)
app.secret_key = "Mellon"
mysql = MySQLConnector(app,'logregdb')
@app.route('/')
def index(): 
    return render_template('index.html') 

@app.route('/login', methods=["POST"])
def check():
    logerror = []
    query = "SELECT * FROM users WHERE username = :username"
    user = {'username' : request.form['username']}
    login = mysql.query_db(query,user)
    if not login:
        logerror.append('Invalid username!')
    else:
        temppass = request.form['password']
        salt = login[0]['salt']
        pswd = md5.new(temppass + salt).hexdigest()
        if not pswd == login[0]['hs_password']:
            logerror.append('Wrong Password!')
        if len(logerror) == 0:
            return render_template('success.html', username = login[0]['username'])
    for i in logerror:
        flash(i)
    return redirect('/')


@app.route('/create', methods=["POST"])
def register():
    error = []
    query = "SELECT * FROM users WHERE username = :username"
    user = {'username' : request.form['username']}
    usertry = mysql.query_db(query,user)


    if usertry:
        error.append("Username already exists, please login or choose a different one to register!")
    if len(request.form['username']) < 1 or len(request.form['email']) < 1 or len(request.form['first_name']) < 1 or len(request.form['last_name']) < 1 or len(request.form['password']) < 1 or len(request.form['conpass']) < 1:
        error.append("Please fill out all the inputs!")
    if not EMAIL_REGEX.match(request.form['email']):
        error.append("Invalid Email Address!")
    if not NAME_REGEX.match(request.form["first_name"]):
        error.append("Your first name should contain letters only!")
    if not NAME_REGEX.match(request.form["last_name"]):
        error.append("Your last name should contain letters only!")
    if not USER_REGEX.match(request.form["username"]):
        error.append("Your username should contain letters and numbers only!")
    if len(request.form['password']) < 8:
        error.append("Your password should contain 8 characters or more!")
    if not request.form['password'] == request.form['conpass']:
        error.append("Password and confirmation password doesn't match")
    if len(error) == 0:
        password = request.form['password']
        salt = binascii.b2a_hex(os.urandom(15))
        hs_password = md5.new(password + salt).hexdigest()
        query = "INSERT INTO users (username, hs_password, first_name, last_name, email, salt, created_at, updated_at) VALUES (:username, :hs_password, :first_name, :last_name, :email, :salt, NOW(), NOW())"
        newuser = {
            'username' : request.form['username'],
            'hs_password' : hs_password,
            'first_name' : request.form['first_name'],
            'last_name' : request.form['last_name'],
            'email' : request.form['email'],
            'salt' : salt
        }
        mysql.query_db(query, newuser)
    for i in error:
        flash(i)
    return redirect('/')
app.run(debug=True)
