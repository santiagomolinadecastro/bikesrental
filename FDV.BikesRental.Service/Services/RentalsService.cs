using FDV.BikesRental.Service.Domain;
using FDV.BikesRental.Service.Exceptions;
using FDV.BikesRental.Service.Exceptions.BusinessExceptions;
using FDV.BikesRental.Service.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FDV.BikesRental.Service.Services
{
    public class RentalsService: IRentaislService
    {
        #region - Private attributes -

        private readonly IBranchesRepository _branches;

        #endregion - Private attributes -

        #region - Public Methods -

        public RentalsService(IBranchesRepository branches)
        {
            _branches = branches;
        }

        public Branch Rent(int branchId, List<Rental> rentals)
        {
            var branch = _branches.Get(branchId);

            foreach (var rental in rentals)
            {
                RentOne(branch, rental);
            }

            return branch;
        }
        
        #endregion - Public Methods -

        #region - Private Methods -

        private void RentOne(Branch branch, Rental rental)
        {
            if (rental.Amount <= branch.AvailableBikes)
            {
                branch.AvailableBikes -= rental.Amount;
            }
            else
            {
                throw new NoBikesAvailabilityException();
            }

            _branches.Update(branch);
        }

        #endregion - Private Methods -
    }
}
