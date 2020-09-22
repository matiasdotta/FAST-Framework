using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace FAST_Framework.Forms
{
    class Menu
    {
        public static void OpenMenuAndSelect(string button)
        {
            Methods.OpenMenu();
            Select(button);
        }
        public static void Select(string button) 
        {
            Methods.ClickButtonByClass("Button", button);
            return;
        }
    }
}
