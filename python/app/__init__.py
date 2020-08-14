from flask import Flask
import flask_sqlalchemy
from .models import db
from flask_migrate import Migrate

app = Flask(__name__)
app.config['SQLALCHEMY_TRACK_MODIFICATIONS'] = False 
app.app_context().push()
db.init_app(app)
db.create_all()
migrate = Migrate(app, db)

from app import views