using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstApp
{
    internal class Crossword_Class
    {
        public string Title { get; set; }
        public int Rows { get; set; }
        public int Columns { get; set; }
        public List<Clue_Class> Clues { get; set; }

        public char[][] Grid { get; set; }  //  Change from char[,] to char[][]
    }
}