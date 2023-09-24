using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KmnlkBarcodeDll.Interfaces
{
    public interface IQRConvertOperations
    {
        Image convertTextToBarcodeImageZEN(string text,bool withText);
        Image convertTextToBarcodeImageZXING(string text, bool withText, int width, int height);
        string extractTextFromBarcodeImageZXING(Bitmap img);
    }
}
