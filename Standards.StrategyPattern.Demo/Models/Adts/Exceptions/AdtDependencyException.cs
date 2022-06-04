// --------------------------------------------------------------------------------
// Copyright (c) Christo du Toit. All rights reserved.
// Licensed under the MIT License. 
// --------------------------------------------------------------------------------

using Standards.StrategyPattern.Demo.Models.Base.Exceptions;
using Xeptions;

namespace Standards.StrategyPattern.Demo.Models.Adts.Exceptions
{
    public class AdtDependencyException : BaseDependencyException
    {
        public AdtDependencyException(Xeption innerException) :
            base(message: "ADT dependency error occurred, contact support.", innerException)
        { }
    }
}
