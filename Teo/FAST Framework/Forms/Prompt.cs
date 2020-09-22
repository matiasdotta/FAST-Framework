using System;
using System.Collections.Generic;
using System.Text;

namespace FAST_Framework.Forms
{
    class Prompt
    {
        public static void InputTextAndEnter(string text)
        {
            Methods.EnterTextValue(text, true, "txtPromptText");
            return;
        }

        public static void InputText(string text)
        {
            Methods.EnterTextValue(text, false, "txtPromptText");
            return;
        }

        public static void PressSearchButton()
        {
            Methods.ClickImageButton("Search");
            return;
        }

        public static void PressNextButton()
        {
            Methods.ClickImageButton("arrowright");
            return;
        }

        public static void OpenMenu()
        {
            Methods.OpenMenu();
            return;
        }

        public static void PressButtonByName(string button)
        {
            Methods.ClickButtonByClass("Button", button);
            return;          
        }
    }
}
