FROM ubuntu:16.04

RUN apt-get update -y && \ 
    apt-get install -y python3-pip python3-dev && \
    apt-get install -y git

COPY ./requirements.txt /app/requirements.txt

WORKDIR /app

RUN pip3 install -r requirements.txt && \
    pip3 install git+https://github.com/checkr/pyflagr.git

COPY . /app

EXPOSE 5001

ENTRYPOINT [ "python3" ]

CMD [ "run.py" ]
