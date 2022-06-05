// --------------------------------------------------------------------------------
// Copyright (c) Christo du Toit. All rights reserved.
// Licensed under the MIT License. 
// --------------------------------------------------------------------------------

using Standards.StrategyPattern.Demo.Models.Base.Exceptions;
using Xeptions;

namespace Standards.StrategyPattern.Demo.Models.Adts.Exceptions
{
    public class MdmDependencyValidationException : BaseDependencyValidationException
    {
        public MdmDependencyValidationException(Xeption innerException)
            : base(message: "MDM dependency validation occurred, please try again.", innerException)
        { }
    }
}
