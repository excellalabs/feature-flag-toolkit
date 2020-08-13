# README

This application encompasses a bare-bones Rails App that connects to the Flagr API(https://checkr.github.io/flagr/api_docs/). 

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
    
    
### Notes
 * Runs on an internal host of docker('http://host.docker.internal:18000/api/v1/') as the base url
    * Not the usual API of local host hitting a different local host
 * Uses devise as authentication for proof of concept
    * Here's a quick setup guide: https://riptutorial.com/devise/example/12284/installation-or-setup
 * Most of the endpoints have not been incorporated with the front-end so you're going to have to use an HTTP client   
    
    

