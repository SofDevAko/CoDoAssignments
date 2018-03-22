from flask import Flask, request, redirect, render_template, session, flash
from mysqlconnection import MySQLConnector
app = Flask(__name__)
app.secret_key = "Mellon"
mysql = MySQLConnector(app,'mydb')
@app.route('/')
def index(): 
    return render_template('index.html') 

@app.route('/check', methods=["POST"])
def check():
    query = "SELECT * FROM email"
    allmails = mysql.query_db(query)
    query = "SELECT * FROM email WHERE address = :email"
    data = {'email': request.form["email"]}
    mails = mysql.query_db(query, data)
    if mails:
        return render_template("success.html", all_mails = allmails, usermail = request.form['email'])
    else:
        flash("Email is not valid!!!")
        return redirect('/')
app.run(debug=True)
