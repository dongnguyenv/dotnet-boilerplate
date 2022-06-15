# dotnet-boilerplate
dotnet boiler plate

# Prerequired:
    - Install docker
# Generate cert
```dotnet dev-certs https -ep ./aspnet/https/aspnetapp.pfx -p qaz@WSX```

```dotnet dev-certs https --trust```
# Setup 
## 1. create docker network

```docker network create kong-net```

## 2. Deploy kong infrastructure

```docker-compose up -d kong-database kong-migrate kong konga-prepare konga```

## 3. Deploy services

## Build up catalog service

```docker-compose up -d --build catalog-services```

## Build up log service

```docker-compose up -d --build auth-service```

## Build up auth service

```docker-compose up -d --build logmanagement-services```


# Expose services though Kong Gateway

## Register catalog-service though kong gateway

```curl -i -X POST --url http://localhost:8001/services/ --data name="catalog-service" --data url="https://catalog-services:443/"```

## Register catalog route to catalog-service

```curl -i -X POST --url http://localhost:8001/services/catalog-service/routes --data "paths[]=/catalog" --data name="catalog-api"```

## Register log-management service though kong gateway

```curl -i -X POST --url http://localhost:8001/services/ --data name="logmanagement-service" --data url="https://logmanagement-services:443/"```

## Register log-management route to logmanagement-service

```
curl -i -X POST --url http://localhost:8001/services/logmanagement-service/routes --data "paths[]=/log-management" --data name="logmanagement-api"
```

## Register catalog route to catalog-service

```curl -i -X POST --url http://localhost:8001/services/catalog-service/routes --data "paths[]=/catalog" --data name="catalog-api"```

## Register auth service though kong gateway

```
curl -i -X POST --url http://localhost:8001/services/ --data name="auth-service" --data url="https://auth-service:443/"
```

## Register auth route to auth-service

```
curl -i -X POST --url http://localhost:8001/services/auth-service/routes --data "paths[]=/auth" --data name="auth-api"
```

# Test configs

```curl -X 'GET' 'http://localhost:8000/catalog/WeatherForecast' -H 'accept: text/plain'```

```curl -X 'GET' 'http://localhost:8000/log-management/logs' -H 'accept: text/plain'```
