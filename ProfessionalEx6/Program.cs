//Завдання 6

//Напишіть консольну програму, яка дозволяє користувачеві зареєструватися під «Логіном», 
//    що складається тільки з символів латинського алфавіту, і пароля, що складається з цифр і символів.
using System.Text.RegularExpressions;

namespace ProfessionalEx6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Regex regexForLogin = new Regex(@"[a-z]");
            Regex regexForPassword = new Regex(@"[\\._\\-\\/\\*\\(\\)0-9]");

            while (true)
            {
                Console.WriteLine("Enter login:");
                string login = Console.ReadLine();
                Console.WriteLine("Enter password:");
                string password = Console.ReadLine();

                if (regexForLogin.IsMatch(login) && regexForPassword.IsMatch(password))
                {
                    Console.WriteLine("Login confirmed");
                    Console.WriteLine("Password confirmed");
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid login or password");
                }


            }
        }
    }
}