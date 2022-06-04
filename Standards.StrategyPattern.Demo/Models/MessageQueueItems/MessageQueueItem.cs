// --------------------------------------------------------------------------------
// Copyright (c) Christo du Toit. All rights reserved.
// Licensed under the MIT License. 
// --------------------------------------------------------------------------------

using System;

namespace Standards.StrategyPattern.Demo.Models.Messages
{
    public class MessageQueueItem
    {
        public Guid Id { get; set; }
        public string MessageType { get; set; }
        public string Message { get; set; }
    }
}
