using MunasheElevator.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MunasheElevator.Elevator
{
    public class UserInputHandler : IUserInputHandler
    {
        public (int numElevators, int maxFloor) GetElevatorAndFloorDetails()
        {
            int numElevators, maxFloor;
            Console.WriteLine("Number of elevators:");
            numElevators = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Max Floor:");
            maxFloor = Convert.ToInt32(Console.ReadLine());

            return (numElevators, maxFloor);
        }

        public string GetUserInput()
        {
            return Console.ReadLine();
        }

        public Request GetAndValidateRequest(IValidator validator, IDispatcher dispatcher, IDisplay display)
        {
            string input;
            do
            {
                // Display the menu
                display.Display("-------------------------", ConsoleColor.Blue);
                display.Display("Operations:", ConsoleColor.Blue);
                display.Display("(1) Status: prints status", ConsoleColor.Blue);
                display.Display("(2) Request: requests an elevator ride", ConsoleColor.Blue);
                display.Display("(3) Exit: closes the program", ConsoleColor.Blue);
                display.Display("Next command: ", ConsoleColor.Green);

                input = Console.ReadLine();

                switch (input.ToUpper())
                {
                    case "STATUS":
                    case "1":
                        foreach (var elevator in dispatcher.Elevators)
                        {
                            elevator.DisplayStatus();
                        }
                        break;

                    case "REQUEST":
                    case "2":
                        Console.WriteLine("Which floor are you on?");
                        int callingFloor = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Which floor are going to?");
                        int destinationFloor = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("How many persons?");
                        int occupants = Convert.ToInt32(Console.ReadLine());

                        Request request = new Request(occupants, callingFloor, destinationFloor);
                        if (validator.IsValid(request))
                        {
                            Task.Run(async () => dispatcher.AddUnprocessedCallRequest(request));
                        }
                        else
                        {
                            display.Display("Invalid Request!", ConsoleColor.Red);
                        }
                        break;

                    case "EXIT":
                    case "3":
                        return null;

                    default:
                        display.Display("Invalid command!", ConsoleColor.Red);
                        break;
                }
            } while (input.ToUpper() != "EXIT" && input != "3");

            return null;
        }

        public int GetMaxFloor()
        {
            Console.WriteLine("Enter the maximum floor:");
            return Convert.ToInt32(Console.ReadLine());
        }
    }
}
