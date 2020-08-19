module Flager
  class Flags < Base
    def initialize(args = {})
      super(args)
    end

    def self.find_all
      response = Request.get("flags")
      response
    end

    def self.find_flag(id)
      response = Request.get("flags/#{id}")
      response
    end

    def self.create_flag(params)
      response = Request.post(Base.flag_uri, params)
      response
    end

      ##TODO
    # def self.set_flag_enabled(params)
    #   # response = Request.put("flags/#{params[:flag_id]}/enabled")
    #   response = Request.put(params)
    #   response
    # end
  end
end