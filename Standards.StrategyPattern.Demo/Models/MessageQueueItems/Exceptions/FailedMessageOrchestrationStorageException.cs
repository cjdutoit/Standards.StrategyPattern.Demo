// --------------------------------------------------------------------------------
// Copyright (c) Christo du Toit. All rights reserved.
// Licensed under the MIT License. 
// --------------------------------------------------------------------------------

using System;
using Xeptions;

namespace Standards.StrategyPattern.Demo.Models.MessageQueueItems.Exceptions
{
    public class FailedMessageOrchestrationStorageException : Xeption
    {
        public FailedMessageOrchestrationStorageException(Exception innerException)
            : base(message: "Failed message orchestration storage error occurred, contact support.", innerException)
        { }
    }
}
