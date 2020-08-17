from wtforms import Form, StringField, PasswordField, SelectField, validators

class LoginForm(Form):
  username = StringField('Username', [validators.DataRequired()])
  password = PasswordField('Password', [validators.DataRequired()])

class CreateUserForm(Form):
  username = StringField('Username', [validators.DataRequired()])
  password = PasswordField('Password', [validators.DataRequired()])
  role = SelectField('Role', choices=[('admin', 'Admin'), ('authenticated', 'Authenticated'), ('public', 'Public')])
  