﻿using System;
using System.Collections.Generic;
using System.Text;

namespace FAST_Framework.Forms
{
    public class Menu
    {
        public static void Select(string button) 
        {
            Methods.ClickButtonByClass("Button", button);
            return;
        }
    }
}