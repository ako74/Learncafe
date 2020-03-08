using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Learncafe.WebApi.Services
{
    //public class LearcafeAuthorizationService : IAuthorizationService
    //{

    //    public async Task<AuthorizationResult> AuthorizeAsync(ClaimsPrincipal user,
    //         object resource, IEnumerable<IAuthorizationRequirement> requirements)
    //    {
    //        // Create a tracking context from the authorization inputs.
    //        var authContext = _contextFactory.CreateContext(requirements, user, resource);

    //        // By default this returns an IEnumerable<IAuthorizationHandlers> from DI.
    //        var handlers = await _handlers.GetHandlersAsync(authContext);

    //        // Invoke all handlers.
    //        foreach (var handler in handlers)
    //        {
    //            await handler.HandleAsync(authContext);
    //        }

    //        // Check the context, by default success is when all requirements have been met.
    //        return _evaluator.Evaluate(authContext);
    //    }

    //    public Task<AuthorizationResult> AuthorizeAsync(ClaimsPrincipal user, object resource, string policyName)
    //    {
    //        throw new NotImplementedException();
    //    }
    //}
}
