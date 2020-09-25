using System;
using System.Collections.Generic;
using System.Text;

namespace FAST_Framework.FormTemplates
{
    public class Prompt
    {
        public static void InputTextAndEnter(string text)
        {
            Methods.EnterTextValue(text, true, "txtPromptText");
        }

        public static void InputText(string text)
        {
            Methods.EnterTextValue(text, false, "txtPromptText");
        }

        public static void PressSearchButton()
        {
            Methods.ClickImageButton("Search");
        }

        public static void PressNextButton()
        {
            Methods.ClickImageButton("arrowright");
        }

        public static void OpenMenu()
        {
            Methods.OpenMenu();
        }

        public static void PressButtonByName(string button)
        {
            Methods.ClickButtonByClass("Button", button);       
        }
        public static void ImputMultipleLines(List<string> list)
        {
            var lines = list.ToArray();
            foreach (var line in lines)
            {
                Methods.EnterTextValue(line, true, "txtPromptText");
            }
        }
    }
}
