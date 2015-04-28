﻿using System.Collections.Generic;
using System.Linq;
using Glimpse.Agent.Web;
using Glimpse.Web;
using Microsoft.Framework.OptionsModel;

namespace Glimpse.Agent.Web.Framework
{
    public class IgnoredStatusCodeRequestPolicy : IIgnoredRequestPolicy
    {
        private readonly IReadOnlyCollection<int> _statusCodes;

        public IgnoredStatusCodeRequestPolicy(IIgnoredStatusCodeProvider ignoredStatusCodeProvider)
        {
            _statusCodes = ignoredStatusCodeProvider.StatusCodes;
        }

        public bool ShouldIgnore(IHttpContext context)
        {
            return _statusCodes.Contains(context.Response.StatusCode);
        }
    }
}