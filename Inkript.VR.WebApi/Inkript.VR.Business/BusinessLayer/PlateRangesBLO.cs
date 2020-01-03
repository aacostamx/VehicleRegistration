using Inkript.VR.Business.DataAccessLayer;
using Inkript.VR.Models;
using System.Collections.Generic;
using System.Linq;

namespace Inkript.VR.Business
{
    public class PlateRangesBLO
    {
        private PlateRangesDAO _da { get; set; }

        public PlateRangesBLO()
        {
            _da = new PlateRangesDAO();
        }

        public GenericPagedList<PlateRanges> GetAllPlateRangesPaged(int pageNumber, int pageSize)
        {
            return _da.GetAllPaged(pageNumber, pageSize);
        }

        public int CreatePlateRanges(PlateRanges plateRange)
        {
            return _da.CreatePlateRanges(plateRange);
        }

        public int CheckPlateNumberPool(int startNumber, int endNumber)
        {
            return _da.CheckPlateNumberPool(startNumber, endNumber);
        }

        public bool PlateRangeExist(string rangeName)
        {
            return _da.PlateRangeExist(rangeName);
        }

        public void UpdatePlateRanges(PlateRanges plateRange)
        {
            _da.SaveOrUpdate(plateRange, string.Empty);
        }

        public PlateRanges GetByPlateRangesId(int plateRangeId)
        {
            return _da.GetById(plateRangeId);
        }

        public bool DeletePlateRanges(int plateRangeId)
        {
            return _da.Delete(GetByPlateRangesId(plateRangeId));
        }

        public GenerateRandomNumber GenerateRandomNumber(int branchId, int sectorId, int vehicleTypeId)
        {
            return _da.GenerateRandomNumber(branchId, sectorId, vehicleTypeId);
        }

        public bool PlateRangeIdExist(int plateRangeId)
        {
            return _da.Exist(plateRangeId);
        }

        public void UpdatePlateRange(PlateRanges plateRange)
        {
            _da.SaveOrUpdate(plateRange, string.Empty);
        }

        public bool ValidStatus(int statusId)
        {
            return _da.ValidStatus(statusId);
        }

        public List<PlateRanges> GetRangesByStatus(int statusId)
        {
            return _da.GetRangesByStatus(statusId);
        }

        public List<PlateRanges> PlateRangesFilter(int? sectorId, int? branchId, int? vehicleTypeId, int? plateCodeId)
        {
            return _da.PlateRangesFilter(sectorId, branchId, vehicleTypeId, plateCodeId).ToList();
        }

        public PoolInfo PlateNumberPoolInfo(int? rangeId, string rangeName)
        {
            return _da.PlateNumberPoolInfo(rangeId, rangeName);
        }
    }
}
