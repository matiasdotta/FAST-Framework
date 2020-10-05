using System;
using System.Diagnostics;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace FAST_Framework
{
    public static class Methods
    {
        public static WindowsDriver<WindowsElement> driver = Driver.GetDriver();
        private static int timeout;

        #region MC controls


        /// <summary>
        /// Starts Mobile Client with Windows Driver and logs into user account
        /// </summary>
        /// <param name="config">Set the config values (LocaldeviceName, driverPath, MCPath, MCProcName, userName, password) before runing this method</param>
        public static void OpenMobileClient(Config config)
        {
            Driver.InitializeDriver(config);
            Login(config);
            timeout = config.timeout;
        }
        public static void Login(Config config)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
            var login = driver.FindElementByAccessibilityId("loginId");
            var pass = driver.FindElementByAccessibilityId("password");
            var button = driver.FindElementByAccessibilityId("OK");

            login.SendKeys(config.userName);
            pass.SendKeys(config.password);
            button.SendKeys(Keys.Enter);
        }

        public static void ChangeMCConfig()
        {

        }
        /// <summary>
        /// Once logged into MC, looks for an app that contains the parameter passed and opens the first element found
        /// </summary>
        /// <param name="appName">Name or part of the name of the application</param>
        public static void OpenApp(string appName)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(timeout * 2);
            try
            {
                driver.SwitchTo().Window(driver.WindowHandles[0]);
                var apps = driver.FindElementsByClassName("ListBoxItem");
                foreach (var app in apps)
                {
                    if (app.Text.Contains(appName))
                    {
                        app.Click();
                        app.SendKeys(Keys.Enter);
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                Assert.Fail("Application named \"" + appName + "\" not found.\n" + ex.Message);
            }
        }
        #endregion

        #region App controls
        #region Button interactions
        /// <summary>
        /// Looks for a substring containing the name passed and returns the first element of the class with that condition
        /// </summary>
        /// <param name="className">Class name from the inspector</param>
        /// <param name="buttonText">Text displayed on screen</param>
        public static void ClickButtonByClass(String className, string buttonText)
        {
            driver.SwitchTo().Window(driver.WindowHandles[0]);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(timeout);
            try
            {
                var buttons = driver.FindElementsByClassName(className);
                foreach (var b in buttons)
                {
                    if (b.Text.Contains(buttonText))
                    {
                        b.Click();
                        return;
                    }
                }

            }
            catch (Exception ex)
            {
                Assert.Fail("Button \"" + buttonText + "\" not found.\n" + ex.Message);
            }
        }
        /// <summary>
        /// Click on an image button by its name
        /// </summary>
        /// <param name="name"></param>
        public static void ClickImageButton(string name)
        {
            try
            {
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(timeout);
                var images = driver.FindElementsByClassName("Image");
                foreach (var image in images)
                {
                    if (image.Text.Contains(name))
                    {
                        image.Click();
                    }
                }
            }
            catch (Exception ex)
            {
                Assert.Fail("Button \"" + name + "\" not found.\n" + ex.Message);
            }
            return;
        }
        /// <summary>
        /// Opens FAST options Menu
        /// </summary>
        public static void OpenMenu()
        {
            try
            {
                driver.Manage().Timeouts().ImplicitWait = new TimeSpan(timeout);
                var images = driver.FindElementsByAccessibilityId("imgMenu");
                foreach (var image in images)
                {
                    if (image.Text.Contains("Menu"))
                    {
                        image.Click();
                    }
                    return;
                }
            }
            catch (Exception ex)
            {
                Assert.Fail("Unable to open Options Menu" + ex.Message);
            }

        }

        /// <summary>
        /// Combination of methods to exit the application.
        /// </summary>
        public static void ExitApplication()
        {
            OpenMenu();
            ClickButtonByClass("Button", "Exit Transaction");
            return;
        }
        /// <summary>
        /// Combination of methods to press cancer on current screen
        /// </summary>
        public static void Cancel()
        {
            OpenMenu();
            ClickButtonByClass("Button", "Cancel");
            return;
        }
        #endregion
        #region Text Interactions
        /// <summary>
        /// Imput text on prompt elements
        /// </summary>
        /// <param name="text">Input string</param>
        /// <param name="sendEnter">Press enter key after imput</param>
        /// <param name="texboxId">Text box automation ID from inspector</param>
        public static void EnterTextValue(string text, bool sendEnter, string texboxId = "txtPromptText")
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(timeout);
            try
            {
                var textBox = driver.FindElementByAccessibilityId(texboxId);
                if (text == "")
                {
                    textBox.SendKeys(Keys.Enter);
                    return;
                }
                else
                {
                    if (sendEnter)
                    {
                        textBox.SendKeys(text);
                        System.Threading.Thread.Sleep(500);
                        textBox.SendKeys(Keys.Enter);
                        return;
                    }
                    else
                    {
                        textBox.SendKeys(text);
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                Assert.Fail("Unable to enter Text.\n" + ex.Message);
            }
        }

        /// <summary>
        /// Get the text from a field on a "Display Info" form
        /// </summary>
        /// <param name="field">Screen text for the field that we want to extract the value (i.e. "Item Number: ")</param>
        /// <returns></returns>
        public static string GetValueFor(string field)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(timeout);
            try
            {
                var displayedInfo = driver.FindElementByAccessibilityId("lblInfo");
                var value = displayedInfo.Text.Split(field)[1];
                value = value.Split('\r')[0];
                return value;
            }
            catch (Exception ex)
            {
                Assert.Fail("Field \"" + field + "\" not found.\n" + ex.Message);
            }
            return "";
        }
        /// <summary>
        /// Clears any text in an input field and presses enter
        /// </summary>
        public static void ClearText(string texboxId = "txtPromptText")
        {
            try
            {
                var textBox = driver.FindElementByAccessibilityId(texboxId);
                textBox.SendKeys(Keys.Delete);
                Thread.Sleep(500);
                textBox.SendKeys(Keys.Enter);
            }
            catch (Exception ex)
            {
                Assert.Fail("Prompt not found.\n" + ex.Message);
            }
        }
        #endregion
        #region list interactions
        /// <summary>
        /// Gets an array of "ListView" elements and selects the one in the possition specified
        /// </summary>
        /// <param name="n">position of element</param>
        public static void ClickListItemByPos(int n)
        {
            try
            {
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(timeout);
                var ListItems = driver.FindElementsByClassName("ListViewItem");
                ListItems[n].Click();
            }
            catch (Exception ex)
            {
                Assert.Fail("List element not found" + ex.Message);
            }
        }
        /// <summary>
        /// CLick a list item based on its name
        /// </summary>
        /// <param name="name">Name value from inspector</param>
        public static void ClickListItemByName(string name)
        {
            try
            {
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(timeout);
                var ListItem = driver.FindElementByName(name);
                ListItem.Click();
            }
            catch (Exception ex)
            {
                Assert.Fail("Item named \"" + name + "\" not found.\n" + ex.Message);
            }
        }

        public static void OpenDropdown()
        {
            try
            {
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(timeout);
                var dropdown = driver.FindElementByAccessibilityId("ddlDropdown");
                dropdown.Click();
            }
            catch (Exception ex)
            {
                Assert.Fail("Dropdown not found.\n" + ex.Message);
            }
        }
        /// <summary>
        /// Gets an array of dropdown elements and clicks the first one that contains de name specified
        /// </summary>
        /// <param name="name">Text </param>
        public static void ClickDropDownItemByName(string name)
        {
            try
            {
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(timeout);
                var ListItem = driver.FindElementByName(name);
                ListItem.Click();
            }
            catch (Exception ex)
            {
                Assert.Fail("Dropdown Line not found.\n" + ex.Message);
            }
        }
        /// <summary>
        ///Get an array of dropdown elements and clicks the specified one
        /// </summary>
        /// <param name="position">Item to click</param>
        public static void ClickDropDownItemByPosition(int position)
        {
            try
            {
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(timeout);
                var items = driver.FindElementsByClassName("ListBoxItem");
                items[position].Click();
            }
            catch (Exception ex)
            {
                Assert.Fail("Dropdown Line not found.\n" + ex.Message);
            }
        }


        #endregion
        #region Display Message Controls

        /// <summary>
        /// Get the text displayed on a "Display Message" Form
        /// </summary>
        /// <returns></returns>
        public static string GetDisplayMessage()
        {
            try
            {
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(timeout);
                var message = driver.FindElementByAccessibilityId("lblTransitionLabel");
                return message.Text.ToString();
            }
            catch (Exception ex)
            {
                Assert.Fail("display message not found.\n" + ex.Message);
                return "";
            }
            
        }

        /// <summary>
        /// Determines whether the message sent as paramater is the one on being shown.
        /// </summary>
        /// <param name="message">Message to check on the display message screen (Not case sensitive)</param>
        /// <returns>Whether that message is the one being shown or not</returns>
        public static bool IsDisplayMessage(string message)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(timeout);
            try
            {
                var labels = driver.FindElementsByAccessibilityId("lblTransitionLabel");
                foreach (var label in labels)
                {
                    if (label.Text.ToUpper().Contains(message.ToUpper()))
                        return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                Assert.Fail("Text element not found\n" + ex.Message);
                return false;
            }
        }

        #endregion
        #region Cursor Control
        /// <summary>
        /// Used to click windows elements if normal actions fails
        /// </summary>
        /// <param name="elem">Windows element</param>
        /// <param name="doubleClick">Bool if true double click </param>
        public static void ClickElement(WindowsElement elem, bool doubleClick = false)
        {
            try
            {
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(timeout);

                Actions action = new Actions(driver);
                action.MoveToElement(elem);
                action.Perform();

                if (!doubleClick)
                    action.Click();
                else
                    action.DoubleClick();
                action.Perform();
            }
            catch (Exception ex)
            {
                Assert.Fail("Element not found.\n" + ex.Message);
            }
        }
        #endregion
        #endregion
    }

}
