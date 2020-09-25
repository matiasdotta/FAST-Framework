using FAST_Framework;
using FAST_Framework.Apps;
using NUnit.Framework;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;
using System;
using System.Text;
using System.Threading;
using Testing.Apps;

namespace Testing
{
    public class Tests
    {
        private Config _config = new Config();
        private static WindowsDriver<WindowsElement> driver = Driver.GetDriver();
        [SetUp]
        public void Setup()
        {
            _config.LocaldeviceName = "WindowsPC";
            _config.driverPath = @"C:\Program Files (x86)\Windows Application Driver\WinAppDriver.exe";
            _config.MCPath = @"C:\Program Files (x86)\DSI\Mobile Client\DSI.MobileClient.PC.exe";
            _config.MCProcName = "DSI.MobileClient.PC";
            _config.XLPath = @"..\..\..\TestCases.xlsx";
            _config.userName = "matias.dotta@ocloud.com";
            _config.password = "1Password!";
            _config.timeout = 15;
            Methods.OpenMobileClient(_config);
            Methods.OpenApp("FAST Automation");
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

        }

        public void OpenFile()
        {

        }

        [Test]
        public void Test1()
        {            
            TestingApp.Test3();
        }
        
        [TearDown]
        public void TearDown()
        {
            driver.CloseApp();
            driver.Quit();
        }
    }
}