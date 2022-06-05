// --------------------------------------------------------------------------------
// Copyright (c) Christo du Toit. All rights reserved.
// Licensed under the MIT License. 
// --------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Moq;
using Standards.StrategyPattern.Demo.Brokers.Loggers;
using Standards.StrategyPattern.Demo.Models.Adts.Exceptions;
using Standards.StrategyPattern.Demo.Models.Messages;
using Standards.StrategyPattern.Demo.Services.Orchestrations.MessageOrchestrations.Services.Foundations.Messages;
using Standards.StrategyPattern.Demo.Services.Processings.MessageProcessors;
using Tynamix.ObjectFiller;
using Xeptions;
using Xunit;

namespace Standards.StrategyPattern.Demo.Tests.Services.Orchestrations
{
    public partial class MessageOrchestrationServiceTests
    {
        private readonly Mock<IMessageProcessor> adtMessageProcessor;
        private readonly Mock<IMessageProcessor> mdmMessageProcessor;
        private readonly Mock<ILoggingBroker> loggingBrokerMock;
        private readonly List<Mock<IMessageProcessor>> messageProcessorMocks = new List<Mock<IMessageProcessor>>();
        private readonly IMessageOrchestrationService messageOrchestrationService;

        public MessageOrchestrationServiceTests()
        {
            this.adtMessageProcessor = new Mock<IMessageProcessor>();
            this.adtMessageProcessor.Setup(processor => processor.ProcessorMessageType)
                .Returns("ADT");

            this.mdmMessageProcessor = new Mock<IMessageProcessor>();
            this.mdmMessageProcessor.Setup(processor => processor.ProcessorMessageType)
                .Returns("MDM");

            this.loggingBrokerMock = new Mock<ILoggingBroker>();
            this.messageProcessorMocks.Add(this.adtMessageProcessor);
            this.messageProcessorMocks.Add(this.mdmMessageProcessor);
            List<IMessageProcessor> messageProcessors = new List<IMessageProcessor>();
            this.messageProcessorMocks.ForEach(processor => messageProcessors.Add(processor.Object));

            this.messageOrchestrationService = new MessageOrchestrationService(
                messageProcessors: messageProcessors,
                loggingBroker: this.loggingBrokerMock.Object);
        }

        private static Expression<Func<Exception, bool>> SameExceptionAs(Exception expectedException)
        {
            return actualException =>
                actualException.GetType().FullName == expectedException.GetType().FullName
                && actualException.Message == expectedException.Message
                && actualException.InnerException.GetType().FullName == expectedException.InnerException.GetType().FullName
                && actualException.InnerException.Message == expectedException.InnerException.Message
                && ((Xeption)actualException.InnerException).DataEquals(expectedException.InnerException.Data);
        }

        public static TheoryData MessageOrchestrationDependencyValidationExceptions()
        {
            string exceptionMessage = GetRandomString();
            var innerException = new Xeption(exceptionMessage);

            return new TheoryData<Exception>()
            {
                new AdtValidationException(innerException),
                new MdmValidationException(innerException),
                new AdtDependencyValidationException(innerException),
                new MdmDependencyValidationException(innerException),
            };
        }

        public static TheoryData TemplateOrchestrationDependencyExceptions()
        {
            string exceptionMessage = GetRandomString();
            var innerException = new Xeption(exceptionMessage);

            return new TheoryData<Exception>()
            {
                new AdtDependencyException(innerException),
                new MdmDependencyException(innerException),
                new AdtServiceException(innerException),
                new MdmServiceException(innerException),
            };
        }

        private static int GetRandomNumber() =>
            new IntRange(min: 2, max: 10).GetValue();

        private static string GetRandomString() =>
            new MnemonicString(wordCount: GetRandomNumber()).GetValue();

        private static MessageQueueItem CreateRandomAdtMessage() =>
            CreateTemplateFiller("ADT-A04").Create();

        private static MessageQueueItem CreateRandomMdmMessage() =>
            CreateTemplateFiller("MDM").Create();

        private static Filler<MessageQueueItem> CreateTemplateFiller(string messageType)
        {
            var filler = new Filler<MessageQueueItem>();
            filler.Setup()
                .OnProperty(message => message.MessageType).Use(messageType);

            return filler;
        }
    }
}
