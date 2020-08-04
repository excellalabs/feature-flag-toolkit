require 'faraday'
require 'json'
require 'uri'

class Connection
  BASE = 'http://host.docker.internal:18000/api/v1/'

  def self.api
    Faraday.new(url: BASE) do |faraday|
      faraday.response :logger
      faraday.adapter Faraday.default_adapter
      faraday.headers['Content-Type'] = 'application/json'
    end
  end
end