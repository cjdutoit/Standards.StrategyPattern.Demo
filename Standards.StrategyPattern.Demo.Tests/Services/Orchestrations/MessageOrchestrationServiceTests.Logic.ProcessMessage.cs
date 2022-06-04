// --------------------------------------------------------------------------------
// Copyright (c) Christo du Toit. All rights reserved.
// Licensed under the MIT License. 
// --------------------------------------------------------------------------------

using System.Threading.Tasks;
using FluentAssertions;
using Moq;
using Standards.StrategyPattern.Demo.Models.Messages;
using Xunit;

namespace Standards.StrategyPattern.Demo.Tests.Services.Orchestrations
{
    public partial class MessageOrchestrationServiceTests
    {

        [Fact]
        public async Task ShouldProcessAdtMessage()
        {
            // given
            MessageQueueItem randomAdtMessage = CreateRandomAdtMessage();
            MessageQueueItem inputMessage = randomAdtMessage;
            bool expectedResult = true;

            this.adtMessageProcessor.Setup(processor =>
                processor.ProcessMessageAsync(inputMessage))
                    .ReturnsAsync(expectedResult);

            // when
            bool actualResult = await this.messageOrchestrationService.ProcessMessageAsync(inputMessage);

            // then
            actualResult.Should().Be(expectedResult);

            this.messageProcessorMocks.ForEach(processor => processor.Verify(processor =>
                processor.ProcessorMessageType,
                    Times.AtMostOnce));

            this.adtMessageProcessor.Verify(processor =>
                processor.ProcessMessageAsync(inputMessage),
                    Times.Once);

            this.messageProcessorMocks.ForEach(processor => processor.VerifyNoOtherCalls());
            this.loggingBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldProcessMdmMessage()
        {
            // given
            MessageQueueItem randomMdmMessage = CreateRandomMdmMessage();
            MessageQueueItem inputMessage = randomMdmMessage;
            bool expectedResult = true;

            this.mdmMessageProcessor.Setup(processor =>
                processor.ProcessMessageAsync(inputMessage))
                    .ReturnsAsync(expectedResult);

            // when
            bool actualResult = await this.messageOrchestrationService.ProcessMessageAsync(inputMessage);

            // then
            actualResult.Should().Be(expectedResult);

            this.messageProcessorMocks.ForEach(processor => processor.Verify(processor =>
                processor.ProcessorMessageType,
                    Times.AtMostOnce));

            this.mdmMessageProcessor.Verify(processor =>
                processor.ProcessMessageAsync(inputMessage),
                    Times.Once);

            this.messageProcessorMocks.ForEach(processor => processor.VerifyNoOtherCalls());
            this.loggingBrokerMock.VerifyNoOtherCalls();
        }
    }
}
