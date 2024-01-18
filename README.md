# DevChallenge

## Info

- Database is migrated on app startup (for convenience)
- API Data is downloaded and inserted into the DB on app startup (for convenience)
- A background job is refreshing the API data every minute
- Distance querying is done by MSSQL

## Instructions for running the project

- Run `buhler_dev_challenge_sql` `tools/local-compose.yml` to start the database 
  - `docker-compose -f local-compose.yml up buhler_dev_challenge_sql`
- Use `Buhler.DevChallenge.WebApi - https` to run the API
- Use Swagger UI to use the EPs
- Alternatively run the integration tests in your IDE


## Testing

Tests are implemented using test-containers. MSSQL DB is started in a docker container when tests are run.

### Prerequisites

- docker with linux containers

### Running the tests

- Run the tests in your IDE.
- There is an optional env variable `KeepDatabaseBetweenTests` which when set to true will keep the containers from being deleted
  so you can inspect the database after the tests have run. This is useful for debugging. The default is false.


## Project structure

- `src` folder
    - DDD layers
        - Domain
        - Application
          - Application services
        - Integration
          - API integration 
        - Persistence
            - Persistence.Migrations
                - Contains EF migrations and a migration runnable
        - WebApi
- `test` folder
    - `Tests.Integration`
        - Contains integration tests
    - `WebApi.Client`
        - C# API definition is generated from swagger.json so it can be used in tests
- `tools`
    - `local-compose.yml`
        - contains a MSSQL service so you can run your service locally

## Tech stack
- Entity Framework
- MSSQL
- .NET 7
- Docker
- xUnit
    - FluentAssertions
    - TestContainers
    - Respawner
    - NSwag
        - C# API definition is generated from swagger.json so it can be used in tests
