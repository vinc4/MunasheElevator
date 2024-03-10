using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MunasheElevator.Elevator
{
    public class ElevatorStop
    {

        public ElevatorStop(int floor, int occupancyMod)
        {
            Floor = floor;
            OccupancyMod = occupancyMod;
        }
        public int Floor { get; set; }
        public int OccupancyMod { get; set; }
    }

    internal class SortedAscendingElevatorStopComparer : IComparer<ElevatorStop>
    {
        public int Compare(ElevatorStop x, ElevatorStop y)
        {
            return x.Floor.CompareTo(y.Floor);
        }
    }

    internal class SortedDescendingElevatorStopComparer : IComparer<ElevatorStop>
    {
        public int Compare(ElevatorStop x, ElevatorStop y)
        {
            return y.Floor.CompareTo(x.Floor);
        }
    }
}
