class ApplicationController < ActionController::Base
  protect_from_forgery with: :exception
  skip_before_action :verify_authenticity_token, if: -> { controller_name == 'sessions' }
  include Response
  include ExceptionHandler
end
