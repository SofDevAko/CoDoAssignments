from flask import Flask, session, redirect, render_template, request, flash

app = Flask(__name__)
app.secret_key = "secret"




@app.route('/')
def index():
    if 'deaths' not in session:
        session['deaths'] = 0
    return render_template("index.html", deaths = session['deaths'])

@app.route('/sleep')
def sleep():
    session["deaths"] += 1
    return render_template("sleep.html", deaths = session['deaths'])

@app.route('/wakeup')
def wakeup():
    return render_template("wakeup.html", deaths = session['deaths'])

@app.route('/bike')
def bike():
    session["deaths"] += 1
    return render_template("bike.html", deaths = session['deaths'])
@app.route('/bus')
def bus():
    return render_template("bus.html", deaths = session['deaths'])

@app.route('/belton')
def belton():
    session["deaths"] += 1
    return render_template("belton.html", deaths = session['deaths'])

@app.route('/beltoff')
def beltoff():
    return render_template("beltoff.html", deaths = session['deaths'])

@app.route('/reset')
def reset():
    session["deaths"] = 0
    return redirect('/')


app.run(debug=True)