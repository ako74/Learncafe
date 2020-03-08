using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;

namespace Learncafe.WebApi.Authorization
{
    public class IdmGroupHandler : AuthorizationHandler<IdmGroupRequiment>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context,
                                                       IdmGroupRequiment requirement)
        {
            context.Succeed(requirement);
            return Task.CompletedTask;
        }
    }
}
