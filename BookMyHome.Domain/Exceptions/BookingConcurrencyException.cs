using System;
using System.Collections.Generic;
using System.Text;

namespace BookMyHome.Domain.Exceptions
{
    public class BookingConcurrencyException : Exception
    {
        public BookingConcurrencyException(string message)
            : base(message)
        {
        }
    }
}
