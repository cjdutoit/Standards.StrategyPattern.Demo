// --------------------------------------------------------------------------------
// Copyright (c) Christo du Toit. All rights reserved.
// Licensed under the MIT License. 
// --------------------------------------------------------------------------------

using Xeptions;

namespace Standards.StrategyPattern.Demo.Models.MessageQueueItems.Exceptions
{
    public class NullMessageProcessorOrchestrationException : Xeption
    {
        public NullMessageProcessorOrchestrationException()
            : base(message: "Message processor is null.")
        { }
    }
}
