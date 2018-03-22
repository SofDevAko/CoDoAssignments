from flask import Flask, render_template, session, redirect, request

app = Flask(__name__)
app.secret_key = "Mellon"

@app.route('/')

def index():
    session["times"] += 1
    return render_template("index.html")

@app.route('/increase')
def increase():
    session["times"] += 1
    return redirect("/")

@app.route('/reset')
def reset():
    session["times"] = -1
    return redirect("/")

app.run(debug=True)