using AP204_Console_Project.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace AP204_Console_Project.Models
{
    class Hall
    {
        public string No { get; set; }
        private static int count = 1;
        public Categories Category { get; set; }
        public Seat[,] Seats { get; set; }

        public Hall(byte row, byte col, Categories category)
        {
            switch (category)
            {
                case Categories.Sci_Fi:
                    No = $"SF-{count}";
                    break;
                case Categories.Comedy:
                    No = $"C-{count}";
                    break;
                case Categories.Thriller:
                    No = $"T-{count}";
                    break;
                case Categories.Drama:
                    No = $"D-{count}";
                    break;
                case Categories.Action:
                    No = $"A-{count}";
                    break;
                case Categories.Horror:
                    No = $"H-{count}";
                    break;
                default:
                    break;
            }
            Category = category;

            Seats = new Seat[row, col];
            for (byte i = 0; i < row; i++)
            {
                for (byte j = 0; j < col; j++)
                {
                    Seat seat = new Seat((byte)(i +1),(byte)(j + 1));
                    Seats[i, j] = seat;
                }
            }
            count++;
        }


        public override string ToString()
        {
            return $"Hall no: {No}, Category: {Category}";
        }
    }
}
