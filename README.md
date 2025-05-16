# SimpleAuthAPI

A .NET-based authentication API implementing clean architecture principles with JWT authentication.

## Features

- User registration and authentication
- JWT token-based authorization
- Onion Architecture implementation
- Entity Framework Core with SQLite
- Swagger/OpenAPI documentation
- Docker support

## Project Structure

```
SimpleAuthAPI/
├── src/
│   ├── SimpleAuthAPI.API           # API layer with controllers and middleware
│   ├── SimpleAuthAPI.Application   # Application layer with services and DTOs
│   ├── SimpleAuthAPI.Domain        # Domain layer with entities and interfaces
│   └── SimpleAuthAPI.Infrastructure# Infrastructure layer with implementations
```

## Prerequisites

- .NET 8.0 SDK
- Visual Studio Code or any preferred IDE
- Docker (optional)

## Getting Started

### Running Locally

1. Clone the repository

```bash
git clone https://github.com/yourusername/SimpleAuthAPI.git
cd SimpleAuthAPI
```

2. Install dependencies

```bash
dotnet restore
```

3. Update the database

```bash
cd src/SimpleAuthAPI.API
dotnet ef database update
```

4. Run the application

```bash
dotnet run
```

### Running with Docker

1. Build and run using Docker Compose

```bash
docker build -t simpleauthapi .
docker run -p 5195:8080 simpleauthapi
```

The API will be available at:

- HTTP: http://localhost:5195
- HTTPS: https://localhost:5001
- Swagger UI: http://localhost:5195/swagger
- [Postman Documentation](https://documenter.getpostman.com/view/22366860/2sB2qUp5nn)

## API Endpoints

### Authentication

- POST /api/auth/register - Register a new user
- POST /api/auth/login - Login with existing credentials

### Users

- GET /api/users - Get all users (requires authentication)
- GET /api/users/me - Get authenticated user details

## Authentication

The API uses JWT Bearer token authentication. Include the token in your requests:

```bash
curl -H "Authorization: Bearer your-token" https://localhost:5001/api/users/me
```

## Development

To run in development mode with hot reload:

```bash
dotnet watch run
```

For Docker development:

```bash
docker-compose up --build
```

## License

MIT
