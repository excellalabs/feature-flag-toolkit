FROM ubuntu:16.04

RUN apt-get update -y && \ 
    apt-get install -y python3-pip python3-dev && \
    apt-get install -y git

COPY ./requirements.txt usr/src/app/requirements.txt

WORKDIR /usr/src/app

RUN pip3 install -r requirements.txt && \
    pip3 install git+https://github.com/checkr/pyflagr.git

COPY . .

EXPOSE 5000

ENV LC_ALL=C.UTF-8
ENV LANG=C.UTF-8

ENV FLASK_APP=app.py
ENV FLASK_ENV=development
CMD flask db upgrade && flask run -h 0.0.0.0 -p 5000
