using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FDV.BikesRental.Service.Exceptions.BusinessExceptions
{
    public class InvalidFamilyRentalException: BusinessException
    {
        public InvalidFamilyRentalException()
            : base() { }

        public InvalidFamilyRentalException(string message)
            : base(message) { }

        public InvalidFamilyRentalException(string format, params object[] args)
            : base(string.Format(format, args)) { }

        public InvalidFamilyRentalException(string message, Exception innerException)
            : base(message, innerException) { }

        public InvalidFamilyRentalException(string format, Exception innerException, params object[] args)
            : base(string.Format(format, args), innerException) { }
    }
}
