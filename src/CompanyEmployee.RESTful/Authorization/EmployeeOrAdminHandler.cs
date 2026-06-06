using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace CompanyEmployee.RESTful.Authorization
{
    public class EmployeeOrAdminHandler : AuthorizationHandler<EmployeeOrAdminRequirement, Guid>
    {
        protected override Task HandleRequirementAsync(
            AuthorizationHandlerContext context, EmployeeOrAdminRequirement requirement, Guid resource)
        {
            var isAdmin = context.User.IsInRole("admin");

            if (isAdmin)
            {
                context.Succeed(requirement);
                return Task.CompletedTask;
            }

            // Ownership check
            var userId = context.User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (Guid.Parse(userId).Equals(resource))
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}
