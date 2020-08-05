class FlagrController < ApplicationController
  skip_before_action :verify_authenticity_token
  def health
    @health = Flager::Health.show()
    render :json => @health
  end

  def find_flags
    @flags = Flager::Flags.find()
    render :json => @flags
  end
end
