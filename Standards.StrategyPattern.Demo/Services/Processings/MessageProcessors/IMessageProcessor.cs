// --------------------------------------------------------------------------------
// Copyright (c) Christo du Toit. All rights reserved.
// Licensed under the MIT License. 
// --------------------------------------------------------------------------------

using System.Threading.Tasks;
using Standards.StrategyPattern.Demo.Models.Messages;

namespace Standards.StrategyPattern.Demo.Services.Processings.MessageProcessors
{
    public interface IMessageProcessor
    {
        string ProcessorMessageType { get; }
        ValueTask<bool> ProcessMessageAsync(MessageQueueItem message);
    }
}