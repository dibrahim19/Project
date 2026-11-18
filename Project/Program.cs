using MyFirstApp;

try
{


    // Making sure that JSON files exist on disk
    UserManager.UserFileExistanceCheck();
    List<User> users = UserManager.loadUsersFromFile();

    // If no users exist, create a default admin account
    if (users.Count == 0)
    {
        User defaultAdmin = new User();
        defaultAdmin.Username = "admin";
        defaultAdmin.Password = "admin123";
        defaultAdmin.Role = 0; // 0 = Admin
        users.Add(defaultAdmin);
        UserManager.saveUsersToFile(users);
        Console.WriteLine("Default admin account created.");
        Console.WriteLine("Username: admin | Password: admin123");
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey(true);
    }

    // Loading saved data into memory
    UserManager.ClueFileExistanceCheck();
    Clue.Clues = UserManager.LoadCluesFromFile();

    UserManager.CrosswordFileExistanceCheck();
    Crossword.Crosswords = UserManager.LoadCrosswordsFromFile();

    bool isRunning = true;

    while (isRunning)
    {
        User user = Login.UserLogin(users);
    }
}
catch (Exception ex)
{
    Console.WriteLine("Application failed to load. Please check your data files");
    Console.ReadKey(true);
}