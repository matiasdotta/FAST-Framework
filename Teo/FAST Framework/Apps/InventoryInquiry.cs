using FAST_Framework.Forms;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace FAST_Framework.Apps
{
    class InventoryInquiry
    {
        public static void Test1()
        {
            Menu.Select("Subinventory");
            Thread.Sleep(2000);
            Prompt.InputTextAndEnter("203NONCONF");
            Thread.Sleep(8000);
            ListView.ClickItemByText("ARC-274697");
            Thread.Sleep(7000);
            ListView.ClickItemNumber(0);
            Thread.Sleep(8000);
            //string asd = DisplayInfo.GetValueFor("Locator");
            ListView.OpenMenu();
            Thread.Sleep(6000);
            Menu.Select("Exit");
            return;
        }
    }
}
