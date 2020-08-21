module Flager
  class Segment < Base
    def initialize(args = {})
      super(args)
    end

    def self.create_segment(id, params)
      response = Request.post(Base.segment_uri + "/#{id}/segments", params)
      response.body
    end

    def self.find_segments(id)
      response =  Request.get("flags/#{id}/segments")
      response
    end

    def self.create_constraint(params)
      response = Request.post(Base.segment_uri,params)
      response
    end
  end
end