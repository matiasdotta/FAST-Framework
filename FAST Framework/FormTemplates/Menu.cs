using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace FAST_Framework.FormTemplates
{
    public class Menu
    {
        
        /// <summary>
        /// Opens the menu and selects the button specified
        /// </summary>
        /// <param name="button">Text of the button of the menu to select</param>
        public static void OpenMenuAndSelect(string button)
        {
            Methods.OpenMenu();
            Select(button);
        }

        /// <summary>
        /// Selects the button of the menu specified
        /// </summary>
        /// <param name="button">Text of the button of the menu to select</param>
        public static void Select(string button) 
        {
            Methods.ClickButtonByClass("Button", button);
            return;
        }
    }
}
