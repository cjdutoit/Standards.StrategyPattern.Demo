// --------------------------------------------------------------------------------
// Copyright (c) Christo du Toit. All rights reserved.
// Licensed under the MIT License. 
// --------------------------------------------------------------------------------

using Xeptions;

namespace Standards.StrategyPattern.Demo.Models.Base.Exceptions
{
    public class NotFoundBaseException : Xeption
    {
        public NotFoundBaseException(string message)
            : base(message)
        { }
    }
}
