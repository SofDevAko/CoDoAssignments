# -*- coding: utf-8 -*-
from __future__ import unicode_literals

from django.shortcuts import render, redirect
from time import gmtime, strftime

def index(request):
    return render(request, 'sswords/index.html')

def add(request):
    if 'db' not in request.session:
        request.session['db'] = []

    word = request.POST['newword']
    color = request.POST['color']
    time = strftime("%H:%M %p %Y-%m-%d", gmtime())
    checkbox = request.POST.get('bigfont', False)
    if checkbox:
        font = 200
    else:
        font = 100
    post = word + ' -added on ' + time
    data = {
        'post' : post,
        'color' : color,
        'font' : font 
    }
    temp = request.session['db']
    temp.append(data)
    request.session['db'] = temp
    print(request.session['db'])
    return redirect('/')
def clear(request):
    request.session.clear()
    return redirect('/')