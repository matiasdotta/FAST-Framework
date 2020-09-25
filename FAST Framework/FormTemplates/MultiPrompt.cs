using System;
using System.Collections.Generic;
using System.Text;

namespace FAST_Framework.FormTemplates
{
    public class MultiPrompt
    {
        public static void InputTextOnPrompNumber(string text, int promptNumber)
        {
            Methods.EnterTextValue(text, false, "txtPrompt"+promptNumber.ToString());
        }

        public static void PressButtonByName(string button)
        {
            Methods.ClickButtonByClass("Button", button);
        }

        public static void OpenMenu()
        {
            Methods.OpenMenu();
        }
        /// <summary>
        /// Convert a string into a string list searching for "\n"
        /// </summary>
        /// <param name="lines">String to format</param>
        /// <returns>Sloud.comting list</returns>
        public static List<string> StringToList(string lines)
        {
            List<string> list = new List<string>();

            foreach (var line in lines.Split('\n'))
            {
                list.Add(line);
            }
            return list;
        }
    }
}
