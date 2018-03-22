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
    if len(session) == 0:
        generateRandom()
    else:
        print("none")
        print(session)
        pass
    return render_template("index.html")

@app.route('/guess', methods=["POST"])

def guess():
    session["guessnumber"] = request.form["guessnumber"]
    print(session["guessnumber"])
    if session["guessnumber"] == session["number"]:
        flash("Correct", "success")
        return redirect("/")
    elif session["guessnumber"] > session["number"]:
        flash("Too High!", "error")
    elif session["number"] > session["guessnumber"]:
        flash("Too Low!", "error")
    else:
        flash("Guessed number is not valid!", "error")
    return redirect('/')

@app.route('/reset', methods=["GET", "POST"])
def reset():
    session.clear()
    generateRandom()
    return redirect('/')

app.run(debug=True)