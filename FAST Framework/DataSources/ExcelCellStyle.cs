using System.Drawing;

namespace FAST_Framework
{
    public class ExcelCellStyle
    {
        
        public int Size { get; set; }
        public bool Bold { get; set; }
        public bool Italic { get; set; }
        public Color BgColor { get; set; }
        public Color FontColor { get; set; }
        
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
