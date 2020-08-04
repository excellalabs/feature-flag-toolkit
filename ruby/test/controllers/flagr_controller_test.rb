require 'test_helper'

class FlagrControllerTest < ActionDispatch::IntegrationTest
  test "should get index" do
    get flagr_index_url
    assert_response :success
  end

end
