using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using OfficeOpenXml.FormulaParsing.Excel;

namespace FAST_Framework
{
    public class Config
    {
        public string LocaldeviceName { get; set; }
        #region File paths
        public string MCPath { get; set; }
        public string MCProcName { get; set; }
        public string XLPath { get; set; }
        public string driverPath { get; set; }
        #endregion
        #region MC credentials
        public string userName { get; set; }
        public string password { get; set; }
        #endregion
        #region MC config
        public string deviceId { get; set; }
        public string hostAddress { get; set; }
        public string port { get; set; }
        public string httpPort { get; set; }
        public string responseTimeout { get; set; }
        public string commsTimeout { get; set; }
        public bool useHttps { get; set; }
        public bool communicationsActive { get; set; }
        #endregion
        public int timeout { get; set; }
        public static class ExcelCellPredefinedStyles
        {
            public static ExcelCellStyle HeaderStyle = new ExcelCellStyle(16, true, false, Color.Black, Color.White);
            public static ExcelCellStyle DefStyle = new ExcelCellStyle(12, false, false);
        }

        public class ExcelCellStyle
        {
            public int Size;
            public bool Bold;
            public bool Italic;
            public Color BgColor;
            public Color FontColor;

            public ExcelCellStyle(int size, bool bold, bool italic, Color bgColor, Color fontColor)
            {
                this.Size = size;
                this.Bold = bold;
                this.Italic = italic;
                this.BgColor = bgColor;
                this.FontColor = fontColor;
            }
            public ExcelCellStyle(int size, bool bold, bool italic, Color fontColor)
            {
                this.Size = size;
                this.Bold = bold;
                this.Italic = italic;
                this.FontColor = fontColor;
            }
            public ExcelCellStyle(int size, bool bold, bool italic)
            {
                this.Size = size;
                this.Bold = bold;
                this.Italic = italic;
            }

        }
    }
}
