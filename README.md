# CyberIncidents

Web application developed with C# and ASP.NET Core MVC for managing cybersecurity incidents, users, accounts, and assets.

## Live Demo

[Open CyberIncidents](https://cyberincidents-camiloartola-gaa9atb4bng3cvbn.brazilsouth-01.azurewebsites.net/)

## Demo Credentials

You can use the following test accounts to explore the application:

### Administrator

- **Email:** `admin@demo.com`
- **Password:** `admin123`
- **Role:** Administrator

### Operator

- **Email:** `operador@demo.com`
- **Password:** `operador123`
- **Role:** Operator

> These credentials are provided exclusively for demonstration purposes.

## Academic Project

This project was developed as part of a university course focused on object-oriented programming and web application development. It was created as an academic assignment to apply concepts related to software architecture, ASP.NET Core MVC, authentication, authorization, and object-oriented programming.

## Technologies

- C#
- .NET 10
- ASP.NET Core MVC
- Razor
- HTML
- CSS
- Bootstrap

## Features

- User registration and login
- Authentication and authorization
- Role-based access control
- User and account management
- Asset management
- Cybersecurity incident management
- Incident tracking and validation
- Form validation
- MVC architecture

## Project Structure

The solution is divided into separate projects:

- **AplicacionWeb** — ASP.NET Core MVC web application, controllers, views, filters, and presentation logic.
- **Dominio** — Domain classes and business logic.
- **Consola** — Console application for interacting with the domain layer.

## Documentation

The repository includes UML diagrams and project documentation related to the system design and requirements.

## Running Locally

### Requirements

- Visual Studio 2022 or later
- .NET 10 SDK

### Setup

1. Clone the repository.
2. Open `ObligatorioP2_26.slnx` in Visual Studio.
3. Set `AplicacionWeb` as the startup project.
4. Build the solution.
5. Run the application.

## Deployment

The application is deployed on Microsoft Azure using Azure App Service, with continuous deployment through GitHub Actions and HTTPS enabled.

## Author

Camilo Artola
