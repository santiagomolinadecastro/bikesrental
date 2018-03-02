using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FDV.BikesRental.Service.Domain
{
    public class RentalsRequest
    {
        public int BranchId { get; set; }
        public List<Rental> Rentals { get; set; }
    }
}
