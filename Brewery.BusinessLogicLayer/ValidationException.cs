using System;
using System.Collections.Generic;
using System.Text;

namespace Brewery.BusinessLogicLayer
{
    class ValidationException : Exception
    {
        public int Code { get; set; }
        public ValidationException(int code, string msg) : base(msg)
        {
            Code = code;
        }
    }
}
