module Flager
  class Constraint < Base
    def initialize(args = {})
      super(args)
    end

    def self.create_constraint(params)
      response = Request.post(Base.constraint_uri,params)
      response
    end
  end
end