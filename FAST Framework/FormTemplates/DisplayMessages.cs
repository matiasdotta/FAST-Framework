using System;
using System.Collections.Generic;
using System.Text;

namespace FAST_Framework.FormTemplates
{
    public class DisplayMessages
    {
        public static string GetDisplayMessage()
        {
            return Methods.GetDisplayMessage();
        }

        public static void PressButton()
        {
            Methods.ClickButtonByClass("Button","OK");
            return;
        }
    }
}