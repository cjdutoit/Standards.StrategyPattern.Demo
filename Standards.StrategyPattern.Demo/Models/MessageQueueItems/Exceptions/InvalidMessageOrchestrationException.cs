// --------------------------------------------------------------------------------
// Copyright (c) Christo du Toit. All rights reserved.
// Licensed under the MIT License. 
// --------------------------------------------------------------------------------

using Xeptions;

namespace Standards.StrategyPattern.Demo.Models.MessageQueueItems.Exceptions
{
    public class InvalidMessageOrchestrationException : Xeption
    {
        public InvalidMessageOrchestrationException()
            : base(message: "Invalid message orchestration. Please correct the errors and try again.")
        { }
    }
}
