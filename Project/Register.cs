
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstApp
{
    internal class Register
    {
        public static User AddUser(List<User> users)
        {
            Console.WriteLine("Account Registration");
            Console.WriteLine("--------------------");
            // Prompt the user for their username and password
            Console.WriteLine("Enter your username:");
            string username = Console.ReadLine();
            // promt for password
            Console.WriteLine("Enter your password:");
            string password = Console.ReadLine();
            //promt user role
            Console.WriteLine("Enter User Role (0 for Admin, 1 for Player):");
            int role = int.Parse(Console.ReadLine());

            // creating object
            User newUser = new User();

            // store username, password and role 
            newUser.Username = username;
            newUser.Password = password;
            newUser.Role = role;

            // append to list, add to memoory list and persist to users.json
            users.Add(newUser);
            UserManager.saveUsersToFile(users);
            return newUser;

        }

    }
}