## About

Very simple API written in .NET 6 that demonstrates the use of the Specification Pattern both in-memory and database queries, using the same specification and also composition of specifications.

The project also has a test project that performs some unit tests to test the behaviour of the specifications.

### Installation and Usage
```bash
git clone https://github.com/rafbaptista/SpecificationPatternAPI.git
cd SpecificationPattern/src/SpecificationPatternAPI

## Build and run webapi and SQL Server
docker compose up --build 
```

### Examples
```bash
### Get all sales from the system as system admin 
curl -k -X GET http://localhost:8080/sale/1

### Get all sales from a company as a company admin 
curl -k -X GET http://localhost:8080/sale/2

### Get all user creatd sales as an company employee  
curl -k -X GET http://localhost:8080/sale/3

```