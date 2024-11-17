using System;
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

        static string directoryPath = Path.Combine("C:\\Users\\dell\\source\\repos\\Zaliczenie 02.2025\\Accounts");
        static int equals = Directory.GetFiles(directoryPath).Length;
        

        internal AccountAcces(string name, string surename, string password, string login)
        {
            
            userName = name;
            userSurename = surename;
            userPassword = password;
            userLogin = login;

            AccountCreator(userName, userSurename, userPassword, userLogin);
        }

        static internal bool IsLoginFree( string name)
        {
         bool isLoginOccupied = false;
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
                    isLoginOccupied = true;
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

        static internal bool LogIn(string login, string password)
        {



            string inputLogin = login,
                   inputPassword = password,
                   corectLogin,
                   corectPassword;

            bool isCorect=false;
             

            for (int i = 1;i<=equals;i++)
            {
                string pathUsers = $"{directoryPath}\\user{i}.txt";
                StreamReader sr = new StreamReader(pathUsers);
                corectLogin=sr.ReadLine();
                corectPassword=sr.ReadLine();
                sr.Dispose();
                
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
        public void AccountCreator(string name, string surename, string password, string login)
        {
                string userId = $"user{equals + 1}.txt";
                string userPath = $"{directoryPath}\\{userId}";
                string content = $"{userName}\n{userSurename}\n{userPassword}\n{userLogin}\n";

                File.AppendAllText(userPath,content);
        }


    }
}
