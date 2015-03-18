﻿using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Framework.OptionsModel;

namespace Glimpse.Agent.Web.Options
{
    public class DefaultIgnoredStatusCodeProvider : IIgnoredStatusCodeProvider
    {
        public DefaultIgnoredStatusCodeProvider(IOptions<GlimpseAgentWebOptions> optionsAccessor)
        {
            var statusCodes = optionsAccessor.Options.StatusCodes;
            StatusCodes = statusCodes.ToList();
        }

        public IReadOnlyList<IgnoredStatusCodeDescriptor> StatusCodes { get; } 
    }
}