# -*- coding: utf-8 -*-
from __future__ import unicode_literals

from django.shortcuts import render, redirect, HttpResponse
from django.contrib import messages
from django.contrib.messages import get_messages


def index(request):

    return render(request, 'surveys/index.html')

def process(request):
    
    if len(request.POST['name']) < 1 or len(request.POST['comment']) < 1:
        messages.add_message(request, messages.ERROR, "Please fill out Name and Comment!")
        return redirect("/")
    if len(request.POST['comment']) > 120:
        messages.add_message(request, messages.ERROR, "Comments cannot be more than 120 characters!")
        return redirect("/")
    mestore = get_messages(request)
    request.session['name'] = request.POST['name']
    request.session['dojo'] = request.POST['dojo']
    request.session['favlang'] = request.POST['favlang']
    request.session['comment'] = request.POST['comment']
   

    if len(mestore) == 0:
        if  request.session["times"]:
            request.session["times"] += 1
        else:
            request.session["times"] = 0
        return redirect('/result')

def result(request):
    return render(request, 'surveys/result.html')