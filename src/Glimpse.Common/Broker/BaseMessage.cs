﻿using System;

namespace Glimpse
{
    public class BaseMessage : IMessage
    {
        public BaseMessage()
        {
            Id = new Guid();
            Time = new DateTime();
        }

        public Guid Id { get; set; }

        public DateTime Time { get; set; }
    }
}