using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zaliczenie_02._2025.Classes;

namespace Zaliczenie_02._2025.Admin
{
    internal class ConfirmRequests:Page
    {
        internal override void Display(Stack<Page> navigationStack)
        {
            Console.WriteLine("wybierz prośbę");
            Console.WriteLine();
            for (int i = 0; i < NewUsersRequests.ReturnRequestNumber(); i++)
            {

                string file = Path.GetFileName($"{NewUsersRequests.ReturnRequestList().GetValue(i)}");
                string fileName = file.Replace(".txt", "");
                Console.WriteLine($"{i + 1}. {fileName}");
            }
            Console.WriteLine("0. Wróć");
            int choose=int.Parse( Console.ReadLine());

            switch (choose)
            {
                case 0:
                    navigationStack.Pop();
                    Console.Clear();
                    break;
            }
        }

}
}
