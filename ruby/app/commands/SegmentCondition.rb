class SegmentCondition
  def admin?(user_type)
    user_type == 'Admin' ? true : false
  end
end