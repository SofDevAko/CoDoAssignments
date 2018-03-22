from flask import Flask
from mysqlconnection import MySQLConnector
app = Flask(__name__)
mysql = MySQLConnector(app, 'world')
print mysql.query_db("SELECT countries.region FROM countries WHERE countries.name LIKE '%key'")

