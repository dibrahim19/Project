
using System;
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

        public static Crossword_Class SelectCrossword()
        {
            // If no crosswords exist, return null
            if (Crosswords.Count == 0)
            {
                Console.WriteLine("No crosswords available.");
                return null;
            }
            // Display available crosswords
            Console.WriteLine("Available crosswords:");
            for (int i = 0; i < Crosswords.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {Crosswords[i].Title}");
            }

            //ask user to pick crossword by number 
            Console.WriteLine("Enter the number of the crossword you want to play:");
            int choice = int.Parse(Console.ReadLine());

            //validate choice
            if (choice < 1 || choice > Crosswords.Count)
            {
                Console.WriteLine("Invalid choice.");
                return null;
            }

            //get and return the chosen crossword
            Crossword_Class SelectedCrossword = Crosswords[choice - 1];
            return SelectedCrossword;
        }

        public static char[][] BuildDisplayGrid(Crossword_Class crossword)
        {
            //create a new empty jagged arary the same size as the solution grid
            char[][] displayGrid = new char[crossword.Rows][];

            for (int row = 0; row < crossword.Rows; row++)
            {
                displayGrid[row] = new char[crossword.Columns];

                for (int column = 0; column < crossword.Columns; column++)
                {
                    //if solution grid cell is empty 
                    //mirror that in display grid
                    if (crossword.Grid[row][column] == GridSymbols.Empty)
                    {
                        displayGrid[row][column] = GridSymbols.Empty;
                    }
                    else
                    {
                        displayGrid[row][column] = GridSymbols.Blank;
                    }
                }
            }
            return displayGrid;
        }

        public static void DisplayGrid(char[][] displayGrid, int cursorRow, int cursorColumn)
        {
            Console.Clear();
            Console.WriteLine("Use Arrow keys to navigate. Type a letter to guess. Press Escape to quit");
            Console.WriteLine();

            for (int row = 0; row < displayGrid.Length; row++)
            {
                for (int column = 0; column < displayGrid[row].Length; column++)
                {
                    if (row == cursorRow && column == cursorColumn)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(displayGrid[row][column] + " ");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.Write(displayGrid[row][column] + " ");
                    }
                }
                Console.WriteLine();
            }

        }
        public static void PlayCrossword(Crossword_Class crossword)
        {
            //build the display grid from the solution grid
            char[][] displayGrid = Crossword.BuildDisplayGrid(crossword);

            //start cursor in the top left corner 
            int cursorRow = 0;
            int cursorColumn = 0;

            //draw the grid for the first time before any input 
            DisplayGrid(displayGrid, cursorRow, cursorColumn);

            //keep looping until user presses escape key
            bool playing = true;
            while (playing)
            {
                //read single keypresses instantly without waiting for enter
                ConsoleKeyInfo keyPress = Console.ReadKey(true);

                switch (keyPress.Key)
                {
                    case ConsoleKey.UpArrow:
                        if (cursorRow > 0)
                        {
                            cursorRow--;
                        }
                        break;

                    case ConsoleKey.DownArrow:
                        if (cursorRow < crossword.Rows - 1)
                        {
                            cursorRow++;
                        }
                        break;

                    case ConsoleKey.LeftArrow:
                        if (cursorColumn > 0)
                        {
                            cursorColumn--;
                        }
                        break;

                    case ConsoleKey.RightArrow:
                        if (cursorColumn < crossword.Columns - 1)
                        {
                            cursorColumn++;
                        }
                        break;

                    case ConsoleKey.Escape:
                        playing = false;
                        break;

                }
                DisplayGrid(displayGrid, cursorRow, cursorColumn);

            }
        }


    }
}
