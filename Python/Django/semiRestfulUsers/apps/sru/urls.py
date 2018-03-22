from django.conf.urls import url
from . import views

urlpatterns = [
    url(r'^$', views.index),
    url(r'^new$', views.new),
    url(r'^(?P<id>[0-9]+)/edit$', views.edit),
    url(r'^(?P<id>[0-9]+)$', views.show),
    url(r'^create$', views.create),
    url(r'^(?P<id>[0-9]+)/destroy$', views.destroy),
    url(r'^(?P<id>[0-9]+)/update$', views.update)
]
