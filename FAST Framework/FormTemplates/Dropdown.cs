using System;
using System.Collections.Generic;
using System.Text;

namespace FAST_Framework.FormTemplates
{
    public class Dropdown
    {
        public static void OpenDropdown()
        {
            Methods.OpenDropdown();
        }
        public static void ClickItemNumber(int n)
        {
            Methods.ClickDropDownItemByPosition(n);
        }

        public static void ClickItemByName(string name)
        {
            Methods.ClickDropDownItemByName(name);
        }

        public static void OpenMenu()
        {
            Methods.OpenMenu();
        }
        public static void PressNextButton()
        {
            Methods.ClickImageButton("arrowright");
        }

        public static void PressBackButton()
        {
            Methods.ClickImageButton("arrowleft");
        }
    }
}
