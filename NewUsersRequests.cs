using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace Zaliczenie_02._2025
{
    internal class NewUsersRequests : AccountAcces
    {
        static string name, surename, password, login;
        static string path = Path.Combine($"{ProgramSupport.ActualyPathReturn()}\\Service\\Administration");

        internal NewUsersRequests() { }
        internal NewUsersRequests(string newName, string newSurename, string newPassword, string newLogin)
        {
            name = newName;
            surename = newSurename;
            password = newPassword;
            login = newLogin;
            CreateRequest();
        }

        static void CreateRequest()
        {
            string userId = $"request{ReturnUsersNumber(path) + 1}.txt";
            string userPath = $"{path}\\{userId}";
            string content = $"{name}\n{surename}";
            File.AppendAllText(userPath, content);
        }

        
        internal static string[]  ReturnRequestList()
        {
            return Directory.GetFiles(path);
        }
        internal static int ReturnRequestNumber()
        {
            return ReturnRequestList().Length;
        }
        
    }
}
