# Feature Flags in Python

This project is designed to show one way of implementing feature flags in Python. The web application is built using [Flask](https://flask.palletsprojects.com/en/1.1.x/), [Flask-Login](https://flask-login.readthedocs.io/en/latest/), [Flask-SQLAlchemy](https://flask-sqlalchemy.palletsprojects.com/en/2.x/), [Flask-Migrate](https://flask-migrate.readthedocs.io/en/latest/), and [Flask-WTF](https://flask-wtf.readthedocs.io/en/stable/). [Flagr](https://checkr.github.io/flagr/#/) is used as an API for creating and evaluating flags. There is also a python library called [pyflagr](https://github.com/checkr/pyflagr) that makes interacting with Flagr even easier.

The project has been structured with three seperate docker containers. The web container is running our Flask app while the api container is using the base docker image for Flagr to run the Flagr API and finally the db container is running a postgres database. 


# Getting Started

After you have cloned the repository, please make sure you have docker installed on your machine. You can check this by running ```docker --version``` from your terminal. If it is installed you can skip to the next step, if not, please navigate to [Docker](https://www.docker.com/get-started) and install Docker Desktop on your machine. 

After you've completed the previous steps you can simply run ```docker-compose up``` to start the three Docker containers. After they've been started you should be able to navigate to localhost:5000 to see the Flask application, and localhost:18000 to see the Flagr API.

# Example (Date Written: 08/19/2020)

To quickly understand how Flagr works you can run through this example which will walk you through creating a simple flag. The Flask application supports three different users; Admin, Authenticated, and Public. We will create a flag that shows up 100% of the time for Admins, 50% of the time for Authenticated users, and 0% of the time for Public users.

## Step 1

After your containers have started, navigate to localhost:18000. In the bar that says "Specific new flag description" enter in any flag name and then click create.

## Step 2 

First you should enable the flag. Then you can create two variants one labeled "Off", and the other labeled "On". When you evaluate the flag it will send back one of these variants based off the context you pass in from the web application. 

## Step 3

Next you should create three segments, one labeled "Admin", the next labeled "Authenticated", and the last one labeled "Public".

## Step 4

For the first segment create a new distribution and select the "on" variant and set it to 100%. For the Authenticated segment split 50% between "On" and 50% for "off". Finally, for the Public segment set the "off" variant to 100%. 

At this point your flag should like similar to these pictures:

![Enabled flag](/python/readme-images/turn_flag_on.PNG)
![Flag variants](/python/readme-images/flag_variant.PNG)
![First Segment](/python/readme-images/first_segment.PNG)
![Second Segment](/python/readme-images/second_segment.PNG)
![Third Segment](/python/readme-images/third_segment.PNG)

## Create an account and view flags

Navigate to localhost:5000/user/create and create an account with any username or password. Select Admin, and hit enter. You should see the flag you just created. Next create another account and assign it the Authenticated role. You should see your flag appear 50% of the time. Do the same thing for the Public role, and you should not see your flag at all.




