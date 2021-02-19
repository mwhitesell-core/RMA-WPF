using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pdf2Text
{
    public class TextElement
    {
        public TextElement(int row, int column, string text)
        {
            Row = row;
            Column = column;
            Text = text;
        }

        public int Row { get; set; }
        public int Column { get; set; }
        public string Text { get; set; }
    }
}
