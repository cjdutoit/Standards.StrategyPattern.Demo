// --------------------------------------------------------------------------------
// Copyright (c) Christo du Toit. All rights reserved.
// Licensed under the MIT License. 
// --------------------------------------------------------------------------------

using System;
using System.Threading.Tasks;
using Moq;
using Standards.StrategyPattern.Demo.Models.MessageQueueItems.Exceptions;
using Standards.StrategyPattern.Demo.Models.Messages;
using Xunit;

namespace Standards.StrategyPattern.Demo.Tests.Services.Orchestrations
{
    public partial class MessageOrchestrationServiceTests
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public async Task ShouldThrowValidationExceptioIfMessageIsInvalidAndLogItAsync(
            string invalidText)
        {
            // given
            var invalidMessageQueueItem = new MessageQueueItem
            {
                Id = (Guid)default,
                Message = invalidText,
                MessageType = invalidText
            };

            var invalidMessageOrchestrationException =
                new InvalidMessageOrchestrationException();

            invalidMessageOrchestrationException.AddData(
                key: nameof(MessageQueueItem.Id),
                values: "Id is required");

            invalidMessageOrchestrationException.AddData(
                key: nameof(MessageQueueItem.Message),
                values: "Text is required");

            invalidMessageOrchestrationException.AddData(
                key: nameof(MessageQueueItem.MessageType),
                values: "Text is required");

            var expectedPostValidationException =
                new MessageOrchestrationValidationException(invalidMessageOrchestrationException);

            // when
            ValueTask<bool> processTask =
                this.messageOrchestrationService.ProcessMessageAsync(invalidMessageQueueItem);

            // then
            await Assert.ThrowsAsync<MessageOrchestrationValidationException>(() =>
               processTask.AsTask());

            this.messageProcessorMocks.ForEach(processor => processor.Verify(processor =>
                processor.ProcessorMessageType,
                    Times.AtMostOnce));

            this.loggingBrokerMock.Verify(broker =>
                broker.LogError(It.Is(SameExceptionAs(
                    expectedPostValidationException))),
                        Times.Once);

            this.messageProcessorMocks.ForEach(processor => processor.Verify(processor =>
                processor.ProcessMessageAsync(invalidMessageQueueItem),
                    Times.Never));

            this.loggingBrokerMock.VerifyNoOtherCalls();
            this.messageProcessorMocks.ForEach(processor => processor.VerifyNoOtherCalls());
        }
    }
}
