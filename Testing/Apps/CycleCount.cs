using FAST_Framework.Forms;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace FAST_Framework.Apps
{
    class CycleCount
    {
        public static void test1()
        {
            Prompt.PressSearchButton();
            Thread.Sleep(1000);
            Prompt.InputText("DFW");
            Thread.Sleep(4000);
            Prompt.PressNextButton();
            ListView.ClickItemNumber(0);
            Prompt.PressNextButton();
        }
    }
}
