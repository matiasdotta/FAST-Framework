using FAST_Framework;
using FAST_Framework.Apps;
using NUnit.Framework;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;
using System;
using System.Threading;

namespace Testing
{
    public class Tests
    {
        private Config _config = new Config();
        [SetUp]
        public void Setup()
        {
            _config.MCPath = @"C:\Program Files (x86)\DSI\Mobile Client\DSI.MobileClient.PC.exe";
            _config.MCProcName = "DSI.MobileClient.PC";
            _config.XLPath = @"C:\Users\OwO\source\repos\FAST Framework\FAST Framework\TestCases.XLSX";
            _config.userName = "matias.dotta@ARCHROCK.com";
            _config.password = "1Password!";

        }

        public void OpenFile()
        {

        }

        [Test]
        public void Test1()
        {
            Methods.OpenMobileClient(_config);
            Methods.OpenApp("Inventory Inquiry");
            InventoryInquiry.Test1();
            //Methods.OpenApp("Cycle Count");
            //Thread.Sleep(3000);
            //CycleCount.test1();
        }


        [TearDown]
        public void TearDown()
        {
            Assert.Pass();
        }
    }
}