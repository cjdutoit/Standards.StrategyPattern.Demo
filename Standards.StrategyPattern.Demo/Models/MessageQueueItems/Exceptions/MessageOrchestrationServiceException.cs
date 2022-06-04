// --------------------------------------------------------------------------------
// Copyright (c) Christo du Toit. All rights reserved.
// Licensed under the MIT License. 
// --------------------------------------------------------------------------------

using System;
using Xeptions;

namespace Standards.StrategyPattern.Demo.Models.MessageQueueItems.Exceptions
{
    public class MessageOrchestrationServiceException : Xeption
    {
        public MessageOrchestrationServiceException(Exception innerException)
            : base(message: "Message orchestration service error occurred, contact support.", innerException)
        { }
    }
}
