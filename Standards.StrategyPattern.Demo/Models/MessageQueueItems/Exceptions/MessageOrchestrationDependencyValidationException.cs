// --------------------------------------------------------------------------------
// Copyright (c) Christo du Toit. All rights reserved.
// Licensed under the MIT License. 
// --------------------------------------------------------------------------------

using Xeptions;

namespace Standards.StrategyPattern.Demo.Models.MessageQueueItems.Exceptions
{
    public class MessageOrchestrationDependencyValidationException : Xeption
    {
        public MessageOrchestrationDependencyValidationException(Xeption innerException)
            : base(message: "Message orchestration dependency validation occurred, please try again.", innerException)
        { }
    }
}
