// --------------------------------------------------------------------------------
// Copyright (c) Christo du Toit. All rights reserved.
// Licensed under the MIT License. 
// --------------------------------------------------------------------------------

using Standards.StrategyPattern.Demo.Models.Base.Exceptions;
using Xeptions;

namespace Standards.StrategyPattern.Demo.Models.Adts.Exceptions
{
    public class AdtValidationException : BaseValidationException
    {
        public AdtValidationException(Xeption innerException)
            : base(message: "ADT validation errors occurred, please try again.",
                  innerException)
        { }
    }
}
