using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FDV.BikesRental.Service.Services;
using FDV.BikesRental.Tests.Mocks;
using FDV.BikesRental.Service.Domain;
using System.Collections.Generic;
using FDV.BikesRental.Service.Exceptions.BusinessExceptions;
using FDV.BikesRental.Service.Repositories;

namespace FDV.BikesRental.Tests
{
    [TestClass]
    public class RentalsServiceTest
    {
        private IConfigurationService _configurationService;

        [TestInitialize]
        public void Initialize()
        {
            _configurationService = new ConfigurationServiceMock();
            _configurationService.Initialize();
        }

        [TestMethod]
        public void Should_rent_bikes_normally()
        {
            var rentService = _configurationService.GetInstance<IRentaislService>();

            var rentals = new List<Rental>();

            rentals.Add(new RentalByDay { Amount = 1, Id = 1 });

            var branch = rentService.Rent(1, rentals);

            Assert.AreEqual(branch.AvailableBikes, 2);

            branch = rentService.Rent(1, rentals);

            Assert.AreEqual(branch.AvailableBikes, 1);

            branch = rentService.Rent(1, rentals);

            Assert.AreEqual(branch.AvailableBikes, 0);

           try
            {

                branch = rentService.Rent(1, rentals);

            } catch (NoBikesAvailabilityException ex)
            {
                Assert.IsTrue(0 == 0);

                return;
            }

            Assert.IsTrue(0 != 0);
        }

        [TestMethod]
        public void Should_not_bikes_avaiavility()
        {
            var rentService = _configurationService.GetInstance<IRentaislService>();

            var rentals = new List<Rental>();

            rentals.Add(new RentalByDay { Amount = 1000, Id = 1 });
            rentals.Add(new RentalByHour { Amount = 1000, Id = 2 });
            rentals.Add(new RentalByWeek { Amount = 1000, Id = 3 });

            try {

                rentService.Rent(1, rentals);

            } catch (NoBikesAvailabilityException ex)
            {
                Assert.IsTrue(0 == 0);

                return;
            }

            Assert.IsTrue(0 != 0);
        }

        [TestMethod]
        public void Should_not_add_more_rentals_to_family_renta_maxrentals()
        {
            var rentService = _configurationService.GetInstance<IRentaislService>();

            var rentals = new List<Rental>();

            FamilyRental familyRental = new FamilyRental();

            try { 

                familyRental.AddRental(new RentalByDay { Amount = 1, Id = 1 });
                familyRental.AddRental(new RentalByDay { Amount = 1, Id = 1 });
                familyRental.AddRental(new RentalByDay { Amount = 1, Id = 1 });
                familyRental.AddRental(new RentalByDay { Amount = 1, Id = 1 });
                familyRental.AddRental(new RentalByDay { Amount = 1, Id = 1 });
                familyRental.AddRental(new RentalByDay { Amount = 1, Id = 1 });

            } catch (InvalidFamilyRentalException ex)
            {
                Assert.IsTrue(0 == 0);

                return;
            }

            Assert.IsTrue(0 != 0);
        }

        [TestMethod]
        public void Should_not_get_price_minrentals()
        {
            var rentService = _configurationService.GetInstance<IRentaislService>();

            var rentals = new List<Rental>();

            FamilyRental familyRental = new FamilyRental();

            try
            {

                familyRental.AddRental(new RentalByDay { Amount = 1, Id = 1 });
                familyRental.AddRental(new RentalByDay { Amount = 1, Id = 1 });

                var price = familyRental.Price;
            }
            catch (InvalidFamilyRentalException ex)
            {
                Assert.IsTrue(0 == 0);

                return;
            }

            Assert.IsTrue(0 != 0);
        }

        [TestMethod]
        public void Should_get_family_rental_price()
        {
            var rentService = _configurationService.GetInstance<IRentaislService>();

            var rentals = new List<Rental>();

            FamilyRental familyRental = new FamilyRental();

            familyRental.AddRental(new RentalByDay { Amount = 1, Id = 1 });
            familyRental.AddRental(new RentalByDay { Amount = 1, Id = 1 });
            familyRental.AddRental(new RentalByDay { Amount = 1, Id = 1 });

            var price = familyRental.Price;


            // TODO: Calculate number from configuration file values.
            Assert.IsTrue(price == 42);

            familyRental = new FamilyRental();

            familyRental.AddRental(new RentalByDay { Amount = 1, Id = 1 });
            familyRental.AddRental(new RentalByDay { Amount = 1, Id = 1 });
            familyRental.AddRental(new RentalByDay { Amount = 1, Id = 1 });
            familyRental.AddRental(new RentalByDay { Amount = 1, Id = 1 });

            price = familyRental.Price;

            // TODO: Calculate number from configuration file values.
            Assert.IsTrue(price == 56);

            familyRental = new FamilyRental();

            familyRental.AddRental(new RentalByDay { Amount = 1, Id = 1 });
            familyRental.AddRental(new RentalByDay { Amount = 1, Id = 1 });
            familyRental.AddRental(new RentalByDay { Amount = 1, Id = 1 });
            familyRental.AddRental(new RentalByDay { Amount = 1, Id = 1 });
            familyRental.AddRental(new RentalByDay { Amount = 1, Id = 1 });

            price = familyRental.Price;

            Assert.IsTrue(price == 70);
        }
    }
}
