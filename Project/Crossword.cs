
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstApp
{
    internal class Crossword
    {
        public static List<Crossword_Class> Crosswords = new List<Crossword_Class>();
        public static Crossword_Class CreateCrossword(List<Crossword_Class> crosswords)
        {
            Crossword_Class crossword = new Crossword_Class();

            Console.Write("Enter the title of the crossword:");
            crossword.Title = Console.ReadLine();

            Console.Write("Enter the number of rows:");
            crossword.Rows = int.Parse(Console.ReadLine());

            Console.Write("Enter the number of columns:");
            crossword.Columns = int.Parse(Console.ReadLine());

            crossword.Grid = new char[crossword.Rows][];  // ⬅️ Jagged array
            for (int row = 0; row < crossword.Rows; row++)
            {
                crossword.Grid[row] = new char[crossword.Columns];  // ⬅️ Initialize each row
                for (int column = 0; column < crossword.Columns; column++)
                {
                    crossword.Grid[row][column] = '*';  // ⬅️ Syntax changes slightly
                }
            }

            crosswords.Add(crossword);
            UserManager.saveCrosswordsToFile(crosswords);

            return crossword;

        }
        public static void DisplayCrossword(Crossword_Class crossword)
        {
            for (int row = 0; row < crossword.Rows; row++)
            {
                for (int column = 0; column < crossword.Columns; column++)
                {
                    Console.Write(crossword.Grid[row][column] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}