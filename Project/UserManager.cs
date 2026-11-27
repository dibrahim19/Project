
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

        // save a single crossword to its own file named after the crossword title
        public static void saveCrosswordsToFile(Crossword_Class crossword)
        {
            string filename = crossword.Title + ".json";
            string json = JsonSerializer.Serialize(crossword);
            File.WriteAllText(filename, json);
        }

        // Load all individual crossword files from disk (excludes users.json and clues.json)
        public static List<Crossword_Class> LoadAllCrosswordsFromFiles()
        {
            List<Crossword_Class> crosswords = new List<Crossword_Class>();

            List<string> files = Directory.GetFiles(".", "*.json")
                .Where(f => f != ".\\users.json" && f != ".\\clues.json")
                .ToList();

            foreach (string file in files)
            {
                string json = File.ReadAllText(file);
                Crossword_Class crossword = JsonSerializer.Deserialize<Crossword_Class>(json);
                crosswords.Add(crossword);
            }

            return crosswords;
        }
    }
}