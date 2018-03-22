from flask import Flask, render_template, request, redirect
app = Flask(__name__)
@app.route('/')

def main():
    return render_template('main.html')

@app.route('/process', methods=['POST'])

def process():

    name = request.form['name']
    email = request.form['email']
    print(name)
    return redirect('/')

app.run(debug=True)
