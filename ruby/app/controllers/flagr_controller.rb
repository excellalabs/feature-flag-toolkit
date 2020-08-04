class FlagrController < ApplicationController
  skip_before_action :verify_authenticity_token
  def health
    @health = Flager::Health.show()
    render :json => @health
  end
end
