
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstApp
{

    internal class Login
    {

        public static User UserLogin(List<User> users)
        {
            // welcome user to login page
            Console.WriteLine("Login to your account!");
            Console.WriteLine("-----------------------");
            Console.Write("Enter your username: ");
            string username = Console.ReadLine();
            Console.Write("Enter your password: ");
            string password = Console.ReadLine();
            // starting a loop to check every user object in the list of users to see if the username and password match
            for (int currentindex = 0; currentindex < users.Count; currentindex++)
            {
                // checking if the username and password match the current user object in the list
                if (users[currentindex].Username == username && users[currentindex].Password == password)
                {
                    // if the username and password match, check the role of the user and display the appropriate menu
                    if (users[currentindex].Role == 0)
                    {
                        // if the user is an admin, display the admin menu
                        Console.WriteLine("Welcome Admin!");
                        // call the AdminMenu method from the Menu class and pass in the list of users
                        Menu.AdminMenu(users);
                    }
                    else if (users[currentindex].Role == 1)
                    {
                        Console.WriteLine("Welcome Player!");
                        Menu.PlayerMenu();
                    }
                    return users[currentindex];
                }
            }
            // error messaage 
            Console.WriteLine("Invalid username or password. Please try again.");
            return null;
        }
    }
}