
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
            Console.WriteLine("Login to your account!");
            Console.WriteLine("-----------------------");
            Console.Write("Enter your username: ");
            string username = Console.ReadLine();
            Console.Write("Enter your password: ");
            string password = Console.ReadLine();
            for (int currentindex = 0; currentindex < users.Count; currentindex++)
            {
                if (users[currentindex].Username == username && users[currentindex].Password == password)
                {
                    if (users[currentindex].Role == 0)
                    {
                        Console.WriteLine("Welcome Admin!");
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
            Console.WriteLine("Invalid username or password. Please try again.");
            return null;
        }
    }
}