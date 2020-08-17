module Flager
  class Segment < Base
    def initialize(args = {})
      super(args)
    end

    def self.create_segment(params)
      response = Request.post(params)
      response
    end
  end
end