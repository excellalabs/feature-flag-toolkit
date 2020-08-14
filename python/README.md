# Feature Flags in Python

This project is designed to show one way of implementing feature flags in Python. The web application is built using [Flask](https://flask.palletsprojects.com/en/1.1.x/), while [Flagr](https://checkr.github.io/flagr/#/) is used as an API for creating and evaluating flags. There is also a python library called [pyflagr](https://github.com/checkr/pyflagr) that makes interacting with Flagr even easier.

The project has been structured with three seperate docker containers. The web container is running our Flask app while the api container is using the base Flagr docker image to run the Flagr application and finally the db container is running a postgres database. 


# Getting Started

After you have cloned the repository, please make sure you have docker installed on your machine. You can check this by running ```docker --version``` from your terminal. If it is installed you can skip to the next step, if not, please navigate to [Docker](https://www.docker.com/get-started) and install Docker Desktop on your machine. 

After you've completed the previous steps you can simply run ```docker-compose up``` to start the three Docker containers. After they've been started you should be able to navigate to localhost:5000 to see the Flask application, and localhost:18000 to see the Flagr API. 