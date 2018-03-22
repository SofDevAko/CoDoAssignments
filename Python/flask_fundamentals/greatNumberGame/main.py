from flask import Flask, flash, render_template, session, redirect, request
import random

app = Flask(__name__)
app.secret_key = "Mellon"

def generateRandom():
    number = random.randrange(0, 101)
    session["number"] = number
    print(session["number"])

@app.route('/')

def index():
    if not "number" in session:
        generateRandom()
    return render_template("index.html")

@app.route('/guess', methods=["POST"])

def guess():
    session["guessnumber"] = int(request.form["guessnumber"])
    print(session["guessnumber"])
    if session["guessnumber"] == session["number"]:
        flash("Correct", "success")
        return redirect("/")
    elif session["guessnumber"] > session["number"]:
        flash("Go lower!", "error")
    elif session["number"] > session["guessnumber"]:
        flash("Go higher!", "error")
   
    return redirect('/')

@app.route('/reset', methods=["GET", "POST"])
def reset():
    session.clear()
    return redirect('/')

app.run(debug=True)