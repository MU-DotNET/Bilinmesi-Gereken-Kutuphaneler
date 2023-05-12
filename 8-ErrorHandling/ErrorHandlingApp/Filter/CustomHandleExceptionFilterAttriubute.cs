using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace ErrorHandlingApp.Filter
{
    public class CustomHandleExceptionFilterAttriubute : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            ViewResult result = new() { ViewName = "Hata1" };
            result.ViewData = new(new EmptyModelMetadataProvider(),context.ModelState);
            result.ViewData.Add("Exception",context.Exception);

            context.Result = result;
        }
    }
}
