// --------------------------------------------------------------------------------
// Copyright (c) Christo du Toit. All rights reserved.
// Licensed under the MIT License. 
// --------------------------------------------------------------------------------

using System;
using System.Threading.Tasks;
using Moq;
using Standards.StrategyPattern.Demo.Models.MessageQueueItems.Exceptions;
using Standards.StrategyPattern.Demo.Models.Messages;
using Xeptions;
using Xunit;

namespace Standards.StrategyPattern.Demo.Tests.Services.Orchestrations
{
    public partial class MessageOrchestrationServiceTests
    {
        [Theory]
        [MemberData(nameof(MessageOrchestrationDependencyValidationExceptions))]
        public void ShouldThrowDependencyValidationExceptionOnProcessMessagesIfDependencyValidationErrorOccursAndLogIt(
            Exception dependencyValidationException)
        {
            // given
            MessageQueueItem randomMdmMessage = CreateRandomAdtMessage();
            MessageQueueItem inputMessage = randomMdmMessage;

            var expectedDependencyValidationException =
                new MessageOrchestrationDependencyValidationException(
                    dependencyValidationException.InnerException as Xeption);

            this.messageProcessorMocks.ForEach(processor =>
                processor.Setup(processor =>
                    processor.ProcessMessageAsync(inputMessage))
                        .Throws(dependencyValidationException));

            // when
            ValueTask<bool> processAction =
                this.messageOrchestrationService.ProcessMessageAsync(inputMessage);

            // then
            var actualException = Assert.ThrowsAsync<MessageOrchestrationDependencyValidationException>(() =>
                processAction.AsTask());

            this.loggingBrokerMock.Verify(broker =>
                broker.LogError(It.Is(SameExceptionAs(
                    expectedDependencyValidationException))),
                        Times.Once);

            this.adtMessageProcessor.Verify(processor =>
                processor.ProcessMessageAsync(inputMessage),
                    Times.Once);

            this.messageProcessorMocks.ForEach(processor => processor.Verify(processor =>
                processor.ProcessorMessageType,
                    Times.AtMostOnce));

            this.messageProcessorMocks.ForEach(processor => processor.VerifyNoOtherCalls());
            this.loggingBrokerMock.VerifyNoOtherCalls();
        }

        [Theory]
        [MemberData(nameof(TemplateOrchestrationDependencyExceptions))]
        public async Task ShouldThrowDependencyExceptionOnProcessMessagesIfDependencyErrorOccursAndLogIt(
            Exception dependencyException)
        {
            // given
            MessageQueueItem randomMdmMessage = CreateRandomAdtMessage();
            MessageQueueItem inputMessage = randomMdmMessage;

            var expectedTemplateOrchestrationDependencyException =
                new MessageOrchestrationDependencyException(dependencyException.InnerException as Xeption);

            this.messageProcessorMocks.ForEach(processor =>
                processor.Setup(processor =>
                    processor.ProcessMessageAsync(inputMessage))
                        .Throws(dependencyException));

            // when
            ValueTask<bool> processAction =
                this.messageOrchestrationService.ProcessMessageAsync(inputMessage);

            // then
            var actualException = await Assert.ThrowsAsync<MessageOrchestrationDependencyException>(() =>
                processAction.AsTask());

            this.loggingBrokerMock.Verify(broker =>
                broker.LogError(It.Is(SameExceptionAs(
                    expectedTemplateOrchestrationDependencyException))),
                        Times.Once);

            this.adtMessageProcessor.Verify(processor =>
                processor.ProcessMessageAsync(inputMessage),
                    Times.Once);

            this.messageProcessorMocks.ForEach(processor => processor.Verify(processor =>
                processor.ProcessorMessageType,
                    Times.AtMostOnce));

            this.messageProcessorMocks.ForEach(processor => processor.VerifyNoOtherCalls());
            this.loggingBrokerMock.VerifyNoOtherCalls(); ;
        }

        [Fact]
        public async Task ShoudThrowServiceExceptionOnProcessMessagesIfServiceErrorOccurs()
        {
            // given
            var serviceException = new Exception();
            MessageQueueItem randomMdmMessage = CreateRandomAdtMessage();
            MessageQueueItem inputMessage = randomMdmMessage;

            var failedMessageOrchestrationServiceException =
                new FailedMessageOrchestrationServiceException(serviceException);

            var expectedMessageOrchestrationServiceException =
                new MessageOrchestrationServiceException(failedMessageOrchestrationServiceException);

            this.messageProcessorMocks.ForEach(processor =>
                processor.Setup(processor =>
                    processor.ProcessMessageAsync(inputMessage))
                        .Throws(serviceException));

            // when
            ValueTask<bool> processAction =
                this.messageOrchestrationService.ProcessMessageAsync(inputMessage);

            // then
            var actualException = await Assert.ThrowsAsync<MessageOrchestrationServiceException>(() =>
                processAction.AsTask());

            this.loggingBrokerMock.Verify(broker =>
                broker.LogError(It.Is(SameExceptionAs(
                    expectedMessageOrchestrationServiceException))),
                        Times.Once);

            this.adtMessageProcessor.Verify(processor =>
                processor.ProcessMessageAsync(inputMessage),
                    Times.Once);

            this.messageProcessorMocks.ForEach(processor => processor.Verify(processor =>
                processor.ProcessorMessageType,
                    Times.AtMostOnce));

            this.messageProcessorMocks.ForEach(processor => processor.VerifyNoOtherCalls());
            this.loggingBrokerMock.VerifyNoOtherCalls();
        }
    }
}