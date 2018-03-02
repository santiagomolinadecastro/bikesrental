using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FDV.BikesRental.Service.Services
{
    public interface IConfigurationService
    {
        /// <summary>
        /// Initialize all domain dependencies.
        /// </summary>
        void Initialize();

        /// <summary>
        /// Get instance from container.
        /// </summary>
        T GetInstance<T>();
    }
}
