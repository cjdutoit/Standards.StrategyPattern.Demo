// --------------------------------------------------------------------------------
// Copyright (c) Christo du Toit. All rights reserved.
// Licensed under the MIT License. 
// --------------------------------------------------------------------------------

using Xeptions;

namespace Standards.StrategyPattern.Demo.Models.MessageQueueItems.Exceptions
{
    public class NullMessageOrchestrationException : Xeption
    {
        public NullMessageOrchestrationException()
            : base(message: "Message orchestration is null.")
        { }
    }
}
