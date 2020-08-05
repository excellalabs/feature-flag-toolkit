Rails.application.routes.draw do
  get 'flagr/health'
  get 'flagr/find_flags'

  root 'flagr#index'
  resources :todos do
    resources :items
  end
end
