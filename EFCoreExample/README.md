# EFCoreExample

EFCoreExample is a .NET Core application that demonstrates the use of Entity Framework Core with both SQLite and SQL Server databases.

## Overview

The application uses different databases depending on the environment: SQLite for testing and SQL Server for development and production. This is managed through the `SchoolContextSqlite` and `SchoolContextSqlServer` classes, which are configured in the `Startup` class.

The `SchoolContext` class is the Entity Framework DbContext for the application. It contains `DbSet` properties for each of the entities in the model.

The `SchoolRepository` class provides methods for querying and updating the database using the `SchoolContext`.

The `MainService` class is the entry point for the application's functionality. It uses the `SchoolRepository` to interact with the database and `IConsoleService` for console interactions.

## Configuration

The application's configuration is stored in `appsettings.json` files. There are separate files for each environment: `appsettings.Testing.json` for the testing environment and `appsettings.Development.json` and `appsettings.Production.json` for the development and production environments respectively.

The configuration includes the connection string for the database and the log level settings.

## Running the Application

To run the application, use the `dotnet run` command in the root directory of the project. The application will use the settings from the `appsettings.Development.json` file by default.

To run the application in the testing environment, set the `ASPNETCORE_ENVIRONMENT` environment variable to `Testing` before running the `dotnet run` command. The application will use the settings from the `appsettings.Testing.json` file and the SQLite database.

## Migrations

The application uses Entity Framework Core Migrations to manage the database schema. The `ApplyMigrations` method in the `Program` class applies any pending migrations when the application starts.

## Testing

The application includes unit tests, which are located in the `EFCoreExample.Tests` project. The tests use xUnit and Moq for testing and mocking respectively. To run the tests, use the `dotnet test` command in the root directory of the project.
