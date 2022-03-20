# C# Assessment ChannelEngine

Create a .NET application with two entry points, a console app and an ASP.NET web app, which are connected to the ChannelEngine REST-API.

## Required functionality
Include at least the functionality listed below

## Application Entry points
- A .NET console application which can execute the business logic listed below. Write the results of the logic below to the console output.
- An ASP.NET application, which can execute the business logic listed below. Implement this using a controller which displays an HTML table with the results.

### Business logic
_Create the following methods in a shared library_

- Fetch all orders with status IN_PROGRESS from the API
- From these orders, compile a list of the top 5 products sold (product name, GTIN and total quantity), order these by the total quantity sold in descending order
- Pick one of the products from these orders and use the API to set the stock of this product to 25.

### Testing
- A unit test testing the expected outcome of the “top 5” functionality based on dummy input.

### Tips
- Try to incorporate dependency injection.
- Using async is allowed.
- Commit individual changes to version control, like you would do for a
professional project.

### Notes
- You are not allowed to use the ready made ChannelEngine API NuGet package.
- Any other libraries or NuGet packages are allowed.
- The business logic, ASP.NET entry point, console application entry point and
tests should all be added to the solution as separate projects.
- The finished project should be submitted by giving us access to a version control
system of your choice (e.g. Github, Gitlab, your own VCS server). If you have to
use a private repository, please ask your contact person who you should invite to
view.

The API documentation can be found at: https://api-dev.channelengine.net/api

You can use the following API key: 541b989ef78ccb1bad630ea5b85c6ebff9ca3322

For example:

https://api-dev.channelengine.net/api/v2/orders/new?apikey=541b989ef78ccb1bad630ea5b85c6ebff9ca3322

The process of creating a basic ASP.NET webapp can be found at:
https://docs.microsoft.com/en-us/aspnet/core/tutorials/first-mvc-app/

## Technologies used
- NET 6
- C# 10

## How to build
- MS Visual Studio 2022 / Rider (latest)

## Remarks
- Methods do not do null checking as C# nullable reference types feature is enabled.