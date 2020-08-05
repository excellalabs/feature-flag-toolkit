module Flager
  class Flags < Base
    def self.find_all
      response = Request.get("flags")
      response
    end

    def self.find_flag(id)
      response = Request.get("flags/#{id}")
      response
    end

    def initialize(args = {})
      super(args)
    end
  end
end