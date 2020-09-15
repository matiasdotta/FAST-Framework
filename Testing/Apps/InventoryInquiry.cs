using FAST_Framework.Forms;
using NUnit.Framework;
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
            //ExcelUtil.PopulateInCollection(Config.XLPath);
            //var a = ExcelUtil.ReadData(1, "Test1");
            Menu.Select("Subinventory");
            Prompt.InputTextAndEnter("203NONCONF");
            ListView.ClickItemByText("ARC-274697");
            ListView.ClickItemNumber(0);
            var locator = DisplayInfo.GetValueFor("Locator:");
            var subinventory = DisplayInfo.GetValueFor("Subinventory:");
            Methods.ExitApplication();
            return;
        }
    }
}
