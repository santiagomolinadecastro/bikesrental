using FDV.BikesRental.Service.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FDV.BikesRental.Service.Repositories
{
    public interface IBranchesRepository
    {
        /// <summary>
        /// Get branch by id.
        /// </summary>
        /// <param name="branchId"></param>
        /// <returns></returns>
        Branch Get(int branchId);

        void Update(Branch branch);
    }
}
