using FDV.BikesRental.Service.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Unity;

namespace FDV.BikesRental.Service.Services
{
    public class ConfigurationService: IConfigurationService
    {
        #region - Private Attributes -

        private UnityContainer _container;

        private ConfigurationService() { }

        #endregion - Private Attributes -

        #region - Public Methods -

        public void Initialize()
        {
            _container = new UnityContainer();

            _container.RegisterType<IBranchesRepository, BranchesRepository>();
            _container.RegisterType<IRentaislService, RentalsService>();
        }

        public T GetInstance<T>()
        {
            return _container.Resolve<T>();
        }


        #endregion - Public Methods -
    }
}
