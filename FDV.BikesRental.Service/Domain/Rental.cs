using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FDV.BikesRental.Service.Domain
{
    abstract public class Rental
    {
        public int Id { get; set; }
        public int Amount { get; set; }
        public virtual double Price { get; set; }
    }
}
