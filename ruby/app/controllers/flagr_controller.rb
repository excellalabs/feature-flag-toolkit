class FlagrController < ApplicationController
  skip_before_action :verify_authenticity_token
  def health
    result = Flager::Health.show()
    render :json => result
  end

  def find_flags
    result = Flager::Flags.find_all()
    render :json => result
  end

  def find_flag
    result = Flager::Flags.find_flag(params[:flag_id])
    render :json => result
  end

  private
  def flag_params
    params.permit(:flag_id)
  end
end
