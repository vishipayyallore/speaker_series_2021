# Working with Redis Cache with .Net Core

## Working with Redis Cache in our Laptop

URL: <https://redislabs.com/blog/redis-on-windows-10/>

### Verify WSL on Windows 10

hostname
lsb_release -a
cat /etc/\*-release

### To Install on WSL on Windows 10

1. sudo apt-get update
2. sudo apt-get upgrade
3. sudo apt-get install redis-server

### Verifying the Version

1. redis-server -v
2. redis-cli -v

### To Start and Stop the Redis Service

1. sudo service redis-server restart
2. sudo service redis-server stop

### To connect to Redis Server

1. redis-cli

![image info](./Images/Local_Redis_Cache.jpg)

## Creating Simple ASP.Net Core 3.1 Web API (EF Core, and Redis)

1. We will verify the existing .Net Core Web API using Postman.
2. We will add the Redis Cache Nuget package and configure it in Start up class.
3. Verify the services Container using Shift + F9

4. Get All Professors. Verify the Redis Cache from Command line.
5. Verify the Time Stamps of retrieval with and without Redis Cache.
6. Retrieve a particular Professor. Verify the Redis Cache from Command line.
7. Verify the Time Stamps of retrieval with and without Redis Cache.
8. Delete OR Wait till the Cache Expiration and verify the time stamps.

![image info](./Images/DataAccess_With_And_Without_Cache.jpg)

## Consuming the ASP.net Core Web API in Client Application

1. We will test the Web UI. It will not show the Content.
2. We will add the CORS to the Web API.
3. Again, we will Test the UI. Now it will show the Content.
4. Please refer to the image below.

![image info](./Images/WebUI_Consuming_DotNet_WebAPI.jpg)

## Working with Redis Cache in Azure

### Will be covered in Next Month's (15-Jun-2020) session.

## Creating Simple Node JS Web API (Mongo Db, and Redis)

### Will be covered in Next Month's (15-Jun-2020) session.

## Consuming Node JS Web API in Client Application.

### Will be covered in Next Month's (15-Jun-2020) session.
