using System;
using System.Diagnostics;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Support.UI;

namespace FAST_Framework
{
    public static class Methods
    {
        public static WindowsDriver<WindowsElement> driver = Driver.GetDriver();

        #region MC controls

       
        /// <summary>
        /// Starts Mobile Client with Windows Driver and logs into user account
        /// </summary>
        /// <param name="config">Set the config values (LocaldeviceName, driverPath, MCPath, MCProcName, userName, password) before runing this method</param>
        public static void OpenMobileClient(Config config)
        {
            Driver.InitializeDriver(config);
            Login(config);
        }
        public static void Login(Config config) {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
            var login = driver.FindElementByAccessibilityId("loginId");
            var pass = driver.FindElementByAccessibilityId("password");
            var button = driver.FindElementByAccessibilityId("OK");

            login.SendKeys(config.userName);
            pass.SendKeys(config.password);
            button.SendKeys(Keys.Enter);
            return;
        }

        public static void ChangeMCConfig()
        {

        }
        /// <summary>
        /// Once logged into MC, looks for an app that contains the parameter passed and opens the first element found
        /// 
        /// </summary>
        /// <param name="appName">Name or part of the name of the application</param>
        public static void OpenApp(string appName)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
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
                var a = ex.Message;
                throw;
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
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
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
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// Click on an image button by its name
        /// </summary>
        /// <param name="name"></param>
        public static void ClickImageButton(string name)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
            var images = driver.FindElementsByClassName("Image");
            foreach (var image in images)
            {
                if (image.Text.Contains(name))
                {
                    image.Click();
                }
            }
            return;
        }
        /// <summary>
        /// Opens FAST options Menu
        /// </summary>
        public static void OpenMenu()
        {
            driver.Manage().Timeouts().ImplicitWait = new TimeSpan(15);
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
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
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
        /// <summary>
        /// Get the text displayed on a "Display Message" Form
        /// </summary>
        /// <returns></returns>
        public static string GetDisplayMessage()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
            var message = driver.FindElementByAccessibilityId("lblTransitionLabel");
            return message.Text.ToString();
        }
        /// <summary>
        /// Get the text from a field on a "Display Info" form
        /// </summary>
        /// <param name="field">Screen text for the field that we want to extract the value (i.e. "Item Number: ")</param>
        /// <returns></returns>
        public static string GetValueFor(string field)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
            var displayedInfo = driver.FindElementByAccessibilityId("lblInfo");
            var value = displayedInfo.Text.Split(field)[1];
            value = value.Split('\r')[0];
            return value;
        }
        #endregion
        #region list interactions
        /// <summary>
        /// Gets an array of "ListView" elements and selects the one in the possition specified
        /// </summary>
        /// <param name="n">position of element</param>
        public static void ClickListItemByPos(int n)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
            var ListItems = driver.FindElementsByClassName("ListViewItem");
            ListItems[n].Click();
            return;
        }
        /// <summary>
        /// CLick a list item based on its name
        /// </summary>
        /// <param name="name">Name value from inspector</param>
        public static void ClickListItemByName(string name)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
            var ListItem = driver.FindElementByName(name);
            ListItem.Click();
            return;
            
        }
        #endregion
        #endregion
    }

}









/*

/// <summary>
/// Clears any text in an input field and presses enter
/// </summary>
public static void ClearText()
{
    OpenQA.Selenium.Interactions.Actions action = new OpenQA.Selenium.Interactions.Actions(session);

    action.SendKeys(Keys.Delete).Perform();
    ActivityCI.Sleep(500);
    action.SendKeys(Keys.Enter).Perform();
}

/// <summary>
/// Select a list item
/// </summary>
/// <param name="Item"></param>
/// <param name="elementIdentifier"></param>
public static void SelectListItem(string value, string elementIdentifier = "lsvDisplayList1")
{
    WindowsElement listView = session.FindElementByAccessibilityId(elementIdentifier);

    var listItems = listView.FindElementsByTagName("DataItem");

    for (int i = 0; i < listItems.Count; i++)
    {
        WindowsElement listItem = (WindowsElement)listItems[i];

        var textItems = listItem.FindElementsByTagName("Text");

        for (int j = 0; j < textItems.Count; j++)
        {
            if (textItems[j].Text.StartsWith(value))
            {
                listItem.Click();
                return;
            }
        }
    }

    Assert.Fail("Value[" + value + "] not found in list.");
}

/// <summary>
/// Select a list item based on a parent value
/// </summary>
/// <param name="parentValue"></param>
/// <param name="childValue"></param>
/// <param name="elementIdentifier"></param>
public static void SelectListItemBasedOnParentValue(string parentValue, string childValue, string elementIdentifier = "lsvDisplayList1")
{
    WindowsElement listView = session.FindElementByAccessibilityId(elementIdentifier);

    var listItems = listView.FindElementsByTagName("Group");

    for (int i = 0; i < listItems.Count; i++)
    {
        WindowsElement listItem = (WindowsElement)listItems[i];

        if (listItem.Text.StartsWith(parentValue))
        {
            var textItems = listItem.FindElementsByTagName("Text");

            foreach (var item in textItems)
            {
                WindowsElement row = (WindowsElement)item;

                if (row.Text.StartsWith(childValue))
                {
                    row.Click();
                    return;
                }
            }
        }
    }

    Assert.Fail("SelectListItemBasedOnParent - Parent Value[" + parentValue + "] Value[" + childValue + "] not found in list.");
}

/// <summary>
/// click a button
/// </summary>
public static void ClickButton(string buttonText, string className = "ButtonAppControl")
{
    Sleep(500);

    var buttons = session.FindElementsByClassName(className);

    for (int i = 0; i < buttons.Count; i++)
    {
        var buttonItems = buttons[i].FindElementsByTagName("Button");

        for (int j = 0; j < buttonItems.Count; j++)
        {
            if (buttonItems[j].Text.Contains(buttonText))
            {
                buttonItems[j].Click();
                return;
            }
        }
    }
    ActivityCI.Sleep(500);
}


/// <summary>
/// click a button
/// </summary>
public static bool VerifyButton(string buttonText, string className = "ButtonAppControl")
{
    Sleep(500);

    var buttons = session.FindElementsByClassName(className);

    for (int i = 0; i < buttons.Count; i++)
    {
        var buttonItems = buttons[i].FindElementsByTagName("Button");

        for (int j = 0; j < buttonItems.Count; j++)
        {
            if (buttonItems[j].Text.Contains(buttonText))
                return true;
        }
    }

    return false;
}

/// <summary>
/// click a button
/// </summary>
public static void WaitForButton(string buttonText, string className = "ButtonAppControl")
{
    int counter = 0;

    while (true)
    {
        Sleep(500);

        var buttons = session.FindElementsByClassName(className);

        for (int i = 0; i < buttons.Count; i++)
        {
            var buttonItems = buttons[i].FindElementsByTagName("Button");

            for (int j = 0; j < buttonItems.Count; j++)
            {
                if (buttonItems[j].Text.Contains(buttonText))
                {
                    return;
                }
            }
        }

        if (++counter > 10)
            return;
    }
}

/// <summary>
/// click a button by ID
/// </summary>
public static void ClickButtonById(string Id)
{
    var button = session.FindElementByAccessibilityId(Id);
    button.Click();
}

/// <summary>
/// click a button
/// </summary>
public static void ClickOption43(string buttonText)
{
    // open 8 options first            
    var images = session.FindElementsByAccessibilityId("imgMenu");
    images[0].Click();

    var buttons = session.FindElementsByClassName("Button");

    for (int i = 0; i < buttons.Count; i++)
    {
        if (buttons[i].Text == buttonText)
        {
            buttons[i].Click();
            return;
        }
    }
}

/// <summary>
/// Verify a line of text
/// </summary>
/// <param name="text"></param>
/// <returns></returns>
public static void VerifyText(string txt, bool contains = true)
{
    Sleep(500);

    var forms = session.FindElementsByClassName("LabelAppControl");

    for (int i = 0; i < forms.Count; i++)
    {
        var textItems = forms[i].FindElementsByTagName("Text");

        for (int j = 0; j < textItems.Count; j++)
        {
            if (contains)
            {
                string val = textItems[j].Text;

                if (textItems[j].Text.Contains(txt))
                    return;
            }
            else
            {
                if (textItems[j].Text == txt)
                    return;
            }
        }
    }

    Assert.Fail("Text[ " + txt + "] not found.");
}

/// <summary>
/// Validates if the provided text is found in the screen
/// </summary>
/// <param name="txt"></param>
/// <param name="contains"></param>
/// <returns></returns>
public static bool ValidateText(string txt, bool contains = true)
{
    Sleep(500);

    var forms = session.FindElementsByClassName("LabelAppControl");

    for (int i = 0; i < forms.Count; i++)
    {
        var textItems = forms[i].FindElementsByTagName("Text");

        for (int j = 0; j < textItems.Count; j++)
        {
            if (contains)
            {
                string val = textItems[j].Text;

                if (textItems[j].Text.Contains(txt))
                    return true;
            }
            else
            {
                if (textItems[j].Text == txt)
                    return true;
            }
        }
    }

    return false;
}

/// <summary>
/// Verify a line of text
/// </summary>
/// <param name="text"></param>
/// <returns></returns>
public static void VerifyListItemText(string txt, bool contains = true)
{
    Sleep(500);
    var forms = session.FindElementsByClassName("ListViewItem");
    Sleep(500);

    for (int i = 0; i < forms.Count; i++)
    {
        var textItems = forms[i].FindElementsByTagName("Text");

        for (int j = 0; j < textItems.Count; j++)
        {
            if (contains)
            {
                if (textItems[j].Text.Contains(txt))
                    return;
            }
            else
            {
                if (textItems[j].Text == txt)
                    return;
            }
        }
    }

    Assert.Fail("Text[ " + txt + "] not found in list.");
}

/// <summary>
/// Verify a line of text
/// </summary>
/// <param name="text"></param>
/// <returns></returns>
public static bool VerifyListItem(string txt, bool contains = true)
{
    var forms = session.FindElementsByClassName("ListViewItem");

    for (int i = 0; i < forms.Count; i++)
    {
        var textItems = forms[i].FindElementsByTagName("Text");

        for (int j = 0; j < textItems.Count; j++)
        {
            if (contains)
            {
                if (textItems[j].Text.Contains(txt))
                    return true;
            }
            else
            {
                if (textItems[j].Text == txt)
                    return true;
            }
        }
    }
    return false;
}


/// <summary>
/// select an item from a list based on matching text
/// </summary>
/// <param name="text"></param>
/// <returns></returns>
public static void SelectListItemText(string txt, string tag = "lsvDisplayList3", bool contains = true)
{
    var listView = session.FindElementByAccessibilityId(tag);

    var dataItems = listView.FindElementsByTagName("DataItem");

    for (int j = 0; j < dataItems.Count; j++)
    {
        var textItems = dataItems[j].FindElementsByTagName("Text");

        for (int k = 0; k < textItems.Count; k++)
        {
            if (contains)
            {
                if (textItems[k].Text.Contains(txt))
                {
                    ActivityCI.Sleep(1000);
                    dataItems[j].Click();
                    return;
                }
            }
            else
            {
                if (textItems[k].Text == txt)
                {
                    dataItems[j].Click();
                    return;
                }
            }
        }
    }

    Assert.Fail("Row containing text[ " + txt + "] not found in list.");
}

/// <summary>
/// retrieve text from a display
/// </summary>
/// <param name="text"></param>
/// <returns></returns>
public static string GetTextIfContains(string txt, int occurrence = 1)
{
    var forms = session.FindElementsByClassName("LabelAppControl");

    int occurrenceCount = 0;

    for (int i = 0; i < forms.Count; i++)
    {
        var textItems = forms[i].FindElementsByTagName("Text");

        for (int j = 0; j < textItems.Count; j++)
        {
            if (textItems[j].Text.Contains(txt))
            {
                occurrenceCount++;

                if (occurrenceCount == occurrence)
                    return textItems[j].Text;
            }
        }
    }

    Assert.Fail("Text[ " + txt + "] not found.");
    return "";
}

/// <summary>
/// retrieve text from a display
/// </summary>
public static string GetTextBoxValue()
{
    var value = session.FindElementByAccessibilityId("txtPromptText");
    return value.Text;
}

/// <summary>
/// click the back arrow image thingy
/// </summary>
public static void ClickBackArrow()
{
    var back = session.FindElementByAccessibilityId("lblBack");
    back.Click();
}

/// <summary>
/// Used in BaseCI.Launch
/// </summary>
public static void WaitForCIMenu()
{
    DefaultWait<WindowsDriver<WindowsElement>> wait = new DefaultWait<WindowsDriver<WindowsElement>>(session)
    {
        Timeout = TimeSpan.FromSeconds(30),
        PollingInterval = TimeSpan.FromSeconds(0.25)
    };

    WindowsElement element = null;
    wait.Until(driver =>
    {
        try
        {
            driver.SwitchTo().Window(driver.WindowHandles[0]);
            element = driver.FindElementByXPath("//Window[@Name='Cloud Inventory Mobile Menu']");
        }
        catch (Exception ex)
        {
            Type exType = ex.GetType();
            if (exType == typeof(InvalidOperationException))
                return false; //By returning false, wait will still rerun
            else
                throw;
        }
        return element != null;
    });
}

/// <summary>
/// Waits for an specific text to be shown
/// </summary>
/// <param name="Id"></param>
/// <param name="txt"></param>
public static void WaitForText(string Id, string txt)
{
    int count = 0;

    while (true)
    {
        var TextItems = session.FindElementsByAccessibilityId(Id);

        for (int i = 0; i < TextItems.Count; i++)
        {
            if (TextItems[i].Text.Contains(txt))
                return;
        }

        ActivityCI.Sleep(500);

        if (++count == 20)  // 10 seconds

            Assert.Fail("WaitForText timed out. Id[" + Id + "] Text[" + txt + "]");
    }
}
    }*/