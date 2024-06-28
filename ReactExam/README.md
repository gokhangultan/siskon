# Introduction 
The steps required to run the exam application are explained below. Please follow the steps carefully.

# Getting Started
1.	Installation process
The application folder contains 2 different projects. VehicleAPI is a background application where you will run api services. VehicleUI, on the other hand, consists of the parts that make up the user interfaces. To run the application, first restore the Database file on SQL Server. For the restore process, use the Vehicle2021.bak backup file in the folder.
2.	Run API
Before running the API project, update the MasterConnectionString value in the appsettings.json file with the necessary parameters. 
After entering the required parameters, run the API application. When the application is run correctly, it will open the swagger application related to API services with the browser. Here you can test the existing APIs in the system or the APIs you have written.
3. Run UI
Before running the UI project, update the DefaultApiUrl value in the config.js file with the required parameters. This parameter should be the same as the URL value in the browser when the API application is running. The commands required to run the application are "yarn install" followed by "yarn start". When these commands are executed correctly, the application will be displayed on your web browser.
 

# Contribute

If you want to learn more about creating good readme files then refer the following [guidelines](https://www.visualstudio.com/en-us/docs/git/create-a-readme). You can also seek inspiration from the below readme files:
- [ASP.NET Core](https://github.com/aspnet/Home)
- [Visual Studio Code](https://github.com/Microsoft/vscode)
- [MSSQL Server](https://www.microsoft.com/tr-tr/sql-server/sql-server-downloads)
- [Yarn](https://yarnpkg.com/getting-started)