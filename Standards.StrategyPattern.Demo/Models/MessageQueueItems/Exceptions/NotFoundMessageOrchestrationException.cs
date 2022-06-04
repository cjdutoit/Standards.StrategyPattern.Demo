﻿// --------------------------------------------------------------------------------
// Copyright (c) Christo du Toit. All rights reserved.
// Licensed under the MIT License. 
// --------------------------------------------------------------------------------

using System;
using Xeptions;

namespace Standards.StrategyPattern.Demo.Models.MessageQueueItems.Exceptions
{
    public class NotFoundMessageOrchestrationException : Xeption
    {
        public NotFoundMessageOrchestrationException(Guid messageOrchestrationId)
            : base(message: $"Couldn't find message orchestration with messageOrchestrationId: {messageOrchestrationId}.")
        { }
    }
}
