using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zaliczenie_02._2025
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string login, password;

            Console.WriteLine("SERVICEDESK");
            Console.WriteLine(@"/-------------------------------------\");
            Console.WriteLine("Witaj w systemie zarządzania zleceniami");
            Console.WriteLine(@"/-------------------------------------\");
            Console.WriteLine("Logowanie");
            Console.WriteLine();

            Console.Write("Login : ");
            login = Console.ReadLine();
            Console.Write("Hasło : ");
            password = Console.ReadLine();
            Console.WriteLine();
            bool isCorect = AccountAcces.LogIn(login, password);
            if (isCorect)
            {
                Console.WriteLine("taki użytkownik istnieje");
            }
            else
            { 
                Console.WriteLine("Nie ma takiego użytkownika");
                Console.WriteLine();

                Console.WriteLine(@"/-------------------------------------\");
                Console.WriteLine($"Nie masz konta? Załóż je, \n " +
                                    $"administrator serwisu potwierdzi twoje dane.");
                Console.WriteLine();

                Console.WriteLine("Podaj imię : ");
                Console.WriteLine("Podaj nazwisko : ");

            }




            Console.ReadKey();
        }
    }
}
