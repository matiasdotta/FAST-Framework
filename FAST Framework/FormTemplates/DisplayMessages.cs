using System;
using System.Collections.Generic;
using System.Text;

namespace FAST_Framework.FormTemplates
{
    public class DisplayMessages
    {
        
        /// <summary>
        /// Returns the display message of the current display message screen
        /// </summary>
        /// <returns>Message being shown</returns>
        public static string GetDisplayMessage()
        {
            return Methods.GetDisplayMessage();
        }

        /// <summary>
        /// Handle of IsDisplayMessage methods of Methods class
        /// </summary>
        /// <param name="messageText">Message to check on the display message screen (Not case sensitive)</param>
        /// <returns>Whether there is a display message or the message is the one being shown or not</returns>
        public static bool IsDisplayMessage(string messageText = "")
        {
            if(messageText != "")
                return Methods.IsDisplayMessage(messageText);
            return Methods.IsDisplayMessage();

        }

        /// <summary>
        /// Clicks the "OK" button found on the display message screens
        /// </summary>
        public static void CLickOkButton()
        {
            Methods.ClickButtonByClass("Button", "OK");
            return;
        }
    }
}
