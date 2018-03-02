using FDV.BikesRental.Service.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FDV.BikesRental.Service.Repositories.Mocks
{
    public class BranchesRepositoryMock: IBranchesRepository
    {
        List<Branch> _branches;

        public BranchesRepositoryMock()
        {
            _branches = new List<Branch>();
            _branches.Add(new Branch { Id = 1, AvailableBikes = 3 });
        }


        public Branch Get(int branchId)
        {
            return _branches.Where(b => b.Id == branchId).FirstOrDefault();
        }

        public void Update(Branch branch)
        {
            _branches[0] = branch;
        }
    }
}
