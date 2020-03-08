using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Learncafe.WebApi
{
    public class IdmGroupRequiment : IAuthorizationRequirement
    {
        public IdmGroupRequiment(string groupName)
        {
            if (string.IsNullOrWhiteSpace(groupName))
            {
                throw new ArgumentException("message", nameof(groupName));
            }

            GroupName = groupName;
        }

        public string GroupName { get; set; }

    }

    public class PermissionHandler : IAuthorizationHandler
    {
        private readonly ILogger _logger;

        public PermissionHandler(ILoggerFactory loggerFactory)
        {
            if(loggerFactory == null)
            {
                throw new ArgumentNullException(nameof(loggerFactory));
            }
            _logger = loggerFactory.CreateLogger<PermissionHandler>();
        }

        public Task HandleAsync(AuthorizationHandlerContext context)
        {
            var pendingRequirements = context.PendingRequirements.ToList();

            foreach (var requirement in pendingRequirements)
            {
                if (requirement is IdmGroupRequiment)
                {
                    var idmGroup = (requirement as IdmGroupRequiment);
                    //context.Succeed(requirement);
                    _logger.LogInformation($"Checking if user '{context.User?.Identity.Name}' belongs to group '{idmGroup.GroupName}'");
                    context.Succeed(requirement);
                }
            }

            return Task.CompletedTask;
        }
    }
}
