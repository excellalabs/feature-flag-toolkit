module Flager
  class Base
    attr_accessor :errors

    def initialize(args = {})
      args.each do |name, value|
        attr_name = name.to_s.underscore
        send("#{attr_name}=", value) if respond_to?("#{attr_name}")
      end
    end

    def self.segment_uri
      'flags'
    end

    def self.flag_uri
      'flags'
    end

    def self.constraint_uri
      'flags'
    end
  end
end
