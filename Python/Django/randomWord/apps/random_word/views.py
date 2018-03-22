# -*- coding: utf-8 -*-
from __future__ import unicode_literals

from django.shortcuts import render, redirect
from django.utils.crypto import get_random_string

# Create your views here.
def index(request):
    return render(request, 'random_word/index.html')

def generate(request):
    if request.session.get('count'):
        request.session['count'] += 1
    else:
        request.session['count'] = 1
    request.session['text'] = get_random_string(length=14)
    return redirect('/')

def reset(request):
    request.session['count'] = 0
    return redirect('/')
