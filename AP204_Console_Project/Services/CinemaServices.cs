using AP204_Console_Project.Helpers;
using AP204_Console_Project.Interfaces;
using AP204_Console_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AP204_Console_Project.Services
{
    class CinemaServices : ICinemaServices
    {
        private List<Hall> _halls = new List<Hall>();
        public List<Hall> Halls => _halls;

        public string CreateHall(byte row, byte col, Categories category)
        {
            if (row <= 0 || col <= 0)
            {
                return "Please choose valid row or column value";
            }

            Hall hall = new Hall(row, col, category);
            _halls.Add(hall);

            return hall.No;

        }

        public void EditHall(string oldNo, string newNo)
        {
            Hall hall = _halls.FirstOrDefault(h => h.No.ToLower().Trim() == oldNo.ToLower().Trim());

            if (hall != null)
            {
                Hall existedHall = _halls.FirstOrDefault(h => h.No.ToLower().Trim() == newNo.ToLower().Trim());
                if (existedHall == null)
                {
                    hall.No = newNo;
                    Console.WriteLine($"Hall's no has been succesfully changed to => {newNo.ToUpper()}");
                }
                else
                {
                    Console.WriteLine($"This hall already exist => {newNo.ToUpper().Trim()}");
                }
            }
            else
            {
                Console.WriteLine($"There is no hall => {oldNo.ToUpper().Trim()}");
            }

        }
        public void GetAllHalls()
        {
            if (_halls.Count > 0)
            {
                foreach (Hall hall in _halls)
                {
                    Console.WriteLine(hall);
                }
            }
            else
            {
                Console.WriteLine("There is no hall");
            }
        }

        public void GetAllSeats(string no)
        {
            Hall hall = _halls.FirstOrDefault(h => h.No.ToLower().Trim() == no.ToLower().Trim());

            if (hall != null)
            {
                foreach (Seat seat in hall.Seats)
                {
                    Console.WriteLine(seat);
                }
            }
            else
            {
                Console.WriteLine("Please choose valid hall no");
            }
        }

        public void Reserve(byte row, byte col, string no)
        {
            if (string.IsNullOrEmpty(no) || string.IsNullOrWhiteSpace(no))
            {
                Console.WriteLine("Please enter valid hall no");
                return;
            }
            if (row <= 0 || col <= 0)
            {
                Console.WriteLine("Please enter valid row or column value");
                return;
            }

            Hall hall = _halls.FirstOrDefault(h => h.No.ToLower().Trim() == no.ToLower().Trim());
            if (hall == null)
            {
                Console.WriteLine("Please enter valid hall no");
                return;
            }

            if (row > hall.Seats.GetLength(0) || col > hall.Seats.GetLength(1))
            {
                Console.WriteLine("Please enter valid row or column value");
                return;
            }

            if (!hall.Seats[row-1, col-1].IsFull)
            {
                hall.Seats[row - 1, col - 1].IsFull = true;
                Console.WriteLine("Seat succesfully reserved");
            }
            else
            {
                Console.WriteLine("This seat has already reserved \n Please choose another seat");
                GetAllSeats(no);
                Console.WriteLine("Please enter row value: ");
                byte row1;
                bool rowResult = byte.TryParse(Console.ReadLine(), out row1);
                Console.WriteLine("Please enter col value: ");
                byte col1;
                bool colResult = byte.TryParse(Console.ReadLine(), out col1);
                Reserve(row1, col1, no);

            }
        }
    }
}
