
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KmnlkBarcodeDll.Helpers
{
   public class MainHelper
    {
        public static Bitmap writeTextOnImage(string text, Bitmap img)
        {
            using (var graphics = Graphics.FromImage(img))
            {
                int fontSize = 10;
                Font font = new Font("Arial", fontSize);
                SizeF size = graphics.MeasureString(text, font);
                int x = 0;
                int y = (img.Height - (int)size.Height);
                int width =(int) size.Width;
                int height = (int)size.Height;
                Rectangle rect = new Rectangle(x, y, width, height);
                graphics.FillRectangle(Brushes.White, rect);
                graphics.DrawString(text, font, new SolidBrush(Color.Black), x, y);
                graphics.Dispose();
                return img;
            }
        }
     
        public static int getTextWidth(string text)
        {
            text = text.Trim();
            int countChar = 0;
            int countDegit = 0;
            char[] arr = text.ToArray();
            foreach(char ch in arr)
            {
                if (Char.IsDigit(ch))
                    countDegit++;
                else
                    countChar++;
            }

            int textLength = 0;
            textLength = (int)(((text.Length * 11) + 35) * 1.2);
            if (textLength < 120)
                textLength = 120;

            return textLength;
        }
    }
}
