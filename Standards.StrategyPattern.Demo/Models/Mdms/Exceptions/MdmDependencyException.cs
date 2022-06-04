// --------------------------------------------------------------------------------
// Copyright (c) Christo du Toit. All rights reserved.
// Licensed under the MIT License. 
// --------------------------------------------------------------------------------

using Standards.StrategyPattern.Demo.Models.Base.Exceptions;
using Xeptions;

namespace Standards.StrategyPattern.Demo.Models.Adts.Exceptions
{
    public class MdmDependencyException : BaseDependencyException
    {
        public MdmDependencyException(Xeption innerException) :
            base(message: "MDM dependency error occurred, contact support.", innerException)
        { }
    }
}
