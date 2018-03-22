# -*- coding: utf-8 -*-
from __future__ import unicode_literals

from django.db import models
import re, bcrypt
EMAIL_REGEX = re.compile(r'^[a-zA-Z0-9.+_-]+@[a-zA-Z0-9._-]+\.[a-zA-Z]+$')
NAME_REGEX = re.compile(r'^[a-zA-Z]+$')
USER_REGEX = re.compile(r'^[a-zA-Z0-9.+_-]+$')

class UserManager(models.Manager):
    def login_validator(self, data):
        errors = []
        if User.objects.filter(username=data['username']):
            myuser=User.objects.get(username=data['username'])
            temppass = myuser.password
            if bcrypt.checkpw(data['password'].encode(), temppass.encode()):
                success = []
                request.session['active_id'] = myuser.id
                request.session['active_username'] = myuser.username
                return success
            else:
                errors.append('Invalid password!')
        else:
            errors.append('There is no registered email address')
        return errors

    def register_validator(self, data):
        errors = []
        if User.objects.filter(email=data['email']):
            errors.append('This email address is already registered')
        if len(data['username']) < 1 or len(data['email']) < 1 or len(data['password']) < 1 or len(data['conpass']) < 1 or len(data['first_name']) < 1 or len(data['last_name']) < 1:
            errors.append('Please fill all the fields!')
        if not EMAIL_REGEX.match(data['email']):
            errors.append("Invalid Email Address!")
        if not NAME_REGEX.match(data["first_name"]):
            errors.append("Your first name should contain letters only!")
        if not NAME_REGEX.match(data["last_name"]):
            errors.append("Your last name should contain letters only!")
        if not USER_REGEX.match(data["username"]):
            errors.append("Your username should contain letters and numbers only!")
        if len(data['password']) < 8:
            errors.append("Your password should contain 8 characters or more!")
        if not data['password'] == data['conpass']:
            errors.append("Password and confirmation password doesn't match")
        return errors

    def edit_validator(self, data):
        errors = []
        if len(data['username']) < 1 or len(data['email']) < 1 or len(data['password']) < 1 or len(data['conpass']) < 1 or len(data['first_name']) < 1 or len(data['last_name']) < 1:
            errors.append('Please fill all the fields!')
        if not EMAIL_REGEX.match(data['email']):
            errors.append("Invalid Email Address!")
        if not NAME_REGEX.match(data["first_name"]):
            errors.append("Your first name should contain letters only!")
        if not NAME_REGEX.match(data["last_name"]):
            errors.append("Your last name should contain letters only!")
        if not USER_REGEX.match(data["username"]):
            errors.append("Your username should contain letters and numbers only!")
        if len(data['password']) < 8:
            errors.append("Your password should contain 8 characters or more!")
        if not data['password'] == data['conpass']:
            errors.append("Password and confirmation password doesn't match")
        return errors

class User(models.Model):
    username = models.CharField(max_length=255)
    first_name = models.CharField(max_length=255)
    last_name = models.CharField(max_length=255)
    email = models.CharField(max_length=255)
    password = models.CharField(max_length=255)
    created_at = models.DateTimeField(auto_now_add=True)
    updated_at = models.DateTimeField(auto_now=True)
    
    objects = UserManager()
