using CompanyEmployee.RESTful.RequestAttributes;
using CompanyEmployees.Domain.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CompanyEmployee.RESTful.ActionFilters
{
    public class ValidationFilterAttribute : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            var action = context.RouteData.Values["action"];
            var controller = context.RouteData.Values["controller"];
            
            var param = context.ActionArguments.SingleOrDefault(p => p.Value.ToString().Contains("Dto")).Value;

            var skipValidation = context.ActionDescriptor.EndpointMetadata
                .Any(x => x is SkipRequestDtoValidationAttribute);

            if (skipValidation)
                return;

            if (param is null)
            {
                context.Result = new BadRequestObjectResult(string.Format(CompanyEmployeesErrorCodes.ObjectIsNull, controller, action));
                return;
            }

            if (!context.ModelState.IsValid)
            {
                context.Result = new UnprocessableEntityObjectResult(context.ModelState);
            }
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            // TODO: Implement if needed
        }
    }
}
