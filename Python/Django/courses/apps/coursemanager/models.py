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
        if User.objects.filter(email=data['email']):
            myuser=User.objects.get(email=data['email'])
            temppass = myuser.password
            if bcrypt.checkpw(data['password'].encode(), temppass.encode()):
                success = []
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

class User(models.Model):
    username = models.CharField(max_length=255)
    first_name = models.CharField(max_length=255)
    last_name = models.CharField(max_length=255)
    email = models.CharField(max_length=255)
    password = models.CharField(max_length=255)
    created_at = models.DateTimeField(auto_now_add=True)
    updated_at = models.DateTimeField(auto_now=True)
    
    objects = UserManager()

class CourseManager(models.Manager):
    def course_validator(self, data):
        errors = []
        if len(data['name']) > 5 and len(data['name']) < 25 and len(data['description']) > 15 and len(data['description']) < 85:
            success = []
            return success
        else:
            errors.append('25>Name>5 and 85>description>15')
            return errors

class Course(models.Model):
    name = models.CharField(max_length=255)
    description = models.CharField(max_length=255)
    created_at = models.DateTimeField(auto_now_add=True)
    created_by = models.CharField(max_length=255, default = 'user')
    users_who_liked = models.ManyToManyField(User, related_name="Courses_that_are_liked")
    
    objects = CourseManager()

class Comment(models.Model):
    content = models.CharField(max_length=255)
    created_at = models.DateTimeField(auto_now_add=True)
    commenter = models.ForeignKey(User)
    commented = models.ForeignKey(Course)

objects = Comment()