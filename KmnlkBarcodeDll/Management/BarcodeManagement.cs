
using KmnlkBarcodeDll.Constants;
using KmnlkBarcodeDll.Exceptions;
using KmnlkBarcodeDll.Helpers;
using KmnlkBarcodeDll.Interfaces;
using KmnlkCommon.Shareds;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZXing;
using static KmnlkCommon.Shareds.LoggerManagement;

namespace KmnlkBarcodeDll.Management
{
    public class BarcodeManagement : IBarcodeConvertOperations, IValidationOperations
    {
        private ILog logger;
        private Zen.Barcode.Code128BarcodeDraw manager;
        public BarcodeManagement(ILog logger)
        {
            this.logger = logger;
            this.manager = Zen.Barcode.BarcodeDrawFactory.Code128WithChecksum;
        }

        public string extractTextFromBarcodeImageZXING(Bitmap img)
        {
            logger.WriteToLog(EnvironmentManagement.getCurrentMethodName(this.GetType()), "", ENUM_TYPE_MSG_LOGGER.INFO, ENUM_TYPE_Block_LOGGER.START, modConstant.MSG_SUCCESS);
            try
            {
                if (!isValid(img))
                {
                    return null;
                }
                string result = "";
                BarcodeReader reader = new BarcodeReader();
                var res = reader.Decode(img);
                if (res != null)
                    result = res.ToString();
                logger.WriteToLog(EnvironmentManagement.getCurrentMethodName(this.GetType()), "", ENUM_TYPE_MSG_LOGGER.INFO, ENUM_TYPE_Block_LOGGER.END, modConstant.MSG_SUCCESS);
                return result;
            }
            catch (Exception e)
            {
                new DllException(logger, "", EnvironmentManagement.getCurrentMethodName(this.GetType()), e.Message);
                return null;
            }
        }

        public Image convertTextToBarcodeImageZEN(string text, bool withText)
        {
            logger.WriteToLog(EnvironmentManagement.getCurrentMethodName(this.GetType()), "", ENUM_TYPE_MSG_LOGGER.INFO, ENUM_TYPE_Block_LOGGER.START, modConstant.MSG_SUCCESS);
            try
            {
                if (!isValid(text))
                {
                    return null;
                }
                Image result = manager.Draw(text, 50,4);
                if (withText)
                {
                    var resultImage = new Bitmap(result);
                    resultImage = MainHelper.writeTextOnImage(text, resultImage);
                    return resultImage;
                }
                logger.WriteToLog(EnvironmentManagement.getCurrentMethodName(this.GetType()), "", ENUM_TYPE_MSG_LOGGER.INFO, ENUM_TYPE_Block_LOGGER.END, modConstant.MSG_SUCCESS);
                return result;
            }
            catch (Exception e)
            {
                new DllException(logger, "", EnvironmentManagement.getCurrentMethodName(this.GetType()), e.Message);
                return null;
            }
        }
        public Image convertTextToBarcodeImageZXING(string text, bool withText,int width=-1,int height=100)
        {
            logger.WriteToLog(EnvironmentManagement.getCurrentMethodName(this.GetType()), "", ENUM_TYPE_MSG_LOGGER.INFO, ENUM_TYPE_Block_LOGGER.START, modConstant.MSG_SUCCESS);
            try
            {
                if (!isValid(text))
                {
                    return null;
                }
                if (width == -1)
                {
                    width = MainHelper.getTextWidth(text);
                }
                var options = new ZXing.QrCode.QrCodeEncodingOptions();
                options.Width = width;
                options.Height = height;
                BarcodeWriter writer = new BarcodeWriter();
                writer.Format = BarcodeFormat.CODE_128;
                writer.Options = options;
                Bitmap result = new Bitmap(writer.Write(text));
                if (withText)
                {
                    var resultImage = new Bitmap(result);
                    resultImage = MainHelper.writeTextOnImage(text, resultImage);
                    return resultImage;
                }
                logger.WriteToLog(EnvironmentManagement.getCurrentMethodName(this.GetType()), "", ENUM_TYPE_MSG_LOGGER.INFO, ENUM_TYPE_Block_LOGGER.END, modConstant.MSG_SUCCESS);
                return result;
            }
            catch (Exception e)
            {
                new DllException(logger, "", EnvironmentManagement.getCurrentMethodName(this.GetType()), e.Message);
                return null;
            }
        }

        public bool isValid(object model)
        {
            bool result = true;
            logger.WriteToLog(EnvironmentManagement.getCurrentMethodName(this.GetType()), "", ENUM_TYPE_MSG_LOGGER.INFO, ENUM_TYPE_Block_LOGGER.START, modConstant.MSG_SUCCESS);

            logger.WriteToLog(EnvironmentManagement.getCurrentMethodName(this.GetType()), "", ENUM_TYPE_MSG_LOGGER.INFO, ENUM_TYPE_Block_LOGGER.END, modConstant.MSG_SUCCESS);
            return result;
        }
    }
}
