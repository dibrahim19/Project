using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MyFirstApp
{
    internal class Clue
    {
        public static List<Clue_Class> Clues = new List<Clue_Class>();

        public static Clue_Class AddClue(List<Clue_Class> Clues, Crossword_Class crossword)
        {
            Clue_Class Clue = new Clue_Class();
            Clue.CrosswordTitle = crossword.Title; // link to this crossword via title

            Console.WriteLine("Enter the word for the clue:");
            Clue.Word = Console.ReadLine().ToUpper(); //always stores letters inputted upper case

            Console.WriteLine("Enter the hint for the clue:");
            Clue.Hint = Console.ReadLine();

            Console.WriteLine("Enter the direction for the clue (across or down):");
            Clue.Direction = Console.ReadLine().ToLower();

            Console.WriteLine("Enter the row number for the clue:");
            Clue.Row = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter the column number for the clue:");
            Clue.Column = int.Parse(Console.ReadLine());

            //placing word on grid
            if (!PlaceWordInGrid(crossword, Clue))
            {
                Console.WriteLine("That word doesn't fit on the grid. Clue was not saved.");
                return null;
            }

            Clues.Add(Clue);
            UserManager.saveCluesToFile(Clues);
            UserManager.saveCrosswordsToFile(Crossword.Crosswords);
            return Clue;
        }

        private static bool PlaceWordInGrid(Crossword_Class crossword, Clue_Class clue)
        {
            int row = clue.Row;
            int column = clue.Column;

            for (int i = 0; i < clue.Word.Length; i++)
            {
                // Bounds check: does this letter still land inside the grid?
                if (row < 0 || row >= crossword.Rows || column < 0 || column >= crossword.Columns)
                {
                    return false;
                }

                //write this letter into the solution grid
                crossword.Grid[row][column] = clue.Word[i];

                //move onto the next cell
                if (clue.Direction == "across")
                {
                    column++;
                }
                else if (clue.Direction == "down")
                {
                    row++;
                }
                else
                {
                    Console.WriteLine("Direction must be 'across' or 'down'.");
                    return false;
                }
            }

            return true;
        }
    }
}