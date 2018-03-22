from flask import Flask, render_template, request, redirect, flash, session
import re
EMAIL_REGEX = re.compile(r'^[a-zA-Z0-9.+_-]+@[a-zA-Z0-9._-]+\.[a-zA-Z]+$')
NAME_REGEX = re.compile(r'^[a-zA-Z]+$')
app = Flask(__name__)
app.secret_key = "Mellon"
@app.route('/')

def main():

    return render_template('index.html')

@app.route('/process', methods=['POST'])

def process():

    email = request.form['email']
    firstname = request.form['firstname']
    lastname = request.form['lastname']
    password = request.form['password']
    conpass = request.form['conpass']
    error = 0


    if len(request.form['email']) < 1 or len(request.form['firstname']) < 1 or len(request.form['lastname']) < 1 or len(request.form['password']) < 1 or len(request.form['conpass']) < 1:
        flash("Please fill out all the inputs!")
        error += 1
    if not EMAIL_REGEX.match(request.form['email']):
        flash("Invalid Email Address!")
        error += 1
    if not NAME_REGEX.match(request.form["firstname"]):
        flash("Your first name should contain letters only!")
        error += 1
    if not NAME_REGEX.match(request.form["lastname"]):
        flash("Your last name should contain letters only!")
        error += 1
    if len(request.form['password']) < 8:
        flash("Your password should contain 8 characters or more!")
        error += 1
    if not request.form['password'] == request.form['conpass']:
        flash("Password and confirmation password doesn't match")
        error += 1
    if error == 0:
        flash("Thank you for submitting your information!")
    return redirect("/")
app.run(debug=True)

