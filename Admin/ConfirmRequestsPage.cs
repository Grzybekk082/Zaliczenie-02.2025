﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Zaliczenie_02._2025.Admin.ConfirmRequestsOptions;
using Zaliczenie_02._2025.Classes;

namespace Zaliczenie_02._2025.Admin
{
    internal class ConfirmRequestsPage:Page
    {
        internal override void Display(Stack<Page> navigationStack)
        {
            for(; ; )
            {
                Console.Clear();
                Console.WriteLine("wybierz prośbę");
                Console.WriteLine();
                for (int i = 0; i < NewUsersRequests.ReturnRequestNumber(); i++)
                {

                    string file = Path.GetFileName($"{NewUsersRequests.ReturnRequestList().GetValue(i)}");
                    string fileName = file.Replace(".txt", "");
                    Console.WriteLine($"{i + 1}. {fileName}");
                }
                Console.WriteLine("0. Wróć");
                int choose = int.Parse(Console.ReadLine());

                if (choose == 0)
                {
                    navigationStack.Pop();
                    Console.Clear();
                    break;
                }
                else if (choose > NewUsersRequests.ReturnRequestNumber())
                {
                    Console.WriteLine("Wykroczono poza listę próśb spróbuj ponownie");
                    Thread.Sleep(2000);
                    Console.Clear();
                    continue;
                }
                else
                {
                    navigationStack.Push(new UserRequestPage(choose-1));
                    Console.Clear();
                    break;
                }
            }


        }
 
    }

}

