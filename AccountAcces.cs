﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zaliczenie_02._2025
{
       internal class AccountAcces
    {
        internal string userName, userSurename, userPassword, userLogin;

        static string directoryPath = Path.Combine("C:\\Users\\dell\\source\\repos\\Zaliczenie 02.2025\\Accounts\\usersData");
        //ścieżka do folderu z plikami "user#", przechowuje podstawowe dane logowania do konta(imie, nazwisko, login, hasło
        internal static int equals = Directory.GetFiles(directoryPath).Length;
        //Oblicza aktualną liczbę użytkownikó w folderze userData

        internal static string inputLogin,
                        inputPassword,
                        corectLogin,
                        corectPassword;

        internal AccountAcces() { }
        //Konstruktor, Pobiera od nowego użytkownika podstawowe dane logowania i wywołuje w sobie funkcję tworzącą nowe konto.
        internal AccountAcces(string name, string surename, string password, string login)
        {
            
            userName = name;
            userSurename = surename;
            userPassword = password;
            userLogin = login;

            AccountCreator(userName, userSurename, userPassword, userLogin);
        }
        
        //Metoda sprawdza, czy Login podany przez nowego użytkownika nie istnieje już w bazie, porównuje ze sobą inputLogin
        //podany przez użytkownika oraz corectLogin wyczytany z pierwszej linii w każdym pliku w folderze userData
        static internal bool IsLoginFree( string name)
        {
         bool isLoginOccupied = true;
        string inputLogin = name,
                   corectLogin;

            for (int i = 1; i <= equals; i++)
            {
                string pathUsers = $"{directoryPath}\\user{i}.txt";
                StreamReader sr = new StreamReader(pathUsers);

                corectLogin = sr.ReadLine();
                sr.Dispose();


                if (corectLogin.Equals(inputLogin))
                {
                    isLoginOccupied = false;
                }
                else
                {
                    if (i == equals)
                    {
                        break;
                    }
                    continue;
                }
            }
            return isLoginOccupied;
        }
        //metoda porównuje uzyskane z metody zwrócone wartości prawidłowego loginu i hasła z danymi wprowadzonymi przez
        //użytkownika próbującego się zalogować i jeżeli takie dane istnieją w pojedynczym pliku "user#" użytkownik zostanie prawidłowo
        //zalogowany
        static internal bool LogIn(string login, string password)
        {

            string inputLogin = login,
                   inputPassword = password,
                   corectLogin,
                   corectPassword;

            bool isCorect=false;
             

            for (int i = 1;i<=equals;i++)
            {
                (string tutleName,string tutleSurename)t1 = ReturnInfo(i);
                corectLogin=t1.tutleName;
                corectPassword=t1.tutleSurename;
                
                if(corectLogin.Equals(inputLogin)&&corectPassword.Equals(inputPassword))
                {
                    isCorect = true;
                }
                else
                {
                    if( i==equals)
                    {
                        break;
                    }
                    continue;
                }
            }
            
            return isCorect;
        }
        //Metoda mająca za zadanie jedynie utworzenie pliku .txt z nowym użytkownikiem, jest wywoływana w konstruktorze
        public void AccountCreator(string name, string surename, string password, string login)
        {
                string userId = $"user{equals + 1}.txt";
                string userPath = $"{directoryPath}\\{userId}";
                string content = $"{userName}\n{userSurename}\n{userPassword}\n{userLogin}\n";

                File.AppendAllText(userPath,content);
            
        }
        //Metoda korzystająca z tutle, zwracająca z folderu userData z plików "user#" prawidłowy login i hasło, dzięki tutle
        //można zwracać więcej wartości na raz.
        internal static (string , string )  ReturnInfo( int i)
        {

                string pathUsers = $"{directoryPath}\\user{i}.txt";
                StreamReader sr = new StreamReader(pathUsers);
                corectLogin = sr.ReadLine();
                corectPassword = sr.ReadLine();
                sr.Dispose();

            return (corectLogin,  corectPassword);
        }


    }
}
