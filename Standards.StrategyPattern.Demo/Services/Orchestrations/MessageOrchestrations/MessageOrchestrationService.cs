// --------------------------------------------------------------------------------
// Copyright (c) Christo du Toit. All rights reserved.
// Licensed under the MIT License. 
// --------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Standards.StrategyPattern.Demo.Brokers.Loggers;
using Standards.StrategyPattern.Demo.Models.Messages;
using Standards.StrategyPattern.Demo.Services.Processings.MessageProcessors;

namespace Standards.StrategyPattern.Demo.Services.Orchestrations.MessageOrchestrations.Services.Foundations.Messages
{
    public partial class MessageOrchestrationService : IMessageOrchestrationService
    {
        private readonly ICollection<IMessageProcessor> messageProcessors;
        private readonly ILoggingBroker loggingBroker;

        public MessageOrchestrationService(
            ICollection<IMessageProcessor> messageProcessors,
            ILoggingBroker loggingBroker)
        {
            this.messageProcessors = messageProcessors;
            this.loggingBroker = loggingBroker;
        }

        public ValueTask<bool> ProcessMessageAsync(MessageQueueItem messageQueueItem) =>
        TryCatch(async () =>
        {
            ValidateMessage(messageQueueItem);

            IMessageProcessor processor = messageProcessors
                .FirstOrDefault(processor => messageQueueItem.MessageType.StartsWith(processor.ProcessorMessageType));

            ValidateMatchingProcessorExist(processor);

            return await processor.ProcessMessageAsync(messageQueueItem);
        });
    }
}
