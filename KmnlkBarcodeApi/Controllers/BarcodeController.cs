using KmnlkBarcodeApi.Constants;
using KmnlkBarcodeApi.Exceptions;
using KmnlkBarcodeApi.Management;
using KmnlkBarcodeApi.Models;
using KmnlkCommon.Shareds;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using static KmnlkCommon.Shareds.LoggerManagement;

namespace KmnlkBarcodeApi.Controllers
{
    public class BarcodeController : ApiController
    {
        private PackageManagement package = null;

        public BarcodeController(PackageManagement repo)
        {
            package = repo;
        }
        [HttpGet]
        [ActionName("GetBarcode")]
        public HttpResponseMessage GetBarcode([FromUri]string text, [FromUri]bool withText, [FromUri]int type,string fileName="barcode",string ext="png")
        {
            package.logger.WriteToLog(EnvironmentManagement.getCurrentMethodName(this.GetType()), "", ENUM_TYPE_MSG_LOGGER.INFO, ENUM_TYPE_Block_LOGGER.START, modConstants.MSG_SUCCESS);
            string startTime = DateTime.Now.ToString("hh:mm:ss");
            string endTime = "";
            HttpResponseMessage res;
            try
            {
                Guid duid = Guid.NewGuid();
                Image img = package.getBarcode(text,withText,type);
                string dataFolder = SettingsManagement.getSetting(SettingsManagement.KEY_DataFolder).ToString();
                dataFolder = Path.Combine(dataFolder, "DownloadFolder");
                if (!Directory.Exists(dataFolder))
                {
                    Directory.CreateDirectory(dataFolder);
                }
                dataFolder = Path.Combine(dataFolder, duid.ToString());
                if (!Directory.Exists(dataFolder))
                {
                    Directory.CreateDirectory(dataFolder);
                }
                dataFolder = Path.Combine(dataFolder, duid.ToString() + "." + ext);
                img.Save(dataFolder);
                res =DownloadManagement.Download(img, fileName+"."+ext, "image", ext);
                endTime = DateTime.Now.ToString("hh:mm:ss");
                package.logger.WriteToLog(EnvironmentManagement.getCurrentMethodName(this.GetType()), "", ENUM_TYPE_MSG_LOGGER.INFO,ENUM_TYPE_Block_LOGGER.END, modConstants.MSG_SUCCESS);
                return res;
            }
            catch(Exception e)
            {
                new ApiException(package.logger, modConstants.MSG_SUCCESS, EnvironmentManagement.getCurrentMethodName(this.GetType()), e.Message);
                var response = new ResponseModel(null, e.Message, HttpStatusCode.BadRequest, startTime, endTime);
                return Request.CreateResponse<ResponseModel>(HttpStatusCode.OK, response);
            }
      
        }


        [HttpPost]
        [ActionName("GetText")]
        public async Task<HttpResponseMessage> GetText([FromUri]int type)
        {
            package.logger.WriteToLog(EnvironmentManagement.getCurrentMethodName(this.GetType()), "", ENUM_TYPE_MSG_LOGGER.INFO, ENUM_TYPE_Block_LOGGER.START, modConstants.MSG_SUCCESS);
            string startTime = DateTime.Now.ToString("hh:mm:ss");
            string endTime = "";
            HttpResponseMessage res;
            try
            {
                string dataFolder = SettingsManagement.getSetting(SettingsManagement.KEY_DataFolder).ToString();
                dataFolder=Path.Combine(dataFolder, "TempFolder");
                var provider = new MultipartFormDataStreamProvider(dataFolder);
                await Request.Content.ReadAsMultipartAsync(provider);
                string text = package.getText(provider, type);
                endTime = DateTime.Now.ToString("hh:mm:ss");
                var response = new ResponseModel(text, modConstants.MSG_SUCCESS, HttpStatusCode.OK, startTime, endTime);
                res=Request.CreateResponse<ResponseModel>(HttpStatusCode.OK, response);
                package.logger.WriteToLog(EnvironmentManagement.getCurrentMethodName(this.GetType()), "", ENUM_TYPE_MSG_LOGGER.INFO, ENUM_TYPE_Block_LOGGER.END, modConstants.MSG_SUCCESS);
                return res;
            }
            catch (Exception e)
            {
                new ApiException(package.logger, "", EnvironmentManagement.getCurrentMethodName(this.GetType()), e.Message);
                var response = new ResponseModel(null, e.Message, HttpStatusCode.BadRequest, startTime, endTime);
                return Request.CreateResponse<ResponseModel>(HttpStatusCode.OK, response);
            }

        }

        [NonAction]
        public bool isValid(string uid)
        {
            return true;
        }
    }
}
