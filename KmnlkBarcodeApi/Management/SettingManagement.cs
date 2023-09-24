using KmnlkCommon.Shareds;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using static KmnlkCommon.Shareds.RWFManagement;

namespace KmnlkBarcodeApi.Management
{
    public class SettingsManagement
    {
        private static Dictionary<object, object> settings;
        private static string pathSettings = "";
        private static string folderSettings = "Settings";
        public static string KEY_PublicKey = "PublicKey";
        public static string KEY_EnableLog = "EnableLog";
        public static string KEY_TypeLog = "TypeLog";
        public static string KEY_GlobalTypeLog = "GlobalTypeLog";
        public static string KEY_PathLog = "PathLog";
        public static string KEY_GlobalPathLog = "GlobalPathLog";
        public static string KEY_DataFolder = "DataFolder";
        public static string KEY_UploadFilesMaximumFileSize = "UploadFilesMaximumFileSize";
        public static string KEY_BarcodePackage = "BarcodePackage";
        public static string KEY_ConnectionString = "ConnectionString";
        public static string KEY_DBPassword = "DBPassword";
        public static string KEY_OCRServiceUrl = "OCRServiceUrl";
        public static string KEY_DBType = "DBType";

        private static void loadSettings()
        {
            XMLFileObject XML = new XMLFileObject(pathSettings);
            settings = XML.ReadAll();
        }
        public static object getSetting(string key, string defaultValue = "")
        {
            if (settings == null)
            {
                settings = new Dictionary<object, object>();
                pathSettings = EnvironmentManagement.getRootPath();
                pathSettings = Path.Combine(pathSettings, folderSettings);
                pathSettings = Path.Combine(pathSettings, "config.xml");
                loadSettings();
            }

            object value = null;
            settings.TryGetValue(key, out value);
            if (value == null)
            {
                return defaultValue;
            }
            return value;
        }
    }
}