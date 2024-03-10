using MunasheElevator.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MunasheElevator.Elevator
{
    public class MDisplay : IDisplay
    {
        public void Display(string message, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        void IDisplay.Display(string message)
        {
            Console.WriteLine(message);
        }

        void IDisplay.Display(string message, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }
}
