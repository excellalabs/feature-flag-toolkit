import flask_sqlalchemy

db = flask_sqlalchemy.SQLAlchemy()

class User(db.Model):
  __tablename__ = 'user'
  id = db.Column(db.Integer, primary_key=True)
  username = db.Column(db.String(50))
  password = db.Column(db.String(20))
  role = db.Column(db.String(20))

  @property
  def is_active(self):
    return True

  @property
  def is_authenticated(self):
    return True

  @property
  def is_anonymous(self):
    return False

  def get_id(self):
        try:
            return self.id
        except AttributeError:
            raise NotImplementedError('No `id` attribute - override `get_id`')
