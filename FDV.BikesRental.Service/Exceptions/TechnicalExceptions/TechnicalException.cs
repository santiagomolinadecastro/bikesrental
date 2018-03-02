using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FDV.BikesRental.Service.Exceptions
{
    public class TechnicalException: Exception
    {
        public TechnicalException()
            : base() { }

        public TechnicalException(string message)
            : base(message) { }

        public TechnicalException(string format, params object[] args)
            : base(string.Format(format, args)) { }

        public TechnicalException(string message, Exception innerException)
            : base(message, innerException) { }

        public TechnicalException(string format, Exception innerException, params object[] args)
            : base(string.Format(format, args), innerException) { }
    }
}
