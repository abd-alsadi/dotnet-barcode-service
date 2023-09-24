using KmnlkBarcodeDll.Management;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using static KmnlkBarcodeDll.Constants.Enums;
using static KmnlkCommon.Shareds.LoggerManagement;

namespace KmnlkBarcodeDll.Management
{
    public class BussinessBarcodeManagement
    {
        private QRManagement QRM;
        private BarcodeManagement BRM;
        public ILog logger;
        private string BarcodePackage;
        public BussinessBarcodeManagement(ILog logger,string BarcodePackage)
        {
            this.logger = logger;
            this.BarcodePackage=BarcodePackage;
            QRM = new QRManagement(logger);
            BRM = new BarcodeManagement(logger);
        }
        public Image getBarcode(string text, bool withText, int type)
        {
            if (BarcodePackage == "zen")
            {
                switch (type)
                {
                    case (int)Enum_Barcode_Type.CODE_128:
                        return BRM.convertTextToBarcodeImageZEN(text, withText);
                    case (int)Enum_Barcode_Type.CODE_QR:
                        return QRM.convertTextToBarcodeImageZEN(text, withText);
                    default:
                        return BRM.convertTextToBarcodeImageZEN(text, withText);
                }
            }
            else
            {
                switch (type)
                {
                    case (int)Enum_Barcode_Type.CODE_128:
                        return BRM.convertTextToBarcodeImageZXING(text, withText);
                    case (int)Enum_Barcode_Type.CODE_QR:
                        return QRM.convertTextToBarcodeImageZXING(text, withText);
                    default:
                        return BRM.convertTextToBarcodeImageZXING(text, withText);
                }
            }

        }
        public string getText(Bitmap img, int type)
        {
            if (BarcodePackage == "zen")
            {
                switch (type)
                {
                    case (int)Enum_Barcode_Type.CODE_128:
                        return BRM.extractTextFromBarcodeImageZXING(img);
                    case (int)Enum_Barcode_Type.CODE_QR:
                        return QRM.extractTextFromBarcodeImageZXING(img);
                    default:
                        return BRM.extractTextFromBarcodeImageZXING(img);
                }
            }
            else
            {
                switch (type)
                {
                    case (int)Enum_Barcode_Type.CODE_128:
                        return BRM.extractTextFromBarcodeImageZXING(img);
                    case (int)Enum_Barcode_Type.CODE_QR:
                        return QRM.extractTextFromBarcodeImageZXING(img);
                    default:
                        return BRM.extractTextFromBarcodeImageZXING(img);
                }
            }

        }
    }
}