using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FDV.BikesRental.Service.Exceptions.BusinessExceptions
{
    public class NoBikesAvailabilityException: Exception
    {
        public NoBikesAvailabilityException()
            : base() { }

        public NoBikesAvailabilityException(string message)
            : base(message) { }

        public NoBikesAvailabilityException(string format, params object[] args)
            : base(string.Format(format, args)) { }

        public NoBikesAvailabilityException(string message, Exception innerException)
            : base(message, innerException) { }

        public NoBikesAvailabilityException(string format, Exception innerException, params object[] args)
            : base(string.Format(format, args), innerException) { }
    }
}
