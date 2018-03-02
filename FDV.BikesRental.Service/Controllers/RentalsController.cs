using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FDV.BikesRental.Service.Domain;
using FDV.BikesRental.Service.Services;

namespace FDV.BikesRental.Service.Controllers
{
    [Route("api")]
    public class RentalsController : Controller
    {
        private readonly IConfigurationService _configurationService;

        public RentalsController()
        {
            _configurationService.Initialize();
        }

        [HttpPost("branches/{id}")]
        public void Rent([FromBody]RentalsRequest request)
        {
            IRentaislService rentailService =_configurationService.GetInstance<IRentaislService>();

            rentailService.Rent(request.BranchId, request.Rentals);
        }
    }
}
