using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Zaliczenie_02._2025.Classes;
using Zaliczenie_02._2025.User;
using Zaliczenie_02._2025.Admin;
namespace Zaliczenie_02._2025


{
    internal class Program
    {
        static void Main(string[] args)
        {
            string login, password, newName, newSurename, newPassword, newLogin;
            bool isLoginCorect=false;

            Console.WriteLine("SERVICEDESK");
            Console.WriteLine(@"/-------------------------------------\");
            Console.WriteLine("Witaj w systemie zarządzania zleceniami");
            Console.WriteLine(@"/-------------------------------------\");
            Console.WriteLine("Logowanie");
            Console.WriteLine();

            for (int i = 1;; i++)
            {
                int modulo = i % 3;
                Console.Write("Login : ");
                login = Console.ReadLine();
                Console.Write("Hasło : ");
                password = Console.ReadLine();
                Console.Clear();
                bool isCorect = AccountAcces.LogIn(login, password).Item1;
                if (isCorect)
                {
                    bool isAdmin = AccountAcces.LogIn(login, password).Item2;
                    if(isAdmin)
                    {
                        AdminInterface();
                        break;
                    }
                    else
                    {
                        UserInterface();
                        break;
                    }

                }
                if(modulo==0)
                {
                    Console.WriteLine("Nieudane 3 próby, kara czasowa 30s.");
                    Console.WriteLine("Nie masz konta? załóż je, wpsiz 'TAK'");
                    if (Console.ReadLine() == "TAK")
                    {
                        Console.Clear();
                        for (; ; )
                        {
                            Console.WriteLine(@"/-------------------------------------\");
                            Console.WriteLine($"administrator serwisu potwierdzi twoje dane.");
                            Console.WriteLine();

                            Console.WriteLine("Podaj imię : ");
                            newName = Console.ReadLine();
                            Console.WriteLine("Podaj nazwisko : ");
                            newSurename = Console.ReadLine();
                            Console.WriteLine("Utwórz hasło : ");
                            newPassword = Console.ReadLine();
                            Console.WriteLine("Utwórz login : ");
                            newLogin = Console.ReadLine();
                            Console.Clear();

                            if (!AccountAcces.IsLoginFree(newName))
                            {
                                Console.WriteLine("Login jest zajęty, spróbuj ponownie");
                                Thread.Sleep(2000);
                                Console.Clear();
                                continue;
                            }
                            else
                            {
                                NewUsersRequests nu = new NewUsersRequests(newName, newSurename, newPassword, newLogin);
                                //AccountAcces ac = new AccountAcces(newName, newSurename, newPassword, newLogin);
                                break;
                            }
                        }
                        Thread.Sleep(1000);
                    }
                    else
                    {
                        for (int j = 1; j <= 30; j++)
                        {
                            Console.WriteLine(j);
                            //Thread.Sleep(1000);
                            Console.Clear();
                        }
                    }
                }
                Console.Clear() ;
            }
            Console.ReadKey();
        }

        static void AdminInterface()
        {
            Stack<Page> navigationStack = new Stack<Page> ();
            navigationStack.Push (new MainPageAdmin());

            while (navigationStack.Count > 0)
            {
                var currentPage = navigationStack.Peek();
                currentPage.Display(navigationStack);
            }
            Console.WriteLine("Aplikacja zakończyła ");
            Thread.Sleep(2000);
        }
        static void UserInterface()
        {
            Console.WriteLine("taki użytkownik istnieje");

            DataAndFilesManagement.DirectoriesCreator();
            DataAndFilesManagement.DeleteUnnecessaryDirectories();
        }

    }
    
}
