using System;
using System.Collections.Generic;
using System.Text;

namespace FAST_Framework.Forms
{
    public class DisplayInfo
    {
        
        public static void PressButton(string button)
        {
            Methods.ClickButtonByClass("Button", button);
            return;
        }
        public static void OpenMenu()
        {
            Methods.OpenMenu();
            return;
        }

        public static string GetValueFor(string field)
        {
            return Methods.GetValueFor(field);
        }
    }
}
