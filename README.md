# Introduction

## Content
The code structure contains both the web and web.api projects of the Capstone Project. The web.api project also contains the web.api.db migrations.




## Installing Prerequisites

1. Open Terminal or Command Prompt in admin mode


2. [.NET SDK](https://dotnet.microsoft.com/en-us/download) **8.0** LTS

   2.1. Install dotnet sdk

       winget install Microsoft.DotNet.SDK.8

   2.2. Check dotnet sdk

       dotnet --version


3. [.NET Entity Framework Core](https://learn.microsoft.com/en-us/ef/ef6/fundamentals/install) **8.***

   3.1. Install entity framework

       dotnet new tool-manifest
       dotnet tool install --global dotnet-ef --version 8.*

   3.2. Check entity framework

       dotnet-ef --version


4. [Node JS](https://nodejs.org/en/download/package-manager) **20.13.1** LTS

   4.1. Install NodeJS

       winget install OpenJS.NodeJS.20

   4.2. Check NodeJS

       node --version


5. [Git CLI](https://git-scm.com/download/)

   5.1. Install Git CLI

       winget install Git.Git

   5.2. Check Git CLI

       git --version


6. [Visual Studio](https://visualstudio.microsoft.com/downloads)

   6.1. Install Visual Studio

       winget install Microsoft.VisualStudio.2022.Community


5. [Visual Studio Code](https://code.visualstudio.com/Download)

   7.1. Install Visual Studio Code

       winget install Microsoft.VisualStudioCode

   7.2. Optional [Remote Repositories](https://marketplace.visualstudio.com/items?itemName=ms-vscode.remote-repositories) extension

       code --install-extension ms-vscode.remote-repositories

   7.3. Optional [Remote Development](https://marketplace.visualstudio.com/items?itemName=ms-vscode-remote.vscode-remote-extensionpack) extension

       code --install-extension ms-vscode-remote.vscode-remote-extensionpack

   7.4. Optional [Angular Language Service](https://marketplace.visualstudio.com/items?itemName=Angular.ng-template) extension

       code --install-extension Angular.ng-template




## Updating Packages

1. Packages installed with WinGet

       winget upgrade --all --accept-source-agreements --accept-package-agreements

2. Entity Framework

       dotnet tool update --global dotnet-ef




## Setting Up Development Environment

1. capstone.web.db

   1.1. Open `capstone.web.api\capstone.web.api.sln` in Visual Studio

   1.2. Open a developer terminal (ctrl + `)

   1.3. Create database and schema `dotnet ef database update --project capstone.web.api`


2. capstone.web.api

   2.1. Open `capstone.web.api\capstone.web.api.sln` in Visual Studio

   2.2. Build the solution (ctrl+shift+b)

   2.3. Run the solution in https mode (f5)

   2.4. Access the [Swagger UI](https://localhost:7197/swagger/)

   2.5. Locate the `POST /api/login` method and expand it

   2.6. Select **Try it out** and change the request body username to `admin` and password to `admin-password` then click **Execute**

   2.7. In the Response body copy the token value into your clipboard

   2.8. Scroll to the top of the Swagger UI interface and click **Authorize**

   2.9. Enter "bearer " then paste the token and click **Authorize**


3. capstone.web

   3.1. Open `capstone.web` folder in Visual Studio Code

   3.2. Open a terminal (ctrl + `)

   3.3. Install Angular `npm install --global @angular/cli`

   3.4. Install project dependancies `npm install`

   3.5. Run the application `ng serve`

   3.6. Access the [To Do UI](http://localhost:4200/)

   3.7. With the capstone.web.api project running in Visual Studio, attempt to log in with username `general` and password `general-password`
