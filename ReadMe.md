# NorthwindTraders

Northwind Traders is a sample application built using ASP.NET Core and Entity Framework Core. The architecture and design of the project is explained in the video:

* [Clean Architecture with ASP.NET Core 2.1](https://youtu.be/_lwCVE_XgqI) ([slide deck](https://github.com/JasonGT/NorthwindTraders/raw/master/Slides.pdf))

The initial construction of this project is explained in the following blog posts:

* [Code: Northwind Traders with Entity Framework Core](http://www.codingflow.net/northwind-traders-with-entity-framework-core/)
* [Create Northwind Traders Code First with Entity Framework Core – Part 1](http://www.codingflow.net/create-northwind-traders-code-first-with-entity-framework-core-part-1/)
* [Create Northwind Traders Code First with Entity Framework Core – Part 2](http://www.codingflow.net/create-northwind-traders-code-first-with-entity-framework-core-part-2/)

For information on upcoming features and fixes, take a look at the [product roadmap](https://github.com/JasonGT/NorthwindTraders/wiki/Roadmap).

## Getting Started
Use these instructions to get the project up and running.

### Prerequisites
You will need the following tools:

* [Visual Studio Code or 2017](https://www.visualstudio.com/downloads/)
* [.NET Core SDK 2.2](https://www.microsoft.com/net/download/dotnet-core/2.2)

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
  4. Next, within the `Northwind.WebUI\ClientApp` directory, launch the front end by running:
     ```
     npm start
     ```
  5. Once the front end has started, within the `Northwind.WebUI` directory, launch the back end by running:
     ```
	 dotnet run
	 ```
  5. Launch [http://localhost:52468/](http://localhost:52468/) in your browser to view the Web UI
  
  6. Launch [http://localhost:52468/api](http://localhost:52468/api) in your browser to view the API

## Technologies
* .NET Core 2.2
* ASP.NET Core 2.2
* Entity Framework Core 2.2

## License

This project is licensed under the MIT License - see the [LICENSE.md](https://github.com/JasonGT/NorthwindTraders/blob/master/LICENSE.md) file for details.
