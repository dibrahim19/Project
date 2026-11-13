// Create Users

using MyFirstApp;

//Making sure that JSON files exist on disk
UserManager.UserFileExistanceCheck();
List<User> users = UserManager.loadUsersFromFile();
UserManager.saveUsersToFile(users);

//loading saved data into memory
UserManager.ClueFileExistanceCheck();
Clue.Clues = UserManager.LoadUsersFromFile();

UserManager.CrosswordFileExistanceCheck();
Crossword.Crosswords = UserManager.LoadCrosswordsFromFile();  // ⬅️ Load INTO static list

bool isLoggedIn = true;

while (isLoggedIn)
{

    User User = Login.UserLogin(users);

}
