# APIConnect

This is a test project to create a CRUD (Create, Read, Update, Delete) system for adding and removing customers, as well as adding and removing employees. The goal of this project is to demonstrate the use of the following technologies:

- .NET 7.0: Used to develop the API.
- ASP.NET Core MVC: Used to develop the user interface.
- MySQL: Used as the database to store the information.
- ADO.NET: Used for the data access layer, instead of Entity Framework Core, in order to explore the direct use of ADO.NET for learning purposes.
- XUnit: Used it for unit tests, which I verified the behavior and quality of the code.

The project was developed using a layered architecture, following good development practices. Each layer plays a specific role in the system and contributes to the organization and separation of responsibilities.

The project's layers are as follows:

Domain Layer: In this layer, the concepts and business rules of the system are contained. It represents the fundamental entities and behaviors of the application domain.

Infrastructure Layer: This layer is responsible for providing infrastructure resources for the system. It deals with technical aspects, such as database access, external connections, integrations with external systems, among others.

Services Layer: The services layer houses the application's business logic. It coordinates the operations between the different entities of the domain, implementing the system's use cases and business rules.

API Layer: The API layer is responsible for exposing the system's services through an application programming interface (API). It receives requests from clients and directs calls to the appropriate services, returning the corresponding responses.

Web Layer: The web layer is responsible for the system's user interface (UI). It uses ASP.NET Core MVC to create the pages and manage user interaction. This layer allows data presentation and interaction with the system through forms, buttons, and other graphical interfaces.

## Features

- Add clients: Allows you to add information about clients, such as name, address, and contact.
- Remove clients: Enables you to remove customers from the system.
- Add collaborators: Allows you to add information about the collaborators, such as name, position, and department.
- Remove collaborators: Enables you to remove collaborators from the system.

## Configuration/Use

- Make sure you have the .NET 7.0 SDK installed on your machine.
- Clone this repository.
- Open the project in Visual Studio or your preferred IDE.
- Set up the connection to the MySQL database in the appsettings.json file, providing the correct information for the "ConnectionString" property.
- Run the database creation script in MySQL to create the required structure.
- Compile and run the project.

## Contribution

Contributions are welcome! If you have any suggestions, bug fixes or improvements for this project, feel free to create a pull request.

## License

This project is licensed under the MIT License.

