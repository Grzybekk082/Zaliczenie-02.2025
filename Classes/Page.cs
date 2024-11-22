using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zaliczenie_02._2025.Classes;
using Zaliczenie_02._2025.User;
using Zaliczenie_02._2025.Admin;

namespace Zaliczenie_02._2025.Classes
{
    internal abstract class Page
    {
        internal abstract void Display(Stack<Page> navigationStack);
    }
}
