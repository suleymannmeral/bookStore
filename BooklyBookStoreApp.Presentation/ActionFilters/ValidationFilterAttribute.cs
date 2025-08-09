using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooklyBookStoreApp.Presentation.ActionFilters
{
    public class ValidationFilterAttribute:ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var controller= context.RouteData.Values["controller"];  //controller adı
            var action = context.RouteData.Values["action"]; //action adı

            //DTO
            var param =context.ActionArguments
                .SingleOrDefault(x => x.Value.ToString().Contains("Dto")).Value; //action argumanları içinde null olanı bulur


            if(param is null)
            {
                context.Result = new BadRequestObjectResult($"Object is null. Controller: {controller}, Action: {action}");
                return;
            }

            if (!context.ModelState.IsValid)
            {
                context.Result = new UnprocessableEntityObjectResult(context.ModelState);
            }
        }
    }
}
