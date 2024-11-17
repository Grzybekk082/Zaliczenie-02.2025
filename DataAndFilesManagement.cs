using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zaliczenie_02._2025
{
    internal class DataAndFilesManagement 
    {
        static string pathOfDirectory = Path.Combine("C:\\Users\\dell\\source\\repos\\Zaliczenie 02.2025\\Accounts\\usersFiles");
        static string pathOfUsers = Path.Combine();
        static int usersEqual= AccountAcces.equals;
        static int directoryEqual=Directory.GetDirectories(pathOfDirectory).Length;

        static internal void DirectoriesCreator()
        {

            for(int i = 1; i <= usersEqual; i++)
            {

                var t1=AccountAcces.ReturnInfo(i);
                if (Directory.Exists($"{pathOfDirectory}\\{t1.Item1}_{t1.Item2}"))
                {
                    continue;
                }
                else
                {
                    Directory.CreateDirectory($"{pathOfDirectory}\\{t1.Item1}_{t1.Item2}");

                }
            }

        }

        static internal void CheckDirectories()
        {


            string[] directories = Directory.GetDirectories(pathOfDirectory);


            for (int i = 0;i<=directoryEqual-1;i++)
            {
                for(int j = 1;j<=usersEqual;j++)
                {
                    var t1 = AccountAcces.ReturnInfo(j );
                    if (directories[i].Equals($"{pathOfDirectory}\\{t1.Item1}_{t1.Item2}"))
                    {
                        continue;
                    }
                    else
                    {
                        Directory.Delete(directories[i]);
                    }

                    Console.WriteLine($"{i}{directories[i]}");
                }

            }
            //Do wyjaśnienia czymu metoda usuwa jedno z kont.
        }
    }
}
