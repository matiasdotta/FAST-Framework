using FAST_Framework.Apps;
using NUnit.Framework;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;
using System;
using System.Threading;

namespace FAST_Framework
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {

        }

        public void OpenFile()
        {

        }

        [Test]
        public void Test1()
        {
            Methods.OpenMobileClient();
            Thread.Sleep(15000);
            Methods.OpenApp("Inventory Inquiry");
            Thread.Sleep(5000);
            InventoryInquiry.Test1();
            Methods.OpenApp("Cycle Count");
            Thread.Sleep(3000);
            CycleCount.test1();
        }


        [TearDown]
        public void TearDown()
        {
            Assert.Pass();
        }
    }
}