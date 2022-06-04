// --------------------------------------------------------------------------------
// Copyright (c) Christo du Toit. All rights reserved.
// Licensed under the MIT License. 
// --------------------------------------------------------------------------------

using Xeptions;

namespace Standards.StrategyPattern.Demo.Models.MessageQueueItems.Exceptions
{
    public class MessageOrchestrationValidationException : Xeption
    {
        public MessageOrchestrationValidationException(Xeption innerException)
            : base(message: "Message orchestration validation errors occurred, please try again.",
                  innerException)
        { }
    }
}
