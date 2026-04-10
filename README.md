# Entity Framework Core Performance Optimization Demo

A .NET 10 Web API project demonstrating Entity Framework Core best practices, focusing on query optimization, performance benchmarking, and scalable data access patterns. This repository serves as a reference for mitigating common EF pitfalls like over-fetching, N+1 queries, and inefficient change tracking.

## Table of Contents
- [Overview](#overview)
- [Architecture](#architecture)
- [Prerequisites](#prerequisites)
- [Installation](#installation)
- [Configuration](#configuration)
- [Database Setup](#database-setup)
- [Usage](#usage)
- [API Endpoints](#api-endpoints)
- [Performance Insights](#performance-insights)
- [Migrations](#migrations)
- [Testing](#testing)
- [Deployment](#deployment)
- [Contributing](#contributing)
- [License](#license)

## Overview
This project illustrates real-world EF Core challenges in a .NET 10 environment, such as:
- **Over-fetching**: Retrieving unnecessary data, leading to bloated payloads and memory waste.
- **Change Tracking Overhead**: Balancing entity tracking for updates vs. read-only queries.
- **Query Optimization**: Using projections, `AsNoTracking()`, and selective loading to improve throughput.

Built with .NET 10's latest features (e.g., enhanced AOT compilation and minimal APIs), it provides benchmarking endpoints to quantify performance gains.

## Architecture
- **Framework**: .NET 10 (ASP.NET Core Web API)
- **ORM**: Entity Framework Core 10.x with SQLite for simplicity (easily swappable to SQL Server/PostgreSQL)
- **Design Patterns**:
  - Repository Pattern (via `ApplicationDBContext`)
  - Factory Pattern for design-time DbContext creation
  - Scoped DI for data seeding
- **Key Components**:
  - `ApplicationDBContext`: Central DbContext with entity configurations
  - `ProductController`: RESTful API with CRUD operations and benchmarks
  - `DbSeeder`: Scoped seeding for initial data population
- **Best Practices**:
  - Asynchronous operations throughout
  - Explicit projections to avoid over-fetching
  - `AsNoTracking()` for read-heavy endpoints
  - Connection string management via `IConfiguration`

## Prerequisites
- .NET 10 SDK (download from [Microsoft](https://dotnet.microsoft.com/download/dotnet/10.0))
- SQLite (bundled with EF Core.Sqlite)
- Visual Studio Code or Visual Studio 2022+ with C# extensions
- Git for version control

## Installation
1. Clone the repository:
   ```bash
   git clone https://github.com/your-repo/entity-project.git
   cd entity-project
2. dotnet restore
3. dotnet build
4. Update appsettings.json 
{
  "ConnectionStrings": {
    "MyConnectionString": "Data Source=app.db"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.EntityFrameworkCore": "Warning"
    }
  },
  "AllowedHosts": "*"
}

5. Install EF tools  - dotnet tool install --global dotnet-ef
6. Apply migrations - dotnet ef database update
7. Run the app - dotnet run\

## API Endpoints
GET /api/product: Retrieve all products (demonstrates over-fetching).
GET /api/product/fetchNamesOnly: Projection query for names only.
GET /api/product/{id}: Get a single product.
POST /api/product: Create a new product.
PUT /api/product/{id}: Update a product.
DELETE /api/product/{id}: Delete a product.
GET /api/product/benchmark/tracking: Benchmark with change tracking.
GET /api/product/benchmark/notracking: Benchmark without tracking.
