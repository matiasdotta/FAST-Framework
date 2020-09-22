using FAST_Framework.Forms;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace FAST_Framework.Apps
{
    class LotInquiry
    {
        public static void TestRun()
        {
            Driver.GetDriver().Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);

            Methods.OpenApp("Lot");

            ExcelUtil.PopulateInCollection(Config.XLPath);

            for (int i = 0; i < ExcelUtil.numberOfTests; i++)
            {
                var testData = ExcelUtil.ReadTestCase(i + 1).testValues;

                if (testData[0] != "")
                {
                    Menu.OpenMenuAndSelect("Select Organization");
                    ListView.ClickItemByText($"Organization: {testData[0]}");
                }

                if (testData[1] != "")
                    Prompt.InputTextAndEnter(testData[1]);
                else
                    continue;

                if (!DisplayMessages.IsDisplayMessage())
                {
                    if (testData[2] != "")
                        DisplayInfo.ClickDisplayButton(testData[2]);
                }
                else
                {
                    DisplayMessages.CLickOkButton();
                    continue;
                }

                if (Methods.IsDisplayMessage())
                    DisplayMessages.CLickOkButton();

                Menu.OpenMenuAndSelect("Cancel");

            }

            Menu.OpenMenuAndSelect("Exit Transaction");

            return;
        }
    }
}
