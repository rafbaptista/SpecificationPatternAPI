# SpecificationPattern

How to create and populate SQL Server?

Run docker compose
cd SpecificationPattern/src/SpecificationPatternAPI
dotnet ef migrations add InitialCreate -o Infrastructure/Migrations/
dotnet ef database update

TODO: unit tests on specs
