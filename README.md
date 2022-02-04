# VendingMachine

Chosen Project
Virtual Vending Machine
Create a virtual vendening machine. There are a selection of products with a price and a quantity remaining. Users should put in (virtual) money and purchase an item. After they have purchased an item, they can use the remaining money to purchase another item or have the change returned to them. Once they are done they should see a list of the items they have purchased.

Tools Used:
Visual Studio 2019
Visual Studio Code

Languages and frameworks
Backend: C#, .NET Core
Front End: Typescript, Angular, HTML


Project Breakdown
BackEnd: 
  VendingMachine/VendingMachine.Model - This contains the database and models for the api. 
  VendingMachine/VendingMachine.Services - The main api service. contains the repo layer, service layer and controllers
  
FrontEnd:
  VendingMachine/UI/VendingMachine.Angular - Main angular project, typescript files are under the app.component module
