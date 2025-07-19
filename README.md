Talabat.API

A multi-layered ASP.NET Core Web API project built using Clean Architecture principles. This system is designed to manage Talabat-style food ordering services with clear separation of concerns across the core, service, repository, and API layers.

---

Project Structure

- **Talabat.Core**  
  Contains domain entities, enums, and repository interfaces. This layer is completely independent of external frameworks.

- **Talabat.Repository**  
  Handles all data access logic using **Entity Framework Core**, implementing the interfaces defined in the Core layer.

- **Talabat.Service**  
  Encapsulates business rules, validation, and processing logic.

- **Talabat.APIs**  
  The entry point of the application that exposes RESTful API endpoints via ASP.NET Core.

## Important Note

For the best experience:

- Download the `.RAR` file from the repository
- Extract it and open the solution in Visual Studio
- Test the API using **Postman** or the built-in **Swagger UI**
