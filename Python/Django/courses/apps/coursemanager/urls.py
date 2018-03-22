from django.conf.urls import url
from . import views

urlpatterns = [
    url(r'^$', views.index),
    url(r'^check$', views.check),
    url(r'^create$', views.create),
    url(r'^courses$', views.courses),
    url(r'^logout$', views.logout),
    url(r'^courses/addcourse$', views.addcourse),
    url(r'^courses/destroy/(?P<id>[0-9]+)$', views.destroy),
    url(r'^courses/delete/(?P<id>[0-9]+)$', views.delete),
    url(r'^courses/show/(?P<id>[0-9]+)$', views.show),
    url(r'^courses/like/(?P<id>[0-9]+)$', views.like),
    url(r'^courses/makecomment/(?P<id>[0-9]+)$', views.makecomment),
]