using AP204_Console_Project.Helpers;
using AP204_Console_Project.Services;
using System;

namespace AP204_Console_Project
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to our Cinema");
            int selection;
            do
            {
                Console.WriteLine("1. Create Hall");
                Console.WriteLine("2. Edit Hall");
                Console.WriteLine("3. Get all halls");
                Console.WriteLine("4. Get all seats");
                Console.WriteLine("5. Reserve");
                Console.WriteLine("0. Exit");
                bool result = int.TryParse(Console.ReadLine(), out selection);
                Console.Clear();
                if (result)
                {
                    switch (selection)
                    {
                        case 1:
                            MenuServices.CreateHallMenu();
                            break;
                        case 2:
                            MenuServices.EditHallMenu();
                            break;
                        case 3:
                            MenuServices.GetAllHallsMenu();
                            break;
                        case 4:
                            MenuServices.GetAllSeatsMenu();
                            break;
                        case 5:
                            MenuServices.ReserveMenu();
                            break;
                        default:
                            break;
                    }
                }

            } while (selection != 0);
        }
    }
}
