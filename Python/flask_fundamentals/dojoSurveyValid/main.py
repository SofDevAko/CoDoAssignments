from flask import Flask, render_template, request, redirect, flash, session
app = Flask(__name__)
app.secret_key = "Mellon"
@app.route('/')

def main():

    return render_template('index.html')

@app.route('/process', methods=['POST'])

def process():

    name = request.form['name']
    dojo = request.form['dojo']
    favlang = request.form['favlang']
    comment = request.form['comment']


    if len(request.form['name']) < 1 or len(request.form['comment']) < 1:
        flash("Please fill out Name and Comment!")
        return redirect("/")
    elif len(request.form['comment']) > 120:
        flash("Comments cannot be more than 120 characters!")
        return redirect("/")
    else:
        flash("Success!") 
        return render_template("/process.html", **locals())


app.run(debug=True)

