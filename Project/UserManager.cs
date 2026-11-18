
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MyFirstApp
{
    internal class UserManager
    {
        public static void UserFileExistanceCheck()
        {
            if (!File.Exists("users.json"))
            {
                File.WriteAllText("users.json", "[]");

            }
        }
        public static void saveUsersToFile(List<User> users)
        {
            string json = JsonSerializer.Serialize(users);
            File.WriteAllText("users.json", json);
        }
        public static List<User> loadUsersFromFile()
        {
            string json = File.ReadAllText("users.json");

            List<User> users = JsonSerializer.Deserialize<List<User>>(json);

            return users;
        }

        //check if file exists
        public static void ClueFileExistanceCheck()
        {
            if (!File.Exists("clues.json"))
            {
                File.WriteAllText("clues.json", "[]");
            }
        }
        //saves users to new file called clues.json
        public static void saveCluesToFile(List<Clue_Class> clues)
        {
            string json = JsonSerializer.Serialize(clues);
            File.WriteAllText("clues.json", json);
        }
        //load users function to load clues from clues.json
        public static List<Clue_Class> LoadCluesFromFile()
        {
            string json = File.ReadAllText("clues.json");
            List<Clue_Class> clues = JsonSerializer.Deserialize<List<Clue_Class>>(json);
            return clues;
        }

        public static void CrosswordFileExistanceCheck()
        {
            if (!File.Exists("crosswords.json"))
            {
                File.WriteAllText("crosswords.json", "[]");
            }
        }

        public static void saveCrosswordsToFile(List<Crossword_Class> crosswords)
        {
            string json = JsonSerializer.Serialize(crosswords);
            File.WriteAllText("crosswords.json", json);
        }

        public static List<Crossword_Class> LoadCrosswordsFromFile()
        {
            string json = File.ReadAllText("crosswords.json");
            List<Crossword_Class> crosswords = JsonSerializer.Deserialize<List<Crossword_Class>>(json);
            return crosswords;
        }
    }
}