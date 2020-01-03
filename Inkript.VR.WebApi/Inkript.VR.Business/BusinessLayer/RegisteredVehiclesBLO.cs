using System;
using System.Collections.Generic;
using System.Linq;
using Inkript.VR.Business.DataAccessLayer;
using Inkript.VR.Models;

namespace Inkript.VR.Business.BusinessLayer
{
    public class RegisteredVehiclesBLO
    {
        private RegisteredVehiclesDAO _da { get; set; }

        public RegisteredVehiclesBLO()
        {
            _da = new RegisteredVehiclesDAO();
        }

        public GenericPagedList<RegisteredVehicles> GetAllRegisteredVehiclesPaged(int pageNumber, int pageSize)
        {
            return _da.GetAllPaged(pageNumber, pageSize);
        }

        public CarStatus GetRegisteredVehicleStatus(int carUniqueNumber)
        {
            return _da.GetRegisteredVehicleStatus(carUniqueNumber);
        }

        public RegisteredVehicles GetRegisteredCarsbyId(int registerdCarsId)
        {
            return _da.GetById(registerdCarsId);
        } 

        public RegisteredVehicles GetRegisteredCarsByCarUniqueNumber(int carUniqueNumber)
        {
            return _da.GetRegisteredVehicles(carUniqueNumber);
        }

        public bool CarUniqueNumberExist(int carUniqueNumber)
        {
            return _da.CarUniqueNumberExist(carUniqueNumber);
        }

        public RegisteredVehicles GetRegisteredVehicleBy(int? plateNumber, int? plateCodeId, int? carUniqueNumber, int? carStatusId)
        {
            return _da.GetRegisteredVehicleBy(plateNumber, plateCodeId, carUniqueNumber, carStatusId);
        }

        public List<RegisteredVehicles> GetRegisteredVehicles(int? carUniqueNumber, string plateNumber, int? plateCodeId)
        {
            return _da.GetRegisteredVehicles(carUniqueNumber, plateNumber, plateCodeId).ToList();
        }
    }
}
