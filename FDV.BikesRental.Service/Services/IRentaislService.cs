using FDV.BikesRental.Service.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FDV.BikesRental.Service.Services
{
    public interface IRentaislService
    {
        /// <summary>
        /// Make a rent.
        /// </summary>
        /// <param name="branchId"></param>
        /// <param name="rentals"></param>
        Branch Rent(int branchId, List<Rental> rentals);
    }
}
