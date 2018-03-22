from flask import Flask, request, redirect, render_template, session, flash
from mysqlconnection import MySQLConnector
app = Flask(__name__)
mysql = MySQLConnector(app,'friend')
@app.route('/')
def index():
    query = "SELECT * FROM users"                          
    friends = mysql.query_db(query)                           
    return render_template('index.html', all_friends=friends) 

@app.route('/friends', methods=['POST'])
def create():
    query = "INSERT INTO users (first_name, last_name) VALUES (:first_name, :last_name)"
    data = {
             'first_name': request.form['first_name'],
             'last_name':  request.form['last_name'],
    }
    mysql.query_db(query, data)
    return redirect('/')

app.run(debug=True)
