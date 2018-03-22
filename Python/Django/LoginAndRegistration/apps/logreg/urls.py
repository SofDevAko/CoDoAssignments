from django.conf.urls import url
from . import views

urlpatterns = [
    url(r'^$', views.index),
    url(r'^check$', views.check),
    url(r'^create$', views.create),
    url(r'^success$', views.success),
    url(r'^logout$', views.logout)
]