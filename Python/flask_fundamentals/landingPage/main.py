from flask import Flask, render_template, request, redirect
app = Flask(__name__)
@app.route('/')

def main():
    return render_template('index.html')

@app.route('/ninjas')

def ninjas():
    return render_template('ninjas.html')

@app.route('/dojos/new')

def dojos():
    return render_template('dojos.html')

def create_ninjas():
   print "Got Post Info"
   render_template('dojos.html')
   name = request.form['name']
   email = request.form['email']
   return redirect('/')

app.run(debug=True)

