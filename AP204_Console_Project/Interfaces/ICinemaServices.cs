using AP204_Console_Project.Helpers;
using AP204_Console_Project.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AP204_Console_Project.Interfaces
{
    interface ICinemaServices
    {
        List<Hall> Halls { get; }
        string CreateHall(byte row, byte col, Categories category);
        void EditHall(string oldNo,string newNo);
        void GetAllHalls();
        void GetAllSeats(string no);
        void Reserve(byte row, byte col, string no);
    }
}
