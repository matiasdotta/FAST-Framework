using FAST_Framework.Apps;
using System;
using System.Text;

namespace FAST_Framework
{
    public class EntryPoint
    {
        static void Main(string[] args)
        {

            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            if (!Driver.IsMCOpen())
                Methods.OpenMobileClient();
            else
                Methods.SwitchToMobileClient();
            LotInquiry.TestRun();

        }
    }
}
