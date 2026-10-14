using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstApp
{
    internal class Clue_Class
    {
        public string CrosswordTitle { get; set; }   // NEW: links this clue to a specific crossword
        public string Word { get; set; }
        public string Hint { get; set; }

        public string Direction { get; set; }
        public int Row { get; set; }

        public int Column { get; set; }

    }
}