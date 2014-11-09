﻿
using Microsoft.AspNet.Builder;
using System;

namespace Glimpse.Host.Web.AspNet
{
    public static class GlimpseExtension
    {
        /// <summary>
        /// Adds a middleware that allows GLimpse to be registered into the system.
        /// </summary>
        /// <param name="app"></param>
        /// <returns></returns>
        public static IApplicationBuilder UseGlimpse(this IApplicationBuilder app)
        {
            return app.Use(next => new GlimpseMiddleware(next).Invoke);
        }
    }
}