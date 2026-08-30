# FoodSafe Montreal

FoodSafe Montreal is an ASP.NET Core MVC application for exploring public food-establishment data from the City of Montreal. The long-term goal is to import official CSV feeds, detect changes, and support an internal compliance-review workflow without altering the source data.

## Current MVP foundation

- .NET 10 and ASP.NET Core MVC
- Layered solution: Domain, Application, Infrastructure, and Web
- Searchable establishment list backed by an in-memory repository
- Dependency injection and cancellation support
- Health endpoint at `/health`
- Unit tests for domain validation and application search behavior

The in-memory records are explicitly demo data. No conclusion about the current compliance status of a real establishment should be inferred from them.

## Solution structure

```text
src/
  FoodSafeMontreal.Domain/          Core business entities
  FoodSafeMontreal.Application/     Use cases and repository contracts
  FoodSafeMontreal.Infrastructure/  Data-access implementations
  FoodSafeMontreal.Web/             MVC controllers, view models, and views
tests/
  FoodSafeMontreal.UnitTests/       Fast domain and application tests
```

Dependencies point inward:

```text
Web -> Infrastructure -> Application -> Domain
Web --------------------> Application
```

## Run locally

```powershell
dotnet restore FoodSafeMontreal.sln
dotnet build FoodSafeMontreal.sln --no-restore
dotnet run --project src/FoodSafeMontreal.Web
```

Open the URL printed by ASP.NET Core, then navigate to `/Establishments`.

Run the tests with:

```powershell
dotnet test FoodSafeMontreal.sln
```

## Planned increments

1. Add a resilient HTTP client for the City of Montreal CSV resources.
2. Parse and validate establishment records with CsvHelper.
3. Persist imports with Entity Framework Core and SQLite.
4. Import published food violations and link them by `business_id`.
5. Add compliance cases, notes, status history, and authentication.
6. Add dashboards, maps, REST endpoints, Docker, and CI.

## Official data sources planned

- [Food establishments](https://donnees.montreal.ca/dataset/etablissements-alimentaires)
- [Food inspection offenders](https://donnees.montreal.ca/fr/dataset/inspection-aliments-contrevenants)
- [Food inspection activity report](https://donnees.montreal.ca/fr/dataset/inspection-aliments-bilan)

Always review the methodology and licence on each official dataset before importing or publishing derived information.
