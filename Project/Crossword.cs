
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

            //step 1: creating the outer array (The rows container)
            crossword.Grid = new char[crossword.Rows][];  //  Jagged array

            for (int row = 0; row < crossword.Rows; row++) //step 2 create each inner array
            {
                crossword.Grid[row] = new char[crossword.Columns];  //  Initialize each row
                for (int column = 0; column < crossword.Columns; column++)
                {
                    crossword.Grid[row][column] = '*';  // step 3 fill every cell block with the symbol *
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
            //Display grid that players will view and show '_'
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
                        displayGrid[row][column] = GridSymbols.Empty; // mark cell with '*'
                    }
                    else
                    {
                        displayGrid[row][column] = GridSymbols.Blank; // mark cell with '_'
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
                    if (row == cursorRow && column == cursorColumn) //track where player is
                    {
                        Console.ForegroundColor = ConsoleColor.Green; //highlight cursor
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

                    case ConsoleKey.C:
                        CheckAnswers(crossword, displayGrid);
                        break;

                    case ConsoleKey.R:
                        RevealAnswers(crossword, displayGrid);
                        break;

                    default:
                        //Checks if the key pressed is a letter
                        if (char.IsLetter(keyPress.KeyChar))
                        {
                            //onlw allow letters to be entered into the grid
                            if (displayGrid[cursorRow][cursorColumn] != GridSymbols.Empty)
                            {
                                //making sure letters are uppercase
                                displayGrid[cursorRow][cursorColumn] = char.ToUpper(keyPress.KeyChar);

                                if (cursorColumn < crossword.Columns - 1)
                                {
                                    cursorColumn++;
                                }
                            }
                        }
                        break;

                }
                DisplayGrid(displayGrid, cursorRow, cursorColumn);

            }
        }

        public static void CheckAnswers(Crossword_Class crossword, char[][] displayGrid)
        {
            int correct = 0;
            int incorrect = 0;
            int unanswered = 0;

            for(int row = 0; row < crossword.Rows; row++)
            {
                for (int column = 0; column < crossword.Columns; column++)
                {
                    // make sure empty skill, dont check
                    if (crossword.Grid[row][column] == GridSymbols.Empty)
                        continue;

                    //skip block player hasnt guessed yet
                    if (displayGrid[row][column] == GridSymbols.Blank)
                    {
                        unanswered++;
                    }
                    // if guess is a match
                    else if (displayGrid[row][column] == crossword.Grid[row][column])
                    {
                        correct++;
                    }
                    //if guess is wrong
                    else
                    {
                        incorrect++;
                    }
                }
            }
            //answers revealed 

            Console.Clear();
            Console.WriteLine("=== Answer Report ===");
            Console.WriteLine($"Correct: {correct}");
            Console.WriteLine($"Incorrect: {incorrect}");
            Console.WriteLine($"Unanswered: {unanswered}");

            if (incorrect == 0 && unanswered == 0)
            {
                Console.WriteLine("Completed it mate");
            }
            else
            {
                Console.WriteLine("Keep going! Press any key to continue...");
            }
            Console.ReadKey(true);
        }

        public static void RevealAnswers (Crossword_Class crossword, char[][] displayGrid)
        {
            for (int row = 0; row < crossword.Rows; row++)
            {
                for (int column = 0; column < crossword.Columns; column++)
                {
                    //add all letters onto the main display grid
                    if (crossword.Grid[row][column] != GridSymbols.Empty)
                    {
                        displayGrid[row][column] = crossword.Grid[row][column];
                    }
                }
            }

            Console.Clear();
            Console.WriteLine("=== Revealed Answers ===");
            DisplayGrid(displayGrid, -1, -1);
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey(true);
        }
        


    }
}
