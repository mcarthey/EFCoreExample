# EFCoreExample

EFCoreExample is a .NET Core application that demonstrates the use of Entity Framework Core in a console application. It provides a simple interface for managing classrooms and students.

## Overview

The application uses Entity Framework Core to interact with the database, and supports both SQLite and SQL Server databases. The database used depends on the environment: SQLite for testing and SQL Server for development and production.

The application provides a console interface for adding classrooms, adding students to classrooms, listing all classrooms, and listing all students in a specific classroom.

## Configuration

The application's configuration, including the database connection string, is stored in `appsettings.json` files. There are separate files for each environment.

## Running the Application

To run the application, use the `dotnet run` command in the root directory of the project.

## Migrations

The application uses Entity Framework Core Migrations to manage the database schema.

## Testing

The application includes unit tests, which are located in a separate project. The tests use xUnit and Moq.
