class Request
  class << self
    def where(resource_path, query = {}, options = {})
      response, status = get_json(resource_path, query)
      status == 200 ? response : errors(response)
    end

    def get(id = nil)
      response, status = get_json(id)
      status == 200 ? response : errors(response)
    end

    def errors(response)
      error = { errors: { status: response["status"], message: response["message"] } }
      response.merge(error)
    end

    def get_json(root_path, query = {})
      query_string = query.map{|k,v| "#{k}=#{v}"}.join("&")
      path = query.empty?? root_path : "#{root_path}?#{query_string}"
      response = api.get(path)

      [JSON.parse(response.body), response.status]
    end

    def post(params)
      body = params_to_json(params)
      api.post("flags", body)
    end

    def api
      Connection.api
    end

    private
    def params_to_json(params)
      body = {description: params[:description], key: params[:key], template: params[:template]}.to_json
      body
    end
  end
end