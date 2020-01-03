using Inkript.Logging;
using Inkript.VR.Business.Helpers;
using Inkript.VR.Models;
using NHibernate;
using NHibernate.Linq;
using NHibernate.Transform;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Inkript.VR.Business.DataAccessLayer
{
    public class RegisteredVehiclesDAO : GenericDAO<RegisteredVehicles>
    {
        public RegisteredVehicles GetRegisteredVehicles(int carUniqueNumber)
        {
            using (ISession session = NHibernateHelper.OpenSession())
                try
                {
                    return session.Query<RegisteredVehicles>()
                        .Where(c => (c.CarUniqueNumber.CarUniqueNumberVal == carUniqueNumber))
                        .FirstOrDefault();
                }
                catch (Exception ex)
                {
                    session.Clear();
                    Log.ErrorFormat("Cannot Get Registered Vehicle by CarUniqueNumber {0}", carUniqueNumber, ex);
                    throw new DALException("Cannot GetRegisteredCars", ex);
                }
        }

        public RegisteredVehicles GetRegisteredVehicleBy(int? plateNumber, int? plateCodeId, int? carUniqueNumber, int? carStatusId)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                try
                {
                    return session.GetNamedQuery("GetRegisteredCarBy")
                        .SetParameter("PlateNumber", plateNumber)
                        .SetParameter("PlateCodeId", plateCodeId)
                        .SetParameter("CarUniqueNumber", carUniqueNumber)
                        .SetParameter("CarStatusId", carStatusId)
                        .UniqueResult<RegisteredVehicles>();
                }
                catch (Exception ex)
                {
                    session.Clear();
                    Log.ErrorFormat("Cannot Get Get Registered Vehicle By Parameters", ex);
                    throw new DALException("Cannot GetRegisteredVehicleBy", ex);
                }
            }
        }

        public IList<RegisteredVehicles> GetRegisteredVehicles(int? carUniqueNumber, string plateNumber, int? plateCodeId)
        {
            IList<RegisteredVehicles> registeredVehicles = new List<RegisteredVehicles>();

            using (ISession session = NHibernateHelper.OpenSession())
                try
                {
                    if (carUniqueNumber.HasValue)
                    {
                        registeredVehicles = session.Query<RegisteredVehicles>()
                            .Where(c => c.CarUniqueNumber.CarUniqueNumberVal == carUniqueNumber)
                            .ToList();
                    }
                    if (plateCodeId.HasValue && !string.IsNullOrEmpty(plateNumber))
                    {
                        registeredVehicles = session.Query<RegisteredVehicles>()
                            .Where(c => c.PlateNumber == plateNumber && c.PlateCodes.PlateCodeId == plateCodeId)
                            .ToList();
                    }
                    if (registeredVehicles != null
                        && registeredVehicles.Count > 0)
                    {
                        foreach (var vehicles in registeredVehicles)
                        {
                            if (vehicles.VehicleOwnership != null
                                && vehicles.VehicleOwnership.Count > 0)
                            {
                                foreach (var owners in vehicles.VehicleOwnership)
                                {
                                    if (owners != null && owners.OwnerId > 0)
                                    {
                                        if (owners.OwnerTypeId == (int)FlagOwnerTypes.Persons)
                                        {
                                            Person person = session.Query<Person>()
                                                .Where(c => c.PersonId == owners.OwnerId)
                                                .FirstOrDefault();

                                            Owners owner = new Owners
                                            {
                                                PersonId = person.PersonId,
                                                DrivingLicenseId = person.DrivingLicenseId,
                                                NationalId = person.NationalId,
                                                FirstName = person.FirstName,
                                                MiddleName = person.MiddleName,
                                                LastName = person.LastName,
                                                MotherName = person.MotherName,
                                                MotherMaidenName = person.MotherMaidenName,
                                                DateOfBirth = person.DateOfBirth,
                                                CityOfBirth = person.CityOfBirth,
                                                CountryOfBirth = person.CountryOfBirth,
                                                CityId = person.CityId,
                                                Street = person.Street,
                                                Building = person.Building,
                                                Floor = person.Floor,
                                                PIN = person.PIN,
                                                AddressDetails = person.AddressDetails,
                                                NumberOfRegistry = person.NumberOfRegistry,
                                                Phone = person.Phone
                                            };
                                            vehicles.Owners.Add(owner);
                                        }

                                        if (owners.OwnerTypeId == (int)FlagOwnerTypes.Company)
                                        {
                                            Organization company = session.Query<Organization>()
                                                .Where(c => c.OrganizationId == owners.OwnerId)
                                                .FirstOrDefault();

                                            Owners owner = new Owners
                                            {
                                                OrganizationId = company.OrganizationId,
                                                OrganizationName = company.OrganizationName,
                                                RegistrationNumber = company.RegistrationNumber,
                                                RegisterRegionId = company.RegisterRegionId,
                                                MOFNumber = company.MOFNumber,
                                                SectorId = company.SectorId,
                                                CompanyClassId = company.CompanyClassId,
                                                CompanyCategoryId = company.CompanyCategoryId,
                                                RegionId = company.RegionId,
                                                Street = company.Street,
                                                Building = company.Building,
                                                StatusId = company.Status.StatusId
                                            };
                                            vehicles.Owners.Add(owner);
                                        }
                                    }
                                }
                            }

                            if (vehicles.PlateCodes == null)
                            {
                                vehicles.PlateCodes = new PlateCodes();
                            }

                            if (vehicles.Colors == null)
                            {
                                vehicles.Colors = new Colors();
                            }

                            if (vehicles.Utilization == null)
                            {
                                vehicles.Utilization = new Utilization();
                            }

                            if (vehicles.TrunkType == null)
                            {
                                vehicles.TrunkType = new TrunkType();
                            }

                            if (vehicles.FuelTypes == null)
                            {
                                vehicles.FuelTypes = new FuelTypes();
                            }

                            if (vehicles.Sectors == null)
                            {
                                vehicles.Sectors = new Sectors();
                            }

                            if (vehicles.VehicleTypes == null)
                            {
                                vehicles.VehicleTypes = new VehicleTypes();
                            }

                            if (vehicles.CarStatus == null)
                            {
                                vehicles.CarStatus = new CarStatus();
                            }

                            if (vehicles.Branches == null)
                            {
                                vehicles.Branches = new Branches();
                            }

                            if (vehicles.Status == null)
                            {
                                vehicles.Status = new Status();
                            }
                        }
                    }
                    return registeredVehicles;
                }
                catch (Exception ex)
                {
                    session.Clear();
                    Log.ErrorFormat("Cannot Get Registered Vehicles", ex);
                    throw new DALException("Cannot GetRegisteredVehicles", ex);
                }
        }

        public bool CarUniqueNumberExist(int carUniqueNumber)
        {
            using (ISession session = NHibernateHelper.OpenSession())
                try
                {
                    return session.Query<RegisteredVehicles>()
                        .Any(c => (c.CarUniqueNumber.CarUniqueNumberVal == carUniqueNumber));
                }
                catch (Exception ex)
                {
                    session.Clear();
                    Log.ErrorFormat("Cannot check if Registered Vehicle Exist {0}", carUniqueNumber, ex);
                    throw new DALException("Cannot RegisteredVehicleExist", ex);
                }
        }

        public CarStatus GetRegisteredVehicleStatus(int carUniqueNumber)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                try
                {
                    return session.Query<RegisteredVehicles>()
                        .Where(c => c.CarUniqueNumber.CarUniqueNumberVal == carUniqueNumber)
                        .Select(c => c.CarStatus)
                        .FirstOrDefault();
                }
                catch (Exception ex)
                {
                    session.Clear();
                    Log.ErrorFormat("Cannot Get Registered Vehicle Status by Car Unique Number", carUniqueNumber, ex);
                    throw new DALException("Cannot GetRegisteredVehicleStatus", ex);
                }
            }
        }
    }
}
