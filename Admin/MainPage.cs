using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zaliczenie_02._2025.Classes;
using Zaliczenie_02._2025.User;
using Zaliczenie_02._2025.Admin;
using System.IO;

namespace Zaliczenie_02._2025.Admin
{
    internal class MainPageAdmin:Page
    {
        internal override void Display(Stack<Page> navigationStack)
        {
            DataAndFilesManagement.DirectoriesCreator();
            DataAndFilesManagement.DeleteUnnecessaryDirectories();

            Console.WriteLine("Ten użytkownik jest Administratorem serwisu");
            Console.WriteLine();
            Console.WriteLine("1. Potwierdz nowych użytkowników.");
            Console.WriteLine("0. Wyjdź");
            Console.WriteLine();
            Console.Write("Opcja : ");
            int option = int.Parse(Console.ReadLine());

            switch (option)
            {
                case 1:
                    navigationStack.Push(new ConfirmRequests());
                    Console.Clear();
                    break;

                    //reszta opcji

                case 0:
                    navigationStack.Clear();
                    Console.Clear();
                    break;

            }
        }
    }
}
