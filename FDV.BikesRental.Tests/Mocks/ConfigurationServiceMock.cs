using FDV.BikesRental.Service.Domain;
using FDV.BikesRental.Service.Repositories;
using FDV.BikesRental.Service.Repositories.Mocks;
using FDV.BikesRental.Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace FDV.BikesRental.Tests.Mocks
{
    class  ConfigurationServiceMock : IConfigurationService
    {
        private UnityContainer _container;
        
        public void Initialize()
        {
            _container = new UnityContainer();

            _container.RegisterType<IBranchesRepository, BranchesRepositoryMock>();
            _container.RegisterType<IRentaislService, RentalsService>();
            _container.RegisterType<Rental, FamilyRental>();
            _container.RegisterType<Rental, RentalByDay>();
            _container.RegisterType<Rental, RentalByHour>();
            _container.RegisterType<Rental, RentalByWeek>();
        }

        public T GetInstance<T>()
        {
            return _container.Resolve<T>();
        }
    }
}
