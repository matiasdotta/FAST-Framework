

using Castle.DynamicProxy.Generators.Emitters.SimpleAST;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Remote;
using System;
using System.Data;
using System.Diagnostics;
using System.Drawing.Imaging;
using System.Runtime.InteropServices.ComTypes;

namespace FAST_Framework
{
    public static class Driver
    {
        static WindowsDriver<WindowsElement> driver = null;

        //Initialize driver using program path
        public static void InitializeDriver()
        {
            KillProcess("WinAppDriver.exe");
            Process.Start(@"C:\Program Files (x86)\Windows Application Driver\WinAppDriver.exe");
            driver = GetDriver();
            if (driver != null) 
                driver.Quit();

            AppiumOptions capabilities = new AppiumOptions();

            capabilities.AddAdditionalCapability("app", Config.MCPath);
            capabilities.AddAdditionalCapability("deviceName", "WindowsPC");
            driver = new WindowsDriver<WindowsElement>(new Uri("http://127.0.0.1:4723"), capabilities);
            

        }
        //initialize driver using window handle
        public static void InitializeDriver(String WindowHandle)
        {


            AppiumOptions capabilities = new AppiumOptions();

            capabilities.AddAdditionalCapability("app", Config.MCPath);
            capabilities.AddAdditionalCapability("deviceName", "WindowsPC");

            var driver1 = new WindowsDriver<WindowsElement>(new Uri("http://127.0.0.1:4723"), capabilities);
            driver = driver1;
        }

        //Quits driver and restart with current windowHandle
        public static WindowsDriver<WindowsElement> ResetDriverUsingWindowHandler()
        {
            KillProcess("WinAppDriver.exe");
            Process.Start(@"C:\Program Files (x86)\Windows Application Driver\WinAppDriver.exe");
            Driver.InitializeDriver("TEST");

            Process[] processes = Process.GetProcessesByName(Config.MCProcName);
            string WindowHandler = processes[0].MainWindowHandle.ToInt32().ToString("x");
            string pid = processes[0].Id.ToString();
            var driver = Driver.GetDriver();

            driver.Quit();

            return Driver.GetDriver();
        }

        //ReturnStatement current driver
        public static WindowsDriver<WindowsElement> GetDriver()
        {
            return driver;
        }

        public static void CloseDriver()
        {
            driver.Close();
        }

        public static string KillProcess(string serviceName, string SystemID = "")
        {
            try
            {
                foreach (var process in Process.GetProcesses())
                {
                    if (process.ProcessName.ToUpper().Contains(serviceName.ToUpper()))
                        process.Kill();
                }
            }
            catch (Exception ex)
            {
                string ErrMsg = "";
                ErrMsg += "Exception in kill process: " + ex.Message.ToString();
                return ErrMsg;
            }
            return "";
        }

        public static bool IsMCOpen()
        {
            return Process.GetProcessesByName(Config.MCProcName).Length > 0;
        }

    }

   
}
