# -*- coding: utf-8 -*-
from __future__ import unicode_literals

from django.shortcuts import render, redirect
import re, bcrypt
from .models import User, Course, Comment
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
        return redirect('/courses')

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
        return redirect('/')

def courses(request):
    if 'active_username' in request.session:
        courses = Course.objects.all()
        context = { 'courses' : courses}
        return render(request, 'courses.html', context)
    else:
        messages.error(request, "You need to login first!")
        return redirect("/")
    
def logout(request):
    request.session.clear()
    return redirect('/')

def addcourse(request):
    errors = Course.objects.course_validator(request.POST)
    if len(errors):
        for error in errors:
            messages.error(request, error)
        return redirect('/courses')
    else:
        time = strftime("%H:%M %p %Y-%m-%d", gmtime())
        Course.objects.create(
            name = request.POST['name'],
            description = request.POST['description'],
            created_at = time,
            created_by = request.session['active_username']
        )
        courses = Course.objects.all()
        context = { 'courses' : courses}
        messages.success(request, "You have successfully added a course!")
        return redirect('/courses', context)

def destroy(request, id):
    data = Course.objects.get(id=id)
    if data.created_by == request.session['active_username']:
        Course.objects.get(id=id).delete()
    else:
        messages.error(request, "You need to be the one who have created it in order to delete it!")
    return redirect('/courses')

def show(request, id):
    course = Course.objects.get(id=id)
    comments = Comment.objects.filter(commented = id)
    context = { 
        'course' : course,
        'comments': comments
        }
    return render(request, 'show.html', context)

def like(request, id):
    user = User.objects.get(id = request.session['active_id'])
    course = Course.objects.get(id = id)
    if course.users_who_liked:
        course.users_who_liked.add(user)
    else:
        course.users_who_liked.create(user)
    course.save()
    return redirect('/courses')

def makecomment(request, id):
    comment = Comment()
    course = Course.objects.get(id = id)
    myuser = User.objects.get(id = request.session['active_id'])
    time = strftime("%H:%M %p %Y-%m-%d", gmtime())    
    Comment.objects.create(
        content = request.POST['comment'],
        created_at = time,
        commenter = myuser,
        commented = course,
        )
    return redirect('/courses')

def delete(request, id):
    data = Comment.objects.get(id=id)
    if data.commenter.id == request.session['active_id']:
        Comment.objects.get(id=id).delete()
    else:
        messages.error(request, "You need to be the one who have created it in order to delete it!")
    return redirect('/courses')