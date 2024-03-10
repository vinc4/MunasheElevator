using MunasheElevator.Elevator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MunasheElevator.Interfaces
{
    public interface IUserInputHandler
    {
        (int numElevators, int maxFloor) GetElevatorAndFloorDetails();
        string GetUserInput();
        Request GetAndValidateRequest(IValidator validator, IDispatcher dispatcher, IDisplay display);
        int GetMaxFloor(); // Optional method for retrieving user-entered maximum floor
    }
}
