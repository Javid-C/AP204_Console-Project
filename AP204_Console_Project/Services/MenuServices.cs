using AP204_Console_Project.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace AP204_Console_Project.Services
{
    static class MenuServices
    {
        public static CinemaServices cinemaServices = new CinemaServices();
        public static void CreateHallMenu()
        {
            Console.WriteLine("Please enter row value: ");
            byte row;
            bool rowResult = byte.TryParse(Console.ReadLine(), out row);
            Console.WriteLine("Please enter col value: ");
            byte col;
            bool colResult = byte.TryParse(Console.ReadLine(), out col);
            Console.WriteLine("Please enter category");

            foreach (var item in Enum.GetValues(typeof(Categories)))
            {
                Console.WriteLine($"{(int)item}. {item}");
            }
            object cg;
            bool categoryResult = Enum.TryParse(typeof(Categories), Console.ReadLine(), out cg);
            if (categoryResult)
            {
                if (cg is Categories)
                {
                    Categories category = (Categories)cg;
                    string no = cinemaServices.CreateHall(row, col, category);
                    Console.WriteLine($"{no} => Hall succesfully created");
                }
            }
        }

        public static void EditHallMenu()
        {
            Console.WriteLine("Please enter hall no which you want to change");
            string oldNo = Console.ReadLine();
            Console.WriteLine("Please enter new hall no");
            string newNo = Console.ReadLine();
            cinemaServices.EditHall(oldNo, newNo);
        }

        public static void GetAllHallsMenu()
        {
            cinemaServices.GetAllHalls();
        }

        public static void GetAllSeatsMenu()
        {
            Console.WriteLine("Please enter hall no");
            string no = Console.ReadLine();
            cinemaServices.GetAllSeats(no);
        }

        public static void ReserveMenu()
        {
            Console.WriteLine("Please enter row value: ");
            byte row;
            bool rowResult = byte.TryParse(Console.ReadLine(), out row);
            Console.WriteLine("Please enter col value: ");
            byte col;
            bool colResult = byte.TryParse(Console.ReadLine(), out col);
            Console.WriteLine("Please enter hall no");
            string no = Console.ReadLine();
            cinemaServices.Reserve(row, col, no);
        }
    }
}
