Rails.application.routes.draw do
  get 'flagr/health'

  root 'flagr#index'
  resources :todos do
    resources :items
  end
end
