using KmnlkBarcodeDll.Management;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static KmnlkCommon.Shareds.LoggerManagement;

namespace MyTest
{
    class Program
    {
        static void Main(string[] args)
        {
            DBLogger log = new DBLogger(@"E:\Pro\KmnlkBarcode\KmnlkBarcodeApi\Output\Log\Local\");
           // Bitmap b=new Bitmap("tt.png");
            //KmnlkBarcodeDll.Management.QRManagement x = new KmnlkBarcodeDll.Management.QRManagement(log);
            //String img= x.convertBarcodeImageToText(b);
            //img.Save("myfile.png", ImageFormat.Png);
            BarcodeManagement x = new BarcodeManagement(log);
            Image im=x.convertTextToBarcodeImageZXING("asdasdasdas",true);
            im.Save("tt.png", ImageFormat.Png);
        }


    }
}
