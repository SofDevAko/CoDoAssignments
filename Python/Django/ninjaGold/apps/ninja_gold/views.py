# -*- coding: utf-8 -*-
from __future__ import unicode_literals
from django.shortcuts import render, redirect
import random
from time import gmtime, strftime


def index(request):
    if 'db' in request.session:
        pass
    else:
        request.session['db'] = []

    if 'gold' in request.session:
        pass
    else:
        request.session['gold'] = 0
    return render(request, 'index.html')

def process(request):
    place = request.POST['place']
    if place == 'Farm':
        gain = request.session['gold']
        change = random.randint(10,20)
        gain += change
        request.session['gold'] = gain
    elif place == 'Cave':
        gain = request.session['gold']
        change = random.randint(5,10)
        gain += change
        request.session['gold'] = gain    
    elif place == 'House':
        gain = request.session['gold']
        change = random.randint(2,5)
        gain += change
        request.session['gold'] = gain
    elif place == 'Casino':
        gain = request.session['gold']
        change = random.randint(-50,50)
        gain += change
        request.session['gold'] = gain
    time = strftime("%H:%M %p %Y-%m-%d", gmtime())
    post = "Your ninja have gone to "+place+" and his total gold changed by "+str(change)+" "+str(time)+""
    data = {
        'place' : place,
        'post' : post,
        'time' : time,
        'gain' : gain,
        'change': change
    }
    temparr = request.session['db']
    temparr.append(data)
    request.session['db'] = temparr
    return redirect('/')

def reset(request):
    request.session.clear()
    return redirect('/')