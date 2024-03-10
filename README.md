##Elevator System README

Overview
This project is an elevator system built using SOLID principles and interfaces. It simulates the operation of multiple elevators in a building, handling user requests for elevator rides, and dispatching elevators to fulfill those requests efficiently.

##Design Principles

## SOLID Principles
Single Responsibility Principle (SRP): Each class has a single responsibility, focusing on a specific aspect of the system such as elevator control, user input handling, or request validation.

Open/Closed Principle (OCP): The system is designed to be open for extension but closed for modification. This is achieved by using interfaces to define contracts between components, allowing for new implementations to be added without changing existing code.

Liskov Substitution Principle (LSP): Interfaces are used to define common behavior, ensuring that any class implementing an interface can be substituted for another class implementing the same interface without affecting the correctness of the system.

Interface Segregation Principle (ISP): Interfaces are designed to be minimal and focused, containing only the methods necessary for their specific use case. This prevents classes from depending on methods they do not need, reducing coupling and improving maintainability.

Dependency Inversion Principle (DIP): Dependencies are injected into classes rather than being created internally, allowing for easier testing and flexibility in swapping out implementations. This is achieved through constructor injection and dependency injection containers.

###Components
I##nterfaces
The project utilizes interfaces to define contracts between different components of the system. This promotes loose coupling and facilitates dependency inversion, allowing for easier extension and testing.

IDisplay: Defines methods for displaying messages to the user.
IDispatcher: Represents the elevator dispatcher responsible for managing elevator requests and dispatching elevators.
IElevator: Defines methods and properties for controlling individual elevators.
IUserInputHandler: Handles user input for requesting elevator rides and providing system configuration details.
IValidator: Validates elevator ride requests to ensure they meet system requirements.
##Enums
Enums are used to represent certain states or types within the system, providing a clear and type-safe way to work with these values.

ElevatorMovementStatus: Represents the movement status of an elevator (e.g., ascending, descending, stationary).
Other enums could be used to represent elevator states, request status, etc., depending on the specific requirements of the system.
##Conclusion
By following SOLID principles and leveraging interfaces and enums, we have created a modular and extensible elevator system that is easy to maintain and test. This design allows for flexibility in adding new features or modifying existing ones without compromising the integrity of the system.
