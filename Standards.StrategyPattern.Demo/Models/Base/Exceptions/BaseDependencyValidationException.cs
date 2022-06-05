// --------------------------------------------------------------------------------
// Copyright (c) Christo du Toit. All rights reserved.
// Licensed under the MIT License. 
// --------------------------------------------------------------------------------

using Xeptions;

namespace Standards.StrategyPattern.Demo.Models.Base.Exceptions
{
    public class BaseDependencyValidationException : Xeption
    {
        public BaseDependencyValidationException(string message, Xeption innerException)
            : base(message, innerException)
        { }
    }
}
