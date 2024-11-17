using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Zaliczenie_02._2025
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string login, password, newName, newSurename, newPassword, newLogin;

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
                DataAndFilesManagement.DirectoriesCreator();
                DataAndFilesManagement.CheckDirectories();
            }
            else
            { 
           
                    Console.WriteLine("Nie ma takiego użytkownika");
                    Console.WriteLine();
                for (; ; )
                {
                    Console.WriteLine(@"/-------------------------------------\");
                    Console.WriteLine($"Nie masz konta? Załóż je, \n " +
                                        $"administrator serwisu potwierdzi twoje dane.");
                    Console.WriteLine();

                    Console.WriteLine("Podaj imię : ");
                    newName = Console.ReadLine();
                    Console.WriteLine("Podaj nazwisko : ");
                    newSurename = Console.ReadLine();
                    Console.WriteLine("Utwórz hasło : ");
                    newPassword = Console.ReadLine();
                    Console.WriteLine("Utwórz login : ");
                    newLogin = Console.ReadLine();

                    if (!AccountAcces.IsLoginFree(newName))
                    {
                        Console.WriteLine("Login jest zajęty, spróbuj ponownie");
                        Thread.Sleep(2000);
                        Console.Clear();
                        continue;
                    }
                    else
                    {
                        AccountAcces ac = new AccountAcces(newName, newSurename, newPassword, newLogin);
                        break;
                    }
                }
               



            }




            Console.ReadKey();
        }
    }
}
