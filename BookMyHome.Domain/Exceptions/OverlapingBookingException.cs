using System;
using System.Collections.Generic;
using System.Text;

namespace BookMyHome.Domain.Exceptions
{
    public class OverlapingBookingException : Exception
    {
        public OverlapingBookingException()
        {
        }

        public OverlapingBookingException(string message)
            : base(message)
        {
        }
    }
}
