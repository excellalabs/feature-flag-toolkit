from __future__ import print_function
from app import app
import time
import flagr
from flagr.rest import ApiException
from flask import render_template, request, flash
from app.forms import LoginForm


loggedInUser = ""


@app.route('/', methods=['GET', 'POST'])
def login():
    form = LoginForm(request.form)
    if request.method == 'POST' and form.validate():
        if (form.username.data is 'admin' and form.password.data is 'admin'):
            loggedInUser = "admin"
            flash('Logged in successfully')
        elif (form.username.data is 'public' and form.password.data is 'public'):
            loggedInUser = "public"
            flash('Logged in successfully')
        else:
            flash('Please login with one of the provided accounts')
        return render_template('home.html')
    return render_template('login.html', form=form)

@app.route('/flags')
def display_all_flags():
  # create an instance of the API class
  api_instance = flagr.FlagApi()
  api_instance.api_client.configuration.host = "flagr:18000"

  try:
      api_response = api_instance.find_flags()
      print(api_response)
      return render_template('display_flags.html', all_flags=api_response)
  except ApiException as e:
      return render_template('error.html', error=e)

