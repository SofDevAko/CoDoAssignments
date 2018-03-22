from flask import Flask, render_template, request, redirect
app = Flask(__name__)
@app.route('/')

def main():
    return render_template('index.html')

@app.route('/process', methods=['POST'])

def process():

    name = request.form['name']
    dojo = request.form['dojo']
    favlang = request.form['favlang']
    comment = request.form['favlang']
    return render_template('process.html', **locals())

app.run(debug=True)

