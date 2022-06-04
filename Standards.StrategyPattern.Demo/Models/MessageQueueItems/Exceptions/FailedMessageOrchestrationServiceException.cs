// --------------------------------------------------------------------------------
// Copyright (c) Christo du Toit. All rights reserved.
// Licensed under the MIT License. 
// --------------------------------------------------------------------------------

using System;
using Xeptions;

namespace Standards.StrategyPattern.Demo.Models.MessageQueueItems.Exceptions
{
    public class FailedMessageOrchestrationServiceException : Xeption
    {
        public FailedMessageOrchestrationServiceException(Exception innerException)
            : base(message: "Failed message orchestration service occurred, please contact support", innerException)
        { }
    }
}
