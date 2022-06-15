# dotnet-boilerplate
dotnet boiler plate

# Prerequired:
    - Install docker
    - Generate cert    
        ```
        dotnet dev-certs https -ep ./aspnet/https/aspnetapp.pfx -p qaz@WSX
        ```
        ```
        dotnet dev-certs https --trust
        ```
# Setup 
1. create docker network

```docker network create kong-net```
2. Deploy kong infrastructure
```docker-compose up -d kong-database kong-migrate kong konga-prepare konga```

3. Deploy services
```docker-compose up -d --build catalog-services```