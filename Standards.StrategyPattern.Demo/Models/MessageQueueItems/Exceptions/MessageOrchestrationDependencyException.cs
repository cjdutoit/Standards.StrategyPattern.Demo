// --------------------------------------------------------------------------------
// Copyright (c) Christo du Toit. All rights reserved.
// Licensed under the MIT License. 
// --------------------------------------------------------------------------------

using Xeptions;

namespace Standards.StrategyPattern.Demo.Models.MessageQueueItems.Exceptions
{
    public class MessageOrchestrationDependencyException : Xeption
    {
        public MessageOrchestrationDependencyException(Xeption innerException) :
            base(message: "Message orchestration dependency error occurred, contact support.", innerException)
        { }
    }
}
