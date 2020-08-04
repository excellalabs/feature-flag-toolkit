Rails.application.routes.draw do
  get 'flagr/index'
  get 'flagr/find_flags'
  get '/api/v1/flags' => 'flagr#find_flags'
  get 'flagr/health'
  get '/api/v1/health' => 'flagr#health'


  post 'flagr/create_flag'

  post '/api/v1/flags' => 'flagr#create_flag'
  # post '/flags' => 'flager#create_flag'

  root 'flagr#index'
  resources :todos do
    resources :items
  end
end
