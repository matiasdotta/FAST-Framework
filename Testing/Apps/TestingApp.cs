using FAST_Framework;
using FAST_Framework.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Testing.Apps
{
    class TestingApp
    {
        public static List<string> lines = new List<string>();
        

        public static void Test1(Config config)
        {
            ExcelUtil.PopulateInCollection(config.XLPath);
            int n = ExcelUtil.numberOfTests;

            //Start
            for (int i = 0; i < n ; i++)
            {
                var testData = ExcelUtil.ReadTestCase(i + 1).testValues;                
               //Test Variables
                string companyName = testData[0];
                string companyAddress = testData[1];
                string notes = testData[2];
                //select first menu option
                Menu.Select("Add Company");
                //Invalid input
                Prompt.InputTextAndEnter("");
                //Read mesage
                var DisplayedText = DisplayMessages.GetDisplayMessage();
                //continue
                DisplayMessages.PressButton();
                //Input for first prompt
                Prompt.InputTextAndEnter(companyName);
                //Input for secondPrompt
                Prompt.InputTextAndEnter(companyAddress);
                //Date input defaulted
                Prompt.PressNextButton();
                //input multiple lines
                lines = TestingApp.FormatNotes(notes);
                Prompt.ImputMultipleLines(lines);
                //continue
                Prompt.PressNextButton();
                //Validate value for address
                var AddresText = DisplayInfo.GetValueFor("Company Name:");
                //add company
                DisplayInfo.PressButton("Add Company");
                Methods.Cancel();
            }

            //exit application
            Methods.ExitApplication();
            return;
        }

        public static List<string> FormatNotes(string notes)
        {
            List<string> list = new List<string>();
            
            foreach (var note in notes.Split('\n'))
            {
                list.Add(note);                  
            }
            return list;
        }

        public static void Test2()
        {
            Menu.Select("View Companies");
            ListView.ClickItemByText("Name");
            Methods.ExitApplication();
            return;

        }
    }
}

