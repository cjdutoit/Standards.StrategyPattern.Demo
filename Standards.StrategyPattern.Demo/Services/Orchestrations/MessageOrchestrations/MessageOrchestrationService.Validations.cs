// --------------------------------------------------------------------------------
// Copyright (c) Christo du Toit. All rights reserved.
// Licensed under the MIT License. 
// --------------------------------------------------------------------------------

using System;
using Standards.StrategyPattern.Demo.Models.MessageQueueItems.Exceptions;
using Standards.StrategyPattern.Demo.Models.Messages;
using Standards.StrategyPattern.Demo.Services.Processings.MessageProcessors;

namespace Standards.StrategyPattern.Demo.Services.Orchestrations.MessageOrchestrations.Services.Foundations.Messages
{
    public partial class MessageOrchestrationService
    {
        private void ValidateMessage(MessageQueueItem messageQueueItem)
        {
            ValidateMessageIsNotNull(messageQueueItem);

            Validate(
                (Rule: IsInvalid(messageQueueItem.Id), Parameter: nameof(MessageQueueItem.Id)),
                (Rule: IsInvalid(messageQueueItem.MessageType), Parameter: nameof(MessageQueueItem.MessageType)),
                (Rule: IsInvalid(messageQueueItem.Message), Parameter: nameof(MessageQueueItem.Message)));
        }

        public void ValidateMessageId(Guid messageId) =>
            Validate((Rule: IsInvalid(messageId), Parameter: nameof(MessageQueueItem.Id)));

        private static void ValidateMessageIsNotNull(MessageQueueItem messageQueueItem)
        {
            if (messageQueueItem is null)
            {
                throw new NullMessageOrchestrationException();
            }
        }


        private static void ValidateMatchingProcessorExist(IMessageProcessor messageProcessor)
        {
            if (messageProcessor is null)
            {
                throw new NullMessageOrchestrationException();
            }
        }

        private static dynamic IsInvalid(Guid id) => new
        {
            Condition = id == Guid.Empty,
            Message = "Id is required"
        };

        private static dynamic IsInvalid(string text) => new
        {
            Condition = String.IsNullOrWhiteSpace(text),
            Message = "Text is required"
        };

        private static void Validate(params (dynamic Rule, string Parameter)[] validations)
        {
            var invalidMessageException = new InvalidMessageOrchestrationException();

            foreach ((dynamic rule, string parameter) in validations)
            {
                if (rule.Condition)
                {
                    invalidMessageException.UpsertDataList(
                        key: parameter,
                        value: rule.Message);
                }
            }

            invalidMessageException.ThrowIfContainsErrors();
        }
    }
}



