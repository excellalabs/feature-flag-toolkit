# README

This application encompasses a barebones Rails App that connects to the Flagr API(https://checkr.github.io/flagr/api_docs/). 

Processes you may want to cover before getting started:

### Docker
* This application involves two Docker containers: Internal Rails app and an External Flagr image
   * docker-compose.yml sets both of these images up for both localhost usage and an internal docker host

### Rails App
* Simple Rails app that creates Todo and not much else
   

###Flagr

Flagr is a feature flagging, A/B testing and dynamic configuration microservice. The base path for all the APIs is "/api/v1".
* Runs on localhost:18000




## Setup 
 * Have docker installed and ready to go
 * Lets set up Flagr first:
      * run `docker pull checkr/flagr`
      * `docker run -it -p 18000:18000 checkr/flagr`
      * open localhost:18000
      * test out a few endpoints to make sure we're all good to go
      
  * Next is the rails app: 
    * with the way our docker-compose.yml is set up we're going to be running both the Rails app and the Flagr API on the same docker network
    * run `docker-compose build`   
    * `docker-compose up`
    * `docker-compose ps`
        * this should output 3 different containers(Rails app, DB, and Flagr)
    * `docker network inspect ruby_default`: this inspects the network that all three are located
        * make sure all three are here: if not, run `docker network connect ruby_default {container_name}` for those that aren't.     
    * test out a few endpoints using the Flagr_Controller  

