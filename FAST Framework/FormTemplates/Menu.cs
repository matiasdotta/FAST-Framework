using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace FAST_Framework.FormTemplates
{
    public class Menu
    {
        public static void Select(string button) 
        {
            Thread.Sleep(1000);
            Methods.ClickButtonByClass("Button", button);
            return;
        }
    }
}
