

using Castle.DynamicProxy.Generators.Emitters.SimpleAST;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using System;
using System.Data;
using System.Diagnostics;
using System.Runtime.InteropServices.ComTypes;

namespace FAST_Framework
{
    public static class Driver
    {
        static WindowsDriver<WindowsElement> driver;
        static WebDriverWait wait = null;
        /// <summary>
        /// Initialize driver using program path
        /// </summary>
        public static void InitializeDriver(Config config)
        {
            System.Diagnostics.Process.Start(config.driverPath);
            AppiumOptions capabilities = new AppiumOptions();
            capabilities.AddAdditionalCapability("app", config.MCPath);
            capabilities.AddAdditionalCapability("deviceName", config.LocaldeviceName);
            driver = new WindowsDriver<WindowsElement>(new Uri("http://127.0.0.1:4723"), capabilities);
            return;
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

        public static WebDriverWait NewWait(int time)
        {
            TimeSpan timespan = new TimeSpan(0, 0, time);
            wait = new WebDriverWait(driver,timespan);
            return wait;
        }
    }   
}
