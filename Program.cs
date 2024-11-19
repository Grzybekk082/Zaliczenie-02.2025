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
                Console.WriteLine();
                bool isCorect = AccountAcces.LogIn(login, password);
                if (isCorect)
                {
                    Console.WriteLine("taki użytkownik istnieje");
                    DataAndFilesManagement.DirectoriesCreator();
                    DataAndFilesManagement.DeleteUnnecessaryDirectories();
                    break;
                }
                if(modulo==0)
                {
                    Console.WriteLine("Nieudane 3 próby, kara czasowa 30s.");
                    Console.WriteLine("Nie masz konta? załóż je, wpsiz 'TAK'");
                    if (Console.ReadLine() == "TAK")
                    {
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
    }
}
