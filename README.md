# Container adventure day
Container Adventure Day is an interactive team-based and individual learning experience to learn more about on how to work with containers in Azure.

Participants will be working as teams to complete increasingly complex. Subject Matter Experts are available to guide the teams through this journey if needed. The Game Play itself will have a four-phase narrative around Development, Optimizing, Deploy and Scale. 

The target audience are for this event are Software Engineers, Software Developers, Cloud Architects and DevOps Engineers. 

You should have a basic understanding of Microsoft Azure and Docker. Kubernetes experie is helpful. A highly recommended starting point is [Microsoft Certified: Azure Fundamentals](https://docs.microsoft.com/en-us/learn/certifications/azure-fundamentals/), [Administer containers in Azure](https://docs.microsoft.com/en-us/learn/paths/administer-containers-in-azure/) and [Introduction to Docker containers](https://docs.microsoft.com/en-us/learn/modules/intro-to-docker-containers/) .



**TIME:** 70 minutes

## Story
Skynet is infiltrating your datacenter and is taking over your mining robots one by one and is using the resources for its own use.
To fight back you need to make your application more robust and resilient by containerizing it. Someone created a VMs running Docker in Azure and also started the work for containerizing the applications. 

## Overview
Mining applications consists of a back-end application, called "mining-api" and a front-end application, called "mining-web". To run the mining application a SQL database is needed. We will run the database as a container. We will pull the SQL server image from Docker Hub and run it locally. In this challenge we will build the "mining-api" and "mining-web" and try it locally. If everything works fine, we will then push the image to a private registry in Azure.

![Mining App ACI](overview.drawio.png)
 
## Steps

You have several ways to do the labs:
* Locally, on your PC with Docker installed
* In Codespaces
* From Azure Cloud Shell


### 1. Access code

This is the repository that you are going to use for the exercise: [CAD team](https://github.com/Solidify-Container-Adventure-Day/cad-team).
Clone it in Codespaces, on your local machine or in Azure Cloud Shell and there is no need to push the commits back.

*In case you want to use Codespaces, read through the following instructions. Otherwise, clone the repository and go directly to the next challenge.*

To create a Codespace, you have to be added as a collaborator to the Git repository. For this, make sure that you share your GitHub handle with your proctor.
[GitHub Codespaces](https://docs.github.com/en/codespaces) is a development environment that is hosted in the Cloud. It is a good way to work with your code without installing anything on your local machine. Docker and many other things are already there for you. Just create a Codespace instead of cloning it to your local machine.

![image](https://user-images.githubusercontent.com/20904922/158958604-9505f41a-7bdc-4095-af3e-0db9df868a71.png)

![image](https://user-images.githubusercontent.com/20904922/158828689-3d512220-1afa-4a00-8a85-1f1bd28fdbca.png)




> **Tip**: Note that your Codespace "times out" after 30 minutes if you are not using it but you can change the timeout [in this way](https://docs.github.com/en/codespaces/customizing-your-codespace/setting-your-timeout-period-for-codespaces)

> **Tip**: Also, make sure to run this command in the terminal window to install the latest version of the Docker CLI. After you run the command start a new terminal window in Codespaces.
```
curl -L https://raw.githubusercontent.com/docker/compose-cli/main/scripts/install/install_linux.sh | sh
```


