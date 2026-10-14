// Create Users

using MyFirstApp;

UserManager.UserFileExistanceCheck();
List<User> users = UserManager.loadUsersFromFile();
UserManager.saveUsersToFile(users);

UserManager.ClueFileExistanceCheck();
Clue.Clues = UserManager.LoadUsersFromFile();

UserManager.CrosswordFileExistanceCheck();
Crossword.Crosswords = UserManager.LoadCrosswordsFromFile();  // ⬅️ Load INTO static list

bool isLoggedIn = true;

while (isLoggedIn)
{

    User User = Login.UserLogin(users);

}
