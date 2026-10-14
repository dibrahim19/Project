using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstApp
{
    internal class ViewClues
    {
        public void DisplayClues()
        {
            if (Clue.Clues.Count == 0)
            {
                Console.WriteLine("No clues available.");
                return;
            }
            Console.WriteLine("List of Clues:");
            foreach (var clue in Clue.Clues)
            {
                Console.WriteLine($"Word: {clue.Word}, Hint: {clue.Hint}, Direction: {clue.Direction}, Row: {clue.Row}, Column: {clue.Column}");
            }
        }
    }
}

