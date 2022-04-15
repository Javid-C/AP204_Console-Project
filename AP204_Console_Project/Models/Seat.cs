using System;
using System.Collections.Generic;
using System.Text;

namespace AP204_Console_Project.Models
{
    class Seat
    {
        public byte Row { get; set; }
        public byte Column { get; set; }
        public bool IsFull { get; set; }
        public Seat(byte row, byte col, bool status = false)
        {
            Row = row;
            Column = col;
            IsFull = status;
        }

        public override string ToString()
        {
            return $"Row: {Row}, Column: {Column}, Status: {(IsFull ? "Full" : "Empty")}";
        }
    }
}
