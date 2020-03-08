using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;

namespace Learncafe.WebApi.Authorization
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
}
