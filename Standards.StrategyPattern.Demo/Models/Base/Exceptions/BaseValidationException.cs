// --------------------------------------------------------------------------------
// Copyright (c) Christo du Toit. All rights reserved.
// Licensed under the MIT License. 
// --------------------------------------------------------------------------------

using Xeptions;

namespace Standards.StrategyPattern.Demo.Models.Base.Exceptions
{
    public class BaseValidationException : Xeption
    {
        public BaseValidationException(string message, Xeption innerException)
            : base(message, innerException)
        { }
    }
}
