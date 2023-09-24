using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using System.Web.Routing;

namespace KmnlkBarcodeApi.Filters
{
    public class ExecuteBeforeAfterMiddlwareFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext) // before
        {
            if (actionContext.Request.Method.Method == "GET")
            {
                //do stuff for all get requests
            }
            base.OnActionExecuting(actionContext);
        }

        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext) // after
        {

        }
        //public override Task OnActionExecutedAsync(HttpActionExecutedContext actionExecutedContext, CancellationToken cancellationToken)
        //{
        //    return null;
        //}


        //public override Task OnActionExecutingAsync(HttpActionContext actionContext, CancellationToken cancellationToken)
        //{

        //    return null;
        //}



        // use it....
        //[TestActionFilter] // this will be for EVERY api method
        //public class PersonController : BaseApiController
        //{
        //    [HttpGet]
        //    [TestActionFilter] // this will be for just this one method
        //    public HttpResponseMessage GetAll()
        //    {
        //        //normal api stuff
        //    }
        //}
    }
}