class FlagrController < ApplicationController
  skip_before_action :verify_authenticity_token
  include Devise::Controllers::Helpers

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

  def create_flag
    result = Flager::Flags.create_flag(flag_params)
    render :json => result
  end

  ##TODO
  # def set_flag_enabled
  #   result = Flager::Flags.set_flag_enabled(flag_params)
  #   render :json => result
  # end

  def create_segment
    result = Flager::Segment.create_segment(params[:flag_id], segment_params)
    render :json => result
  end

  def find_segments
    result = Flager::Segment.find_segments(params[:flag_id])
    render :json => result
  end

  def create_constraint
    result = Flager::Constraint.create_constraint(constraint_params)
    render :json => result
  end

  private

  def flag_params
    params.permit(:description, :key, :template, :flag_id, :enabled)
  end

  def segment_params
    params.permit(:description, :rollout_percent)
  end

  def constraint_params
    params.permit(:property, :operator, :value)
  end
end
