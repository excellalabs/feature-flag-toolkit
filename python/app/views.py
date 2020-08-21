from app import app
import time
import flagr
from flagr.rest import ApiException
from flask import render_template, request, flash, redirect, url_for
from flask_login import logout_user, current_user, login_user
from app.forms import LoginForm, CreateUserForm
from app.models import User, db

FLAGR_BASE_URL = "python_flagr_1:18000/api/v1"

@app.route('/', methods=['GET', 'POST'])
def login():
    form = LoginForm(request.form)
    if request.method == 'POST' and form.validate():
        user = User.query.filter(User.username == form.username.data).first()
        if user:
            login_user(user)
            if (user.password == form.password.data):
                return redirect(url_for('get_users_flags'))
    return render_template('login.html', form=form)

@app.route('/user/create', methods=['GET', 'POST'])
def create_user():
    form = CreateUserForm(request.form)
    if request.method == 'POST' and form.validate():
        data = request.get_json()
        new_account = User(username=form.username.data, password=form.password.data, role=form.role.data)
        db.session.add(new_account)
        db.session.commit()
        login_user(new_account)
        return redirect(url_for('get_users_flags'))
    return render_template('create_user.html', form=form)

@app.route('/flags')
def display_all_flags():
    flags = get_all_flags()
    return render_template('display_flags.html', all_flags=flags, is_user_flags=False)

@app.route('/user/flags')
def get_users_flags():
    flags = get_all_flags()
    eval_api_instance = flagr.EvaluationApi()
    eval_api_instance.api_client.configuration.host = FLAGR_BASE_URL
    # flagr.EvalContext returns this empty json object 
    # {
    #   'eval_context': 
    #     {
    #       'enable_debug': None, 
    #       'entity_context': None, 
    #       'entity_id': None, 
    #       'entity_type': None, 
    #       'flag_id': None, 
    #       'flag_key': None, 
    #       'flag_tags': None
    #     }
    # }
    body = flagr.EvalContext()
    if current_user.is_anonymous:
        return redirect(url_for('login'))
    body.entity_context = { "role": current_user.role }

    user_flags = []

    for flag in flags:
        try:
            body.flag_id = flag.id
            api_response = eval_api_instance.post_evaluation(body)
            if api_response.variant_key != 'Off':
                user_flags.append(flag)
        except ApiException as e:
            return render_template('error.html', error=e)
    
    return render_template('display_flags.html', all_flags=user_flags, is_user_flags=True)


def get_all_flags():
    api_instance = flagr.FlagApi()
    api_instance.api_client.configuration.host = FLAGR_BASE_URL

    try: 
        api_response = api_instance.find_flags()
        return api_response
    except ApiException as e:
        return render_template('error.html', error=e)
