# ToDoList Application
## Description
The ToDoList is a simple application created with objective of learning and practicing .NET 8.0, C#, Entity Framework Core. It allows users to create, update, and delete to-do items, and organize them into lists. The application is built using C# and .NET technologies, following a layered architecture for separation of concerns and easier maintenance.  

## Technologies Used
- C#: The primary programming language used for developing the application.
- .NET: The framework used for building the application.
- Entity Framework Core: An Object-Relational Mapper (ORM) used for data access.
- PostgreSQL: The database used for persisting data.

## Solution Layers
The solution is divided into several layers, each with a specific responsibility:  
- Domain: This layer contains the business entities (ToDoItem, ListToDo) and interfaces for services and repositories. It represents the business logic and rules of the application.  
- Data: This layer is responsible for data access and contains the DbContext (ToDoContext) and the implementation of the repositories. It uses Entity Framework Core for data access.  
- Application: This layer contains the implementation of the services. It acts as a bridge between the domain and the presentation layers, containing the business logic that manipulates the domain entities.  
- IoC: This layer is responsible for dependency injection. It contains the DependecyContainer class which registers the services and repositories.  
- Api: This layer is the entry point of the application. It contains the controllers which handle HTTP requests and responses.  

## Author
- Jhonatan Paschoal
