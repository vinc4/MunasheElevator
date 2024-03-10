

using Microsoft.Extensions.DependencyInjection;
using MunasheElevator.Elevator;
using MunasheElevator.Interfaces;


class Program
{
    static async Task Main(string[] args)
    {
        // Setup DI container
        var serviceProvider = new ServiceCollection()
            .AddTransient<IDisplay, MDisplay>()
            .AddTransient<IValidator, RequestValidator>()
            .AddTransient<IDispatcher, Dispatcher>()
            .AddTransient<IUserInputHandler, UserInputHandler>()
            .BuildServiceProvider();


        // Resolve dependencies
        var display = serviceProvider.GetService<IDisplay>();
        var dispatcher = serviceProvider.GetService<IDispatcher>();
        var userInputHandler = serviceProvider.GetService<IUserInputHandler>();

        var (numElevators, maxFloor) = userInputHandler.GetElevatorAndFloorDetails();

        await Task.Run(async () => dispatcher.ProcessRequests());
        // Add elevators to the dispatcher
        for (int i = 0; i < numElevators; i++)
        {
            Elevator elevator = new Elevator("Elevator_" + i, 0, display);
            dispatcher.AddElevator(elevator);
        }

        // Create request validator
        var requestValidator = new RequestValidator(0, maxFloor, 10);


        // Get and validate requests
        while (true)
        {
            Request request = userInputHandler.GetAndValidateRequest(requestValidator, dispatcher, display);
            if (request == null)
            {
                break;
            }
        }


    }
}