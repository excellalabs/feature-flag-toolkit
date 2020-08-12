Rails.application.routes.draw do
  devise_for :users
  get 'flagr/health'
  get 'flagr/find_flags'
  get 'flagr/find_flag/:flag_id' => 'flagr#find_flag'
  post 'flagr/create_flag' => 'flagr#create_flag'
  put 'flagr/:flag_id/enabled' => 'flagr#set_flag_enabled'

  root 'flagr#index'
  resources :todos do
    resources :items
  end

end
