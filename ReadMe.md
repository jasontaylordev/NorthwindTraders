# NorthwindTraders

Northwind Traders is a sample application built using ASP.NET Core and Entity Framework Core. The architecture and design of the project is explained in the video:

* [Developing Enterprise Apps with ASP.NET Core 2.1](https://youtu.be/fAJrVf8f6M4)

The initial construction of this project is explained in the following blog posts:

* [Code: Northwind Traders with Entity Framework Core](http://www.codingflow.net/northwind-traders-with-entity-framework-core/)
* [Create Northwind Traders Code First with Entity Framework Core – Part 1](http://www.codingflow.net/create-northwind-traders-code-first-with-entity-framework-core-part-1/)
* [Create Northwind Traders Code First with Entity Framework Core – Part 2](http://www.codingflow.net/create-northwind-traders-code-first-with-entity-framework-core-part-2/)

## Getting Started
Use these instuctions to get the project up and running.

### Prerequisites
You will need the following tools:

* [Visual Studio Code or 2017](https://www.visualstudio.com/downloads/)
* [.NET Core SDK 2.1](https://www.microsoft.com/net/download/)

### Setup
Follow these steps to get your development environment set up:

  1. Clone the repository
  2. At the root directory, restore required packages by running:
     ```
     dotnet restore
     ```
  3. Next, build the solution by running:
     ```
     dotnet build
     ```
  4. Finally, within the `Northwind.WebUI` directory, launch the project by running:
     ```
     dotnet run
     ```
   5. Finally, launch [http://localhost:5211/swagger/]() in your browser to view the Swagger UI for the Northwind API.

## Technologies
* [.NET Core 2.1](https://blogs.msdn.microsoft.com/dotnet/2018/05/30/announcing-net-core-2-1/)
* [ASP.NET Core 2.1](https://blogs.msdn.microsoft.com/webdev/2018/05/30/asp-net-core-2-1-0-now-available/)
* [Entity Framework Core 2.1](https://blogs.msdn.microsoft.com/dotnet/2018/05/30/announcing-entity-framework-core-2-1/)

## License

This project is licensed under the MIT License - see the [LICENSE.md](https://github.com/JasonGT/NorthwindTraders/blob/master/LICENSE.md) file for details.
