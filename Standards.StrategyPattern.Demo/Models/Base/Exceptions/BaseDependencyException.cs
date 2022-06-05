// --------------------------------------------------------------------------------
// Copyright (c) Christo du Toit. All rights reserved.
// Licensed under the MIT License. 
// --------------------------------------------------------------------------------

using Xeptions;

namespace Standards.StrategyPattern.Demo.Models.Base.Exceptions
{
    public class BaseDependencyException : Xeption
    {
        public BaseDependencyException(string message, Xeption innerException) :
            base(message: message, innerException)
        { }
    }
}
