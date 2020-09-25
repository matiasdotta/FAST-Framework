using System;
using System.Collections.Generic;
using System.Text;

namespace FAST_Framework.FormTemplates
{
    public class ListView
    {
        public static void ClickItemNumber(int n)
        {
            Methods.ClickListItemByPos(n);
        }

        public static void ClickItemByText(string name)
        {
            Methods.ClickListItemByName(name);
        }

        public static void OpenMenu()
        {
            Methods.OpenMenu();
            return;
        }
    }
}
