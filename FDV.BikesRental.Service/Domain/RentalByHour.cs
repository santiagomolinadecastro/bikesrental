using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Configuration;

namespace FDV.BikesRental.Service.Domain
{
    public class RentalByHour: Rental
    {
        public RentalByHour()
        {
            Price = int.Parse(ConfigurationManager.AppSettings["ByHour"]);
        }
    }
}
