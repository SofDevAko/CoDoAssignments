# -*- coding: utf-8 -*-
from __future__ import unicode_literals

from django.shortcuts import render, redirect
from models import User
from django.contrib import messages
from time import gmtime, strftime
import bcrypt

def index(request):
    users = User.objects.all()
    context = {
        "users" : users
    }
    return render(request, 'sru/index.html', context)
def new(request):
    return render(request, 'sru/new.html')
def edit(request, id):
    user = User.objects.get(id=id)
    context = { "user" : user}
    return render(request, 'sru/edit.html', context)
def show(request, id):
    user = User.objects.get(id = id)
    context = { "user" : user}
    return render(request, 'sru/profile.html', context)
def create(request):
    errors = User.objects.register_validator(request.POST)
    if len(errors):
        for error in errors:
            messages.error(request, error)
        return redirect('/users/new')
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
        return redirect('/users/new')
def destroy(request, id):
    User.objects.get(id=id).delete()
    return redirect('/users/')
def update(request, id):
    errors = User.objects.edit_validator(request.POST)
    if len(errors):
        for error in errors:
            messages.error(request, error)
        return redirect("/users/"+id+"/edit")
    else:
        time = strftime("%Y-%m-%d %H:%M", gmtime())
        User.objects.filter(id = id).update(
            username = request.POST['username'],
            first_name = request.POST['first_name'],
            last_name = request.POST['last_name'],
            email = request.POST['email'],
            password = bcrypt.hashpw(request.POST['password'].encode(), bcrypt.gensalt()),
            updated_at = time
        )
        messages.success(request, "You have successfully registered!")
        return redirect("/users/"+id+"")



