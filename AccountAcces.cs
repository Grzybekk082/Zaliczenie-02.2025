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
        

        
        AccountAcces(string name, string surename, string password, string login)
        {
            userName = name;
            userSurename = surename;
            userPassword = password;
            userLogin = login;
        }
        internal string AccountCreator
        static internal bool LogIn(string login, string password)
        {

            string directoryPath =Path.Combine( "C:\\Users\\dell\\source\\repos\\Zaliczenie 02.2025\\Accounts");
            string[] equals = Directory.GetFiles(directoryPath);

            string inputLogin = login,
                   inputPassword = password,
                   corectLogin,
                   corectPassword;

            bool isCorest=false;

            for (int i = 1;i<=equals.Length;i++)
            {
                string pathUsers = $"{directoryPath}\\user{i}.txt";
                StreamReader sr = new StreamReader(pathUsers);
                corectLogin=sr.ReadLine();
                corectPassword=sr.ReadLine();

                if(corectLogin.Equals(inputLogin)&&corectPassword.Equals(inputPassword))
                {
                    isCorest = true;
                }
                else
                {
                    if( i==equals.Length)
                    {
                        break;
                    }
                    continue;
                }
            }
            return isCorest;
        }

        

    }
}
