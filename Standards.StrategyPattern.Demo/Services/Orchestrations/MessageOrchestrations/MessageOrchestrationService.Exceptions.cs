// --------------------------------------------------------------------------------
// Copyright (c) Christo du Toit. All rights reserved.
// Licensed under the MIT License. 
// --------------------------------------------------------------------------------

using System;
using System.Threading.Tasks;
using Standards.StrategyPattern.Demo.Models.Base.Exceptions;
using Standards.StrategyPattern.Demo.Models.MessageQueueItems.Exceptions;
using Xeptions;

namespace Standards.StrategyPattern.Demo.Services.Orchestrations.MessageOrchestrations.Services.Foundations.Messages
{
    public partial class MessageOrchestrationService
    {
        private delegate ValueTask<bool> ReturningBooleanMessageQueueFunction();

        private async ValueTask<bool> TryCatch(
            ReturningBooleanMessageQueueFunction returningBooleanMessageQueueFunction)
        {
            try
            {
                return await returningBooleanMessageQueueFunction();
            }
            catch (NullMessageOrchestrationException nullMessageException)
            {
                throw CreateAndLogValidationException(nullMessageException);
            }
            catch (InvalidMessageOrchestrationException invalidMessageException)
            {
                throw CreateAndLogValidationException(invalidMessageException);
            }
            catch (Xeption ex) when (ex.GetType().IsSubclassOf(typeof(BaseValidationException)))
            {
                throw CreateAndLogDependencyValidationException(ex);
            }
            catch (Xeption ex) when (ex.GetType().IsSubclassOf(typeof(BaseDependencyValidationException)))
            {
                throw CreateAndLogDependencyValidationException(ex);
            }
            catch (Xeption ex) when (ex.GetType().IsSubclassOf(typeof(BaseDependencyException)))
            {
                throw CreateAndLogDependencyException(ex);
            }
            catch (Xeption ex) when (ex.GetType().IsSubclassOf(typeof(BaseServiceException)))
            {
                throw CreateAndLogDependencyException(ex);
            }
            catch (Exception exception)
            {
                var failedMessageServiceException =
                    new FailedMessageOrchestrationServiceException(exception);

                throw CreateAndLogServiceException(failedMessageServiceException);
            }
        }

        private MessageOrchestrationValidationException CreateAndLogValidationException(
            Xeption exception)
        {
            var messageOrchestrationValidationException =
                new MessageOrchestrationValidationException(exception);

            this.loggingBroker.LogError(messageOrchestrationValidationException);

            return messageOrchestrationValidationException;
        }

        private MessageOrchestrationDependencyException CreateAndLogCriticalDependencyException(
            Xeption exception)
        {
            var messageOrchestrationDependencyException = new MessageOrchestrationDependencyException(exception.InnerException as Xeption);
            this.loggingBroker.LogCritical(messageOrchestrationDependencyException);

            return messageOrchestrationDependencyException;
        }

        private MessageOrchestrationDependencyValidationException CreateAndLogDependencyValidationException(
        Xeption exception)
        {
            var messageOrchestrationDependencyValidationException =
                new MessageOrchestrationDependencyValidationException(exception.InnerException as Xeption);

            this.loggingBroker.LogError(messageOrchestrationDependencyValidationException);

            return messageOrchestrationDependencyValidationException;
        }

        private MessageOrchestrationDependencyException CreateAndLogDependencyException(
            Xeption exception)
        {
            var messageOrchestrationDependencyException = new MessageOrchestrationDependencyException(exception.InnerException as Xeption);
            this.loggingBroker.LogError(messageOrchestrationDependencyException);

            return messageOrchestrationDependencyException;
        }

        private MessageOrchestrationServiceException CreateAndLogServiceException(
            Xeption exception)
        {
            var messageOrchestrationServiceException = new MessageOrchestrationServiceException(exception);
            this.loggingBroker.LogError(messageOrchestrationServiceException);

            return messageOrchestrationServiceException;
        }
    }
}
