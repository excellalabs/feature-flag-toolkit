from __future__ import print_function
from app import app
import time
import flagr
from flagr.rest import ApiException
from flask import render_template, request, flash
from app.forms import LoginForm
from app.models import User
from app.models import db


loggedInUser = ""


@app.route('/', methods=['GET', 'POST'])
def login():
    form = LoginForm(request.form)
    if request.method == 'POST' and form.validate():
        user = User.query.first()
        if (user.password == form.password.data):
            print(user.password)
            print(form.password.data)
            return render_template('home.html')
    return render_template('login.html', form=form)

@app.route('/flags')
def display_all_flags():
  # create an instance of the API class
  api_instance = flagr.FlagApi()
  api_instance.api_client.configuration.host = "python_flagr_1:18000/api/v1"

  try:
      api_response = api_instance.find_flags()
      print(api_response)
      return render_template('display_flags.html', all_flags=api_response)
  except ApiException as e:
      return render_template('error.html', error=e)

@app.route('/new-user', methods=['GET', 'POST'])
def create_user():
    if request.method == 'GET':
        data = request.get_json()
        new_account = User(username="Devin", password="123")
        db.session.add(new_account)
        db.session.commit()
    return "Success!"

