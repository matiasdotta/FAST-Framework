using System;
using System.Collections.Generic;
using System.Text;

namespace FAST_Framework.Forms
{
    class DisplayInfo
    {
        public static string GetValueFor(string field)
        {
            var driver = Driver.GetDriver();
            var displayedInfo = driver.FindElementByAccessibilityId("lblInfo");
            var value = displayedInfo.Text.Split(field)[1];
            value = value.Split('\r')[0];
            return value;
        }

        public static void ClickDisplayButton(string buttonText)
        {
            Methods.ClickButtonByClass("Button", buttonText);
        }

    }
}
