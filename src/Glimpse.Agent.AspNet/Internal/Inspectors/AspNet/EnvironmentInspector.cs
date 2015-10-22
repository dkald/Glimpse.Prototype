﻿using System;
using Glimpse.Agent.AspNet.Messages;
using Glimpse.Agent.Inspectors;
using Microsoft.AspNet.Http;

namespace Glimpse.Agent.AspNet.Internal.Inspectors.AspNet
{
    public class EnvironmentInspector : Inspector
    {
        private readonly IAgentBroker _broker;
        private EnvironmentMessage _message;

        public EnvironmentInspector(IAgentBroker broker)
        {
            _broker = broker;
        }

        public override void Before(HttpContext context)
        {
            if (_message == null)
            {
                var time = DateTimeOffset.Now;
                var timeZoneInfo = TimeZoneInfo.Local;
                var isDaylightSavingTime = timeZoneInfo.IsDaylightSavingTime(time);
                
                _message = new EnvironmentMessage
                {
                    ServerName = Environment.GetEnvironmentVariable("COMPUTERNAME"), // TODO: make sure its cross plat
                    ServerTime = time.ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss'.'fff"),
                    ServerTimezoneOffset = time.ToString("zzz"),
                    ServerDaylightSavingTime = isDaylightSavingTime
                };
            }

            _broker.SendMessage(_message);
        }
    }
}
