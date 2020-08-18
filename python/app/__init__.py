from flask import Flask
import flask_sqlalchemy
from .models import db, User
from flask_migrate import Migrate
from flask_login import LoginManager

app = Flask(__name__)
app.config['SQLALCHEMY_TRACK_MODIFICATIONS'] = False 
app.secret_key = 'super secret'
app.app_context().push()
db.init_app(app)
db.create_all()
migrate = Migrate(app, db)

# Create the login manager for the flask-login package
login_manager = LoginManager()
login_manager.init_app(app)

@login_manager.user_loader
def load_user(user_id):
    return User.query.get(user_id)

from app import views