# Deploying .NET 6 Apps into Amazon EC2 (Ubuntu/Windows)

## Date Time: 18-Dec-2021 at 09:00 AM IST

## Event URL: [https://www.meetup.com/dot-net-learners-house-hyderabad/events/281836958](https://www.meetup.com/dot-net-learners-house-hyderabad/events/281836958)

## Youtube URL: [https://www.youtube.com/watch?v=FAgrCzShssY](https://www.youtube.com/watch?v=FAgrCzShssY)

![Viswanatha Swamy P K |150x150](./documentation/images/ViswanathaSwamyPK.PNG)

---

## Application Architecture Diagram

![Application Architecture 10-Nov-2021 |150x150](./documentation/images/AppArchitecture.PNG)

---


## Information

![Information | 100x100](./documentation/images/Information.PNG)

## What are we doing today?

> 1. Deploying .NET 6 Web API into Amazon EC2 (Ubuntu)
> 1. Deploying .NET 6 Web App into Amazon EC2 (Windows)
> 1. SUMMARY / RECAP / Q&A


![Seat Belt | 100x100](./documentation/images/SeatBelt.PNG)

---

## 1. Deploying .NET 6 Web API into Amazon EC2 (Ubuntu)

### Installing Nginx on Ubuntu EC2

> 1. Discussion & Demo

```
sudo apt-get -y update
sudo apt-get -y install nginx
curl -I http://localhost
```

![Install Nginx | 100x100](./documentation/images/InstallNginx.PNG)

### Installing .NET 6 on Ubuntu EC2
> 1. Discussion & Demo

```
wget https://packages.microsoft.com/config/ubuntu/20.04/packages-microsoft-prod.deb -O packages-microsoft-prod.deb
sudo dpkg -i packages-microsoft-prod.deb
rm packages-microsoft-prod.deb
```

```
sudo apt-get update; \
  sudo apt-get install -y apt-transport-https && \
  sudo apt-get update && \
  sudo apt-get install -y dotnet-sdk-6.0
```

Reference: https://docs.microsoft.com/en-gb/dotnet/core/install/linux-ubuntu#2004-

### Verifying the .NET 6 Web API on the local box
> 1. Discussion & Demo

![Verify .NET 6 Web Api Locally | 100x100](./documentation/images/Verify.NET6WebApiLocally.PNG)

### Publish and push the binaries into the Ubuntu EC2
> 1. Discussion & Demo

### Verify the .NET 6 Web API on Ubuntu EC2
> 1. Discussion & Demo

### Configure Reverse proxy inside Nginx to route the traffic to the .NET 6 Web API
> 1. Discussion & Demo

---

## 2. Deploying .NET 6 Web App into Amazon EC2 (Windows)
> 1. Discussion & Demo

### EC2 Instance Connect (browser-based SSH connection)
> 1. Demo

### Login Into Linux VM Using Browser
![Login Into Linux VM Using Browser | 100x100](./documentation/images/LoginIntoLinuxVM_UsingBrowser.PNG)


### Login using SSH in WSL2
> 1. Demo

```
ls -l
chmod 400 linuxvm1.pem
ssh -i "linuxvm1.pem" ec2-user@ec2-3-82-191-107.compute-1.amazonaws.com
```


### Setting `.pem` Key File Permission
![KeyFilePermission | 100x100](./documentation/images/KeyFilePermission.PNG)

### Login Into Linux VM Using SSH in WSL2
![LoginIntoLinuxVM | 100x100](./documentation/images/LoginIntoLinuxVM.PNG)

### DEMO 1 LAMP/Nginx Server

```
sudo apt update && sudo apt install -y lamp-server^
curl -I http://localhost
```

### Accessing the Apache  default page On Ubuntu VM
![ApacheOnUbuntuVM | 100x100](./documentation/images/ApacheOnUbuntuVM.PNG)



## 3. SUMMARY / RECAP / Q&A

---

> 1. SUMMARY / RECAP / Q&A
> 2. Any open queries, I will get back through meetup chat/twitter.

---

## What is Next? 

**URL:** [https://www.meetup.com/dot-net-learners-house-hyderabad/events/ToBeDone](https://www.meetup.com/dot-net-learners-house-hyderabad/events/ToBeDone)

**Date:** `15-Jan-2022` at `09:00 AM IST`

> 1. Introduction with Amazon S3 Bucket
> 1. Working with S3 using .NET
> 1. Deploying static websites on Amazon S3
> 1. VPC, Subnets
> 1. Availability Zones (AZs)
> 1. Regions
> 1. Edge Locations
> 1. Regional Edge Caches
> 1. Reboot the machine to show data loss
