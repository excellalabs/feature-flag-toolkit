module Flager
  class Health < Base
    attr_accessor :status

    def self.show
      response = Request.get("health")
      response
    end

    def self.find
      response = Request.get(id)
      Health.new(response)
    end

    def initialize(args = {})
      # super(args)
    end
  end
end