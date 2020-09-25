using FAST_Framework;
using FAST_Framework.FormTemplates;
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
                lines = MultiPrompt.StringToList(notes);
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

        public static void Test2(Config config)
        {
            ExcelUtil.PopulateInCollection(config.XLPath);
            int n = ExcelUtil.numberOfTests;

            Menu.Select("Add Company Multi Prompt");
            MultiPrompt.InputTextOnPrompNumber("asd 1111111111111", 1);
            MultiPrompt.InputTextOnPrompNumber("asd 2222222222222", 2);
            MultiPrompt.InputTextOnPrompNumber("asd 3333333333333", 3);
            MultiPrompt.InputTextOnPrompNumber("asd 4444444444444", 4);
            MultiPrompt.PressButtonByName("Continue");


            //exit application
            Methods.ExitApplication();
            return;
        }



        public static void Test3()
        {
            Menu.Select("Dropdown Companies");
            Dropdown.OpenDropdown();
            Dropdown.ClickItemNumber(1);
            Dropdown.OpenDropdown();
            Dropdown.ClickItemByText("Company 4");
            Dropdown.PressNextButton();
            Methods.ExitApplication();
            return;

        }
    }
}

