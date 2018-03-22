# -*- coding: utf-8 -*-
from __future__ import unicode_literals

from django.shortcuts import render, HttpResponse, redirect

# Create your views here.
def index(request):
    return HttpResponse(('index.html'))

def new(request):
    return HttpResponse('createform.html')

def create(request):
    #creation process
    return redirect('/')

def show(request):
    #brings out the page with specific id
    return HttpResponse('blog.html')

def edit():
    #editing process
    return redirect('/')

def destroy():
    #destruction process
    return redirect('/')