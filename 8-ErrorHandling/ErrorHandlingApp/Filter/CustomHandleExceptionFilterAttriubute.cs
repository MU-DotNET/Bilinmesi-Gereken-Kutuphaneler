using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace ErrorHandlingApp.Filter
{
    public class CustomHandleExceptionFilterAttriubute : ExceptionFilterAttribute
    {
        public string ErrorPage { get; set; }
        public override void OnException(ExceptionContext context)
        {
            //loglama yapıldı

            if (ErrorPage =="Hata1")
            {
                //farklı bir kaynağa loglama
            }
            else
            {
                //farklı bir kaynağa loglama
            }

            ViewResult result = new() { ViewName = ErrorPage };
            result.ViewData = new(new EmptyModelMetadataProvider(), context.ModelState);
            result.ViewData.Add("Exception", context.Exception);

            result.ViewData.Add("Url", context.HttpContext.Request.Path.Value);

            context.Result = result;
        }
    }
}
