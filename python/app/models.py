import flask_sqlalchemy

db = flask_sqlalchemy.SQLAlchemy()

class User(db.Model):
  __tablename__ = 'user'
  id = db.Column(db.Integer, primary_key=True)
  username = db.Column(db.String(100))
  password = db.Column(db.String(20))