

using Castle.DynamicProxy.Generators.Emitters.SimpleAST;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Remote;
using System;
using System.Data;
using System.Diagnostics;
using System.Runtime.InteropServices.ComTypes;

namespace FAST_Framework
{
    public static class Driver
    {
        static WindowsDriver<WindowsElement> driver = null;

        //Initialize driver using program path
        public static void InitializeDriver()
        {
            driver = GetDriver();
            if (driver != null) driver.Quit();
            System.Diagnostics.Process.Start(@"C:\Program Files (x86)\Windows Application Driver\WinAppDriver.exe");
            AppiumOptions capabilities = new AppiumOptions();
            capabilities.AddAdditionalCapability("app", @"C:\Program Files (x86)\DSI\Mobile Client\DSI.MobileClient.PC.exe");
            capabilities.AddAdditionalCapability("deviceName", "WindowsPC");
            driver = new WindowsDriver<WindowsElement>(new Uri("http://127.0.0.1:4723"), capabilities);
        }
        //initialize driver using window handle
        public static void InitializeDriver(String WindowHandle)
        {
            
            AppiumOptions capabilities = new AppiumOptions();
            capabilities.AddAdditionalCapability("appTopLevelWindow", WindowHandle);
            driver = new WindowsDriver<WindowsElement>(new Uri("http://127.0.0.1:4723"), capabilities);
        }

        //Quits driver and restart with current windowHandle
        public static WindowsDriver<WindowsElement> ResetDriverUsingWindowHandler()
        {
            Process[] processes = Process.GetProcessesByName("DSI.MobileClient.PC");
            string WindowHandler = processes[0].MainWindowHandle.ToString(format: "x");
            var driver = Driver.GetDriver();
            driver.Quit();
            Driver.InitializeDriver(WindowHandler);
            return Driver.GetDriver();
        }

        //ReturnStatement current driver
        public static WindowsDriver<WindowsElement> GetDriver()
        {
            return driver;
        }
    }

   
}
