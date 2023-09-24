using KmnlkBarcodeDll.Management;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Web;
using static KmnlkBarcodeApi.Constants.Enums;
using static KmnlkCommon.Shareds.LoggerManagement;

namespace KmnlkBarcodeApi.Management
{
    public class PackageManagement
    {
        private BussinessBarcodeManagement manager;
        public ILog logger;
        private string BarcodePackage;
        public PackageManagement()
        {
            string pathLog = SettingsManagement.getSetting(SettingsManagement.KEY_PathLog).ToString();
            string typeLog = SettingsManagement.getSetting(SettingsManagement.KEY_TypeLog).ToString();
            BarcodePackage = SettingsManagement.getSetting(SettingsManagement.KEY_BarcodePackage).ToString().ToLower();
            switch (typeLog.ToLower())
            {
                case "file":
                    logger = new FileLogger(pathLog);
                    break;
                case "db":
                    logger = new DBLogger(pathLog);
                    break;
                default:
                    logger = new FileLogger(pathLog);
                    break;
            }
            manager = new BussinessBarcodeManagement(logger, BarcodePackage);
        }
        public Image getBarcode(string text,bool withText, int type )
        {
          Image img=manager.getBarcode(text, withText, type);
            return img;
        }
        public string getText(Bitmap img, int type)
        {
            return manager.getText(img, type);
        }
        public string getText(MultipartFormDataStreamProvider provider,int type)
        {
            Guid guid = Guid.NewGuid();
            string newId = guid.ToString();
            string dataFolder = SettingsManagement.getSetting(SettingsManagement.KEY_DataFolder).ToString();
            dataFolder = Path.Combine(dataFolder, "UploadFolder");
            if (!Directory.Exists(dataFolder))
            {
                Directory.CreateDirectory(dataFolder);
            }
            dataFolder = Path.Combine(dataFolder, newId);
            if (!Directory.Exists(dataFolder))
            {
                Directory.CreateDirectory(dataFolder);
            }
            string result = "";
            foreach (var file in provider.FileData)
            {
                var name = file.Headers.ContentDisposition.FileName;
                name = name.Trim('"');
                var locationFileName = file.LocalFileName;
                var filePath = Path.Combine(dataFolder, newId + Path.GetExtension(name));

                File.Copy(locationFileName, filePath);
                Bitmap img = new Bitmap(filePath);
                result += manager.getText(img, type);
            }
            return result;
        }
    }
}