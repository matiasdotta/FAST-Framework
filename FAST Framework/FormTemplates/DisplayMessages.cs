using System;
using System.Collections.Generic;
using System.Text;

namespace FAST_Framework.Forms
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

/*public static void ClickButton(string buttonText, string className = "ButtonAppControl")
{
    Sleep(500);

    var buttons = session.FindElementsByClassName(className);

    for (int i = 0; i < buttons.Count; i++)
    {
        var buttonItems = buttons[i].FindElementsByTagName("Button");

        for (int j = 0; j < buttonItems.Count; j++)
        {
            if (buttonItems[j].Text.Contains(buttonText))
            {
                buttonItems[j].Click();
                return;
            }
        }
    }
    ActivityCI.Sleep(500);
}*/