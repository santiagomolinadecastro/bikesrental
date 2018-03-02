using FDV.BikesRental.Service.Exceptions;
using FDV.BikesRental.Service.Exceptions.BusinessExceptions;
using FDV.BikesRental.Service.Repositories;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace FDV.BikesRental.Service.Domain
{
    public class FamilyRental : Rental
    {
        #region - Private Attributes -

        private readonly int _maxFamilyRentals;
        private readonly int _minFamilyRentals;
        private readonly double _discountFamilyRentals;
        private List<Rental> _rentals;

        #endregion - Private Attributes -

        #region - Properties -

        public override double Price
        {
            get
            {
                if (_rentals.Count < _minFamilyRentals) throw new InvalidFamilyRentalException();

                double result = 0;

                foreach (var rental in _rentals)
                {
                    var discount = rental.Price * rental.Amount * _discountFamilyRentals;

                    result += rental.Price * rental.Amount  - discount;
                }

                return result;
            }
        }

        #endregion - Properties -

        #region - Public Methods -

        public FamilyRental()
        {
            try
            {
                _rentals = new List<Rental>();
                _maxFamilyRentals = int.Parse(ConfigurationManager.AppSettings["MaxFamilyRentals"]);
                _minFamilyRentals = int.Parse(ConfigurationManager.AppSettings["MinFamilyRentals"]);
                _discountFamilyRentals = double.Parse(ConfigurationManager.AppSettings["DiscountFamiliRental"], CultureInfo.InvariantCulture);
                
            } catch (FormatException ex)
            {
                // Log something.

                throw new TechnicalException("There are wrong configurations. Check app.json file.", ex);
            }
        }

        public void AddRental(Rental rental)
        {
            if ((_rentals.Count >= _maxFamilyRentals)) throw new InvalidFamilyRentalException();
            else _rentals.Add(rental);

        }

        #endregion - Public Methods -
    }
}
