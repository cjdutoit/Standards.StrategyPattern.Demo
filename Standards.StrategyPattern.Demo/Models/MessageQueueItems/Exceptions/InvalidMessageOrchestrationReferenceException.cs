// --------------------------------------------------------------------------------
// Copyright (c) Christo du Toit. All rights reserved.
// Licensed under the MIT License. 
// --------------------------------------------------------------------------------

using System;
using Xeptions;

namespace Standards.StrategyPattern.Demo.Models.MessageQueueItems.Exceptions
{
    public class InvalidMessageOrchestrationReferenceException : Xeption
    {
        public InvalidMessageOrchestrationReferenceException(Exception innerException)
            : base(message: "Invalid message orchestration reference error occurred.", innerException) { }
    }
}