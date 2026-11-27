
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstApp
{
    internal class Menu
    {
        public static void AdminMenu(List<User> users)
        {
            bool isLoggedIn = true;
            while (isLoggedIn)
            {
                Console.WriteLine("1. Create Crossword");
                Console.WriteLine("2. Add User");
                Console.WriteLine("3. Add Clue");
                Console.WriteLine("4. Play Crossword");
                Console.WriteLine("5. Load Crosswords");
                Console.WriteLine("6. Logout");
                int user_choice = int.Parse(Console.ReadLine());
                switch (user_choice)
                {
                    case 1:
                        // Play Crossword
                        Crossword_Class crossword = Crossword.CreateCrossword(Crossword.Crosswords);

                        Crossword.DisplayCrossword(crossword);

                        break;
                    case 2:
                        Register.AddUser(users);
                        break;
                    case 3:
                        if (Crossword.Crosswords.Count == 0)
                        {
                            Console.WriteLine("You must create a crossword before adding clues.");
                        }
                        else
                        {
                            Console.WriteLine("Enter the title of the crossword to add a clue to:");
                            string title = Console.ReadLine();
                            Crossword_Class target = Crossword.Crosswords.FirstOrDefault(c => c.Title == title);

                            if (target == null)
                            {
                                Console.WriteLine("No crossword found with that title.");
                            }
                            else
                            {
                                Clue.AddClue(Clue.Clues, target);
                            }
                        }
                        break;

                    case 4:
                        Crossword_Class selectedCrossword = Crossword.SelectCrossword();
                        if (selectedCrossword != null)
                        {
                            Crossword.PlayCrossword(selectedCrossword);
                        }
                        break;

                    // reload all crossword .json files from disk back into memory
                    case 5:
                        Crossword.Crosswords = UserManager.LoadAllCrosswordsFromFiles();
                        Console.WriteLine("Crosswords loaded successfully.");
                        Console.ReadKey(true);
                        break;

                    case 6:
                        isLoggedIn = false;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }
        public static void PlayerMenu()
        {
            bool IsLoggedIn = true;

            while (IsLoggedIn)
            {
                Console.WriteLine("Player Menu");
                Console.WriteLine("1. Play Crossword");
                Console.WriteLine("2. View Clue");
                Console.WriteLine("3. Logout");
                int user_choice = int.Parse(Console.ReadLine());
                switch (user_choice) 
                { 
                    case 1:
                        Crossword_Class selectedCrossword = Crossword.SelectCrossword();
                        if (selectedCrossword != null)
                        {
                            Crossword.PlayCrossword(selectedCrossword);
                        }
                        break;
                case 2:
                        // View Clue
                        ViewClues viewer = new ViewClues();
                        viewer.DisplayClues();
                        break;
                    case 3:
                        IsLoggedIn = false;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }

        }
    }
}