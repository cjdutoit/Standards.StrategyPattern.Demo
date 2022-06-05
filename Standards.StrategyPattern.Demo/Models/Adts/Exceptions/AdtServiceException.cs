// --------------------------------------------------------------------------------
// Copyright (c) Christo du Toit. All rights reserved.
// Licensed under the MIT License. 
// --------------------------------------------------------------------------------

using System;
using Standards.StrategyPattern.Demo.Models.Base.Exceptions;
using Xeptions;

namespace Standards.StrategyPattern.Demo.Models.Adts.Exceptions
{
    public class AdtServiceException : BaseServiceException
    {
        public AdtServiceException(Exception innerException)
            : base(message: "ADT service error occurred, contact support.", innerException as Xeption)
        { }
    }
}
