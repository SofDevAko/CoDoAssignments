# -*- coding: utf-8 -*-
from __future__ import unicode_literals

from django.shortcuts import render, redirect
import re, bcrypt
from .models import User
from django.contrib import messages
from time import gmtime, strftime

def index(request): 
    return render(request, 'index.html') 

def check(request):
    errors = User.objects.login_validator(request.POST)
    if len(errors):
        for error in errors:
            messages.error(request, error)
        return redirect('/')
    else:
        myuser=User.objects.get(email=request.POST['email'])
        request.session['active_username'] = myuser.username
        request.session['active_id'] = myuser.id
        return redirect('/success')

def create(request):
    errors = User.objects.register_validator(request.POST)
    if len(errors):
        for error in errors:
            messages.error(request, error)
        return redirect('/')
    else:
        time = strftime("%H:%M %p %Y-%m-%d", gmtime())
        User.objects.create(
            username = request.POST['username'],
            first_name = request.POST['first_name'],
            last_name = request.POST['last_name'],
            email = request.POST['email'],
            password = bcrypt.hashpw(request.POST['password'].encode(), bcrypt.gensalt()),
            created_at = time,
            updated_at = time,
        )
        messages.success(request, "You have successfully registered!")
        return redirect('/success')

def success(request):
    if request.session['active_username']:
        return render(request, 'success.html')
    else:
        messages.error(request, "You need to login first!")
        return redirect("/")
    
def logout(request):
    request.session['active_username'] = None
    request.session['active_id'] = None
    return redirect('/')