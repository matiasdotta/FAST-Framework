using System;
using System.Collections.Generic;
using System.Text;

namespace FAST_Framework.Forms
{
    class DisplayMessages
    {
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