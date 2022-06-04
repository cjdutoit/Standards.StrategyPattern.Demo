// --------------------------------------------------------------------------------
// Copyright (c) Christo du Toit. All rights reserved.
// Licensed under the MIT License. 
// --------------------------------------------------------------------------------

using System;
using Xeptions;

namespace Standards.StrategyPattern.Demo.Models.MessageQueueItems.Exceptions
{
    public class LockedMessageOrchestrationException : Xeption
    {
        public LockedMessageOrchestrationException(Exception innerException)
            : base(message: "Locked message orchestration record exception, please try again later", innerException)
        {
        }
    }
}
