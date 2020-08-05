module Flager
  class Flags < Base
    attr_accessor

    def self.find
      response = Request.get("flags")
      response
    end

    def initialize(args = {})
      super(args)
    end
  end
end