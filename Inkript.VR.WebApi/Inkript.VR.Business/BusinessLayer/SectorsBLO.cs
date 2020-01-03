using System;
using System.Collections.Generic;
using System.Linq;
using Inkript.VR.Business.DataAccessLayer;
using Inkript.VR.Models;

namespace Inkript.VR.Business.BusinessLayer
{
    public class SectorsBLO
    {
        private SectorsDAO _da { get; set; }

        public SectorsBLO()
        {
            _da = new SectorsDAO();
        }

        public GenericPagedList<Sectors> GetAllSectorsPaged(int pageNumber, int pageSize)
        {
            return _da.GetAllPaged(pageNumber, pageSize);
        }

        public bool SectorExist(int sectorId)
        {
            return _da.Exist(sectorId);
        }

        public Sectors GetBySectorId(int sectorId)
        {
            return _da.GetById(sectorId);
        }

        public bool SectorNameEnExist(string sectorNameEn)
        {
            return _da.SectorNameEnExist(sectorNameEn);
        }

        public bool SectorNameArExist(string sectorNameAr)
        {
            return _da.SectorNameArExist(sectorNameAr);
        }

        public bool ValidateSectorNameEn(int sectorId, string sectorNameEn)
        {
            return _da.ValidateSectorNameEn(sectorId, sectorNameEn);
        }

        public bool ValidateSectorNameAr(int sectorId, string sectorNameAr)
        {
            return _da.ValidateSectorNameAr(sectorId, sectorNameAr);
        }

        public void CreateSector(Sectors sector)
        {
            _da.SaveOrUpdate(sector, string.Empty);
        }

        public void UpdateSector(Sectors entity)
        {
            _da.SaveOrUpdate(entity, string.Empty);
        }

        public bool DeleteSector(int sectorId)
        {
            return _da.Delete(GetBySectorId(sectorId));
        }

        public List<Sectors> SectorFilter(string search)
        {
            return _da.SectorFilter(search).ToList();
        }

        public List<Sectors> GetAllSectors()
        {
            return _da.GetAll().ToList();
        }

        public List<Sectors> GetSectorsByVehicleType(int vehicleTypeId)
        {
            return _da.GetSectorsByVehicleType(vehicleTypeId).ToList();
        }

        public List<SectorsLimit> GetSectorsAtRisk(int sectorId, int? vehicleTypeId, int? plateCodeId, int? branchId)
        {
            return _da.GetSectorsAtRisk(sectorId, vehicleTypeId, plateCodeId, branchId).ToList();
        }

        public bool? ForRent(int? sectorId)
        {
            bool forRent = false;

            if (sectorId.HasValue)
            {
                forRent = sectorId.Value == 15;
            }

            return forRent;
        }
    }
}
