using KmnlkBarcodeApi.Constants;
using KmnlkBarcodeApi.Exceptions;
using KmnlkBarcodeApi.Management;
using KmnlkCommon.Shareds;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using static KmnlkCommon.Shareds.LoggerManagement;

namespace KmnlkBarcodeApi
{
    public class WebApiApplication : System.Web.HttpApplication
    {
    
        private ILog logger;

        private void initConfig()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
        private void init()
        {
            string pathLog = SettingsManagement.getSetting(SettingsManagement.KEY_GlobalPathLog).ToString();
            string typeLog = SettingsManagement.getSetting(SettingsManagement.KEY_GlobalTypeLog).ToString();
            switch (typeLog)
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
        }
        protected void Application_Start()
        {

            init();
            logger.WriteToLog(EnvironmentManagement.getCurrentMethodName(this.GetType()), "", ENUM_TYPE_MSG_LOGGER.INFO, ENUM_TYPE_Block_LOGGER.START, modConstants.MSG_SUCCESS);

            //-------------------------
            try
            {
                // my code
                Application["Title"] = "Builder.com Sample";
                //Session["startValue"] =0;

                logger.WriteToLog(EnvironmentManagement.getCurrentMethodName(this.GetType()), "", ENUM_TYPE_MSG_LOGGER.INFO, ENUM_TYPE_Block_LOGGER.END, modConstants.MSG_SUCCESS);
            }
            catch (Exception ee)
            {
                new ApiException(logger, "", EnvironmentManagement.getCurrentMethodName(this.GetType()), ee.Message);
            }
            //-------------------------
            initConfig();
        }
        protected void Application_Error(object sender, EventArgs e)
        {
            if (logger == null)
                init();
            logger.WriteToLog(EnvironmentManagement.getCurrentMethodName(this.GetType()), "", ENUM_TYPE_MSG_LOGGER.INFO, ENUM_TYPE_Block_LOGGER.START, modConstants.MSG_SUCCESS);

            try
            {
                logger.WriteToLog(EnvironmentManagement.getCurrentMethodName(this.GetType()), "", ENUM_TYPE_MSG_LOGGER.INFO, ENUM_TYPE_Block_LOGGER.END, modConstants.MSG_SUCCESS);
            }
            catch (Exception ee)
            {
                new ApiException(logger, "", EnvironmentManagement.getCurrentMethodName(this.GetType()), ee.Message);
            }

            // Code that runs when an unhandled error occurs
            //Exception objErr = Server.GetLastError().GetBaseException();
            //string err = "Error in: " + Request.Url.ToString() + ". Error Message:" + objErr.Message.ToString();

        }
        protected void Application_End(Object sender, EventArgs e)
        {
            if (logger == null)
                init();
            logger.WriteToLog(EnvironmentManagement.getCurrentMethodName(this.GetType()), "", ENUM_TYPE_MSG_LOGGER.INFO, ENUM_TYPE_Block_LOGGER.START, modConstants.MSG_SUCCESS);

            try
            {
                logger.WriteToLog(EnvironmentManagement.getCurrentMethodName(this.GetType()), "", ENUM_TYPE_MSG_LOGGER.INFO, ENUM_TYPE_Block_LOGGER.END, modConstants.MSG_SUCCESS);
            }
            catch (Exception ee)
            {
                new ApiException(logger, "", EnvironmentManagement.getCurrentMethodName(this.GetType()), ee.Message);
            }
            //Application["Title"] = "Builder.com Sample";
            ////Session["startValue"] =0;
        }
        protected void Session_Start(Object sender, EventArgs e)
        {
            if (logger == null)
                init();
            logger.WriteToLog(EnvironmentManagement.getCurrentMethodName(this.GetType()), "", ENUM_TYPE_MSG_LOGGER.INFO, ENUM_TYPE_Block_LOGGER.START, modConstants.MSG_SUCCESS);

            try
            {
                logger.WriteToLog(EnvironmentManagement.getCurrentMethodName(this.GetType()), "", ENUM_TYPE_MSG_LOGGER.INFO, ENUM_TYPE_Block_LOGGER.END, modConstants.MSG_SUCCESS);
            }
            catch (Exception ee)
            {
                new ApiException(logger, "", EnvironmentManagement.getCurrentMethodName(this.GetType()), ee.Message);
            }
            //Session["startValue"] +=1;
        }
        protected void Session_End(Object sender, EventArgs e)
        {
            if (logger == null)
                init();
            logger.WriteToLog(EnvironmentManagement.getCurrentMethodName(this.GetType()), "", ENUM_TYPE_MSG_LOGGER.INFO, ENUM_TYPE_Block_LOGGER.START, modConstants.MSG_SUCCESS);

            try
            {
                logger.WriteToLog(EnvironmentManagement.getCurrentMethodName(this.GetType()), "", ENUM_TYPE_MSG_LOGGER.INFO, ENUM_TYPE_Block_LOGGER.END, modConstants.MSG_SUCCESS);
            }
            catch (Exception ee)
            {
                new ApiException(logger, "", EnvironmentManagement.getCurrentMethodName(this.GetType()), ee.Message);
            }
            //Session["startValue"] -=1;
        }
        protected void Application_BeginRequest(Object sender, EventArgs e)
        {
            if (logger == null)
                init();
            logger.WriteToLog(EnvironmentManagement.getCurrentMethodName(this.GetType()), "", ENUM_TYPE_MSG_LOGGER.INFO, ENUM_TYPE_Block_LOGGER.START, modConstants.MSG_SUCCESS);

            try
            {
                logger.WriteToLog(EnvironmentManagement.getCurrentMethodName(this.GetType()), "", ENUM_TYPE_MSG_LOGGER.INFO, ENUM_TYPE_Block_LOGGER.END, modConstants.MSG_SUCCESS);
            }
            catch (Exception ee)
            {
                new ApiException(logger, "", EnvironmentManagement.getCurrentMethodName(this.GetType()), ee.Message);
            }
        }
        protected void Application_EndRequest(Object sender, EventArgs e)
        {
            if (logger == null)
                init();
            logger.WriteToLog(EnvironmentManagement.getCurrentMethodName(this.GetType()), "", ENUM_TYPE_MSG_LOGGER.INFO, ENUM_TYPE_Block_LOGGER.START, modConstants.MSG_SUCCESS);

            try
            {
                logger.WriteToLog(EnvironmentManagement.getCurrentMethodName(this.GetType()), "", ENUM_TYPE_MSG_LOGGER.INFO, ENUM_TYPE_Block_LOGGER.END, modConstants.MSG_SUCCESS);
            }
            catch (Exception ee)
            {
                new ApiException(logger, "", EnvironmentManagement.getCurrentMethodName(this.GetType()), ee.Message);
            }
        }
        protected void Application_Disposed(Object sender, EventArgs e)
        {
            if (logger == null)
                init();
            logger.WriteToLog(EnvironmentManagement.getCurrentMethodName(this.GetType()), "", ENUM_TYPE_MSG_LOGGER.INFO, ENUM_TYPE_Block_LOGGER.START, modConstants.MSG_SUCCESS);

            try
            {
                logger.WriteToLog(EnvironmentManagement.getCurrentMethodName(this.GetType()), "", ENUM_TYPE_MSG_LOGGER.INFO, ENUM_TYPE_Block_LOGGER.END, modConstants.MSG_SUCCESS);
            }
            catch (Exception ee)
            {
                new ApiException(logger, "", EnvironmentManagement.getCurrentMethodName(this.GetType()), ee.Message);
            }
        }
        protected void Application_PreRequestHandlerExecute(Object sender, EventArgs e)
        {
            if (logger == null)
                init();
            logger.WriteToLog(EnvironmentManagement.getCurrentMethodName(this.GetType()), "", ENUM_TYPE_MSG_LOGGER.INFO, ENUM_TYPE_Block_LOGGER.START, modConstants.MSG_SUCCESS);

            try
            {
                logger.WriteToLog(EnvironmentManagement.getCurrentMethodName(this.GetType()), "", ENUM_TYPE_MSG_LOGGER.INFO, ENUM_TYPE_Block_LOGGER.END, modConstants.MSG_SUCCESS);
            }
            catch (Exception ee)
            {
                new ApiException(logger, "", EnvironmentManagement.getCurrentMethodName(this.GetType()), ee.Message);
            }
        }
        protected void Application_PostRequestHandlerExecute(Object sender, EventArgs e)
        {
            if (logger == null)
                init();
            logger.WriteToLog(EnvironmentManagement.getCurrentMethodName(this.GetType()), "", ENUM_TYPE_MSG_LOGGER.INFO, ENUM_TYPE_Block_LOGGER.START, modConstants.MSG_SUCCESS);

            try
            {
                logger.WriteToLog(EnvironmentManagement.getCurrentMethodName(this.GetType()), "", ENUM_TYPE_MSG_LOGGER.INFO, ENUM_TYPE_Block_LOGGER.END, modConstants.MSG_SUCCESS);
            }
            catch (Exception ee)
            {
                new ApiException(logger, "", EnvironmentManagement.getCurrentMethodName(this.GetType()), ee.Message);
            }
        }
        protected void Application_AuthenticateRequest(Object sender, EventArgs e)
        {
            if (logger == null)
                init();
            logger.WriteToLog(EnvironmentManagement.getCurrentMethodName(this.GetType()), "", ENUM_TYPE_MSG_LOGGER.INFO, ENUM_TYPE_Block_LOGGER.START, modConstants.MSG_SUCCESS);

            try
            {
                logger.WriteToLog(EnvironmentManagement.getCurrentMethodName(this.GetType()), "", ENUM_TYPE_MSG_LOGGER.INFO, ENUM_TYPE_Block_LOGGER.END, modConstants.MSG_SUCCESS);
            }
            catch (Exception ee)
            {
                new ApiException(logger, "", EnvironmentManagement.getCurrentMethodName(this.GetType()), ee.Message);
            }

            //    // Extract the forms authentication cookie
            //    string cookieName = FormsAuthentication.FormsCookieName;
            //    HttpCookie authCookie = Context.Request.Cookies[cookieName];
            //    if (null == authCookie)
            //    {
            //        // There is no authentication cookie.
            //        return;
            //    }
            //    FormsAuthenticationTicket authTicket = null;
            //    try
            //    {
            //        authTicket = FormsAuthentication.Decrypt(authCookie.Value);
            //    }
            //    catch (Exception ex)
            //    {
            //        // Log exception details (omitted for simplicity)
            //        return;
            //    }
            //    if (null == authTicket)
            //    {
            //        // Cookie failed to decrypt.
            //        return;
            //    }
            //    // When the ticket was created, the UserData property was assigned
            //    // a pipe delimited string of role names.
            //    string[] roles= { "One", "Two" };

            //// Create an Identity object
            //    FormsIdentity id = new FormsIdentity(authTicket);
            //    // This principal will flow throughout the request.
            //    GenericPrincipal principal = new GenericPrincipal(id, roles);
            //    // Attach the new principal object to the current HttpContext object
            //    Context.User = principal;
        }
        
}
}

