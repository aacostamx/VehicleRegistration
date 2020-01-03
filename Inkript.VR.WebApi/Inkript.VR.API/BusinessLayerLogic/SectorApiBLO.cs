using Inkript.Logging;
using Inkript.VR.API.Models;
using Inkript.VR.Business.BusinessLayer;
using Inkript.VR.Models;
using System;
using System.Collections.Generic;

namespace Inkript.VR.API
{
    public class SectorApiBLO
    {
        public ObjectResult<GenericPagedList<Sectors>> GetAllSectorsPaged(int pageNumber, int pageSize)
        {
            SectorsBLO biz = new SectorsBLO();
            ObjectResult<GenericPagedList<Sectors>> output = new ObjectResult<GenericPagedList<Sectors>>();

            try
            {
                output.Result = biz.GetAllSectorsPaged(pageNumber, pageSize);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                output.Result = null;
                output.Success = false;
                output.Message = "Failed to Get All Sectors Paged";
            }
            return output;
        }

        public ObjectResult<Sectors> GetBySectorId(int sectorId)
        {
            SectorsBLO biz = new SectorsBLO();
            ObjectResult<Sectors> output = new ObjectResult<Sectors>();

            try
            {
                if (!biz.SectorExist(sectorId))
                {
                    output.Message = string.Format("Sector Id {0} Not Found", sectorId);
                    return output;
                }
                output.Result = biz.GetBySectorId(sectorId);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                output.Result = null;
                output.Success = false;
                output.Message = "Failed to Get Sector by Id " + sectorId;
            }
            return output;
        }

        public ObjectResult<List<Sectors>> GetAllSectors()
        {
            SectorsBLO biz = new SectorsBLO();            
            ObjectResult<List<Sectors>> output = new ObjectResult<List<Sectors>>();

            try
            {                
                output.Result = biz.GetAllSectors();
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                output.Result = null;
                output.Success = false;
                output.Message = "Failed to Get all Sectors";
            }
            return output;
        }

        public ObjectResult<List<Sectors>> GetSectorsByVehicleType(int vehicleTypeId)
        {
            SectorsBLO biz = new SectorsBLO();
            VehicleTypesBLO vehicleTypeBiz = new VehicleTypesBLO();
            ObjectResult<List<Sectors>> output = new ObjectResult<List<Sectors>>();

            try
            {
                if (!vehicleTypeBiz.VehicleTypeExist(vehicleTypeId))
                {
                    output.Message = string.Format("Vehicle Type Id {0} Not Found", vehicleTypeId);
                    return output;
                }
                output.Result = biz.GetSectorsByVehicleType(vehicleTypeId);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                output.Result = null;
                output.Success = false;
                output.Message = "Failed to Get Sectors By Vehicle Type";
            }
            return output;
        }

        public ObjectResult<List<Sectors>> SectorFilter(string search)
        {
            SectorsBLO biz = new SectorsBLO();
            ObjectResult<List<Sectors>> output = new ObjectResult<List<Sectors>>();

            try
            {
                output.Result = biz.SectorFilter(search);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                output.Result = null;
                output.Success = false;
                output.Message = "Failed to Get Sector by Search Filter " + search;
            }
            return output;
        }

        public ObjectResult<Sectors> CreateSector(SectorsCustom sector)
        {
            SectorsBLO biz = new SectorsBLO();
            ObjectResult<Sectors> output = new ObjectResult<Sectors>();

            try
            {
                if (biz.SectorNameEnExist(sector.SectorNameEn))
                {
                    output.Message = string.Format("English Sector Name: '{0}' Already Exists", sector.SectorNameEn);
                    return output;
                }

                if (biz.SectorNameArExist(sector.SectorNameAr))
                {
                    output.Message = string.Format("Arabic Sector Name: '{0}' Already Exists", sector.SectorNameAr);
                    return output;
                }
                biz.CreateSector(InkriptMapper.Mapper.Map<Sectors>(sector));
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                output.Result = null;
                output.Success = false;
                output.Message = "Failed to Create Sector";
            }
            return output;
        }

        public ObjectResult<Sectors> UpdateSector(int sectorId, SectorsCustom sector)
        {
            SectorsBLO biz = new SectorsBLO();
            ObjectResult<Sectors> output = new ObjectResult<Sectors>();

            try
            {
                if (!biz.SectorExist(sectorId))
                {
                    output.Message = string.Format("Sector Id {0} Not Found", sectorId);
                    return output;
                }

                if (!biz.ValidateSectorNameEn(sectorId, sector.SectorNameEn))
                {
                    if (biz.SectorNameEnExist(sector.SectorNameEn))
                    {
                        output.Message = string.Format("English Sector Name: '{0}' Already Exists", sector.SectorNameEn);
                        return output;
                    }
                }

                if (!biz.ValidateSectorNameAr(sectorId, sector.SectorNameAr))
                {
                    if (biz.SectorNameArExist(sector.SectorNameAr))
                    {
                        output.Message = string.Format("Arabic Sector Name: '{0}' Already Exists", sector.SectorNameAr);
                        return output;
                    }
                }

                Sectors entity = InkriptMapper.Mapper.Map<Sectors>(sector);
                entity.SectorId = sectorId;
                biz.UpdateSector(entity);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                output.Result = null;
                output.Success = false;
                output.Message = "Failed to Update Sector Id " + sectorId;
            }
            return output;
        }

        public ObjectResult<bool> DeleteSector(int sectorId)
        {
            SectorsBLO biz = new SectorsBLO();
            ObjectResult<bool> output = new ObjectResult<bool>();

            try
            {
                if (!biz.SectorExist(sectorId))
                {
                    output.Message = string.Format("Sector Id {0} Not Found", sectorId);
                    return output;
                }
                output.Result = biz.DeleteSector(sectorId);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                output.Result = false;
                output.Success = false;
                output.Message = "Failed to Delete Sector Id " + sectorId;
            }
            return output;
        }

        public ObjectResult<List<SectorsLimit>> GetSectorsAtRisk(int sectorId, int? vehicleTypeId, int? plateCodeId, int? branchId)
        {
            SectorsBLO biz = new SectorsBLO();
            VehicleTypesBLO vechicleTypesBiz = new VehicleTypesBLO();
            PlateCodesBLO plateCodesBiz = new PlateCodesBLO();
            BranchesBLO branchesBiz = new BranchesBLO();
            ObjectResult<List<SectorsLimit>> output = new ObjectResult<List<SectorsLimit>>();

            try
            {
                if (!biz.SectorExist(sectorId))
                {
                    output.Message = string.Format("Sector Id {0} Not Found", sectorId);
                    return output;
                }

                if (vehicleTypeId.HasValue && !vechicleTypesBiz.VehicleTypeExist(vehicleTypeId.Value))
                {
                    output.Message = string.Format("Vehicle Type Id {0} Not Found", vehicleTypeId);
                    return output;
                }

                if (plateCodeId.HasValue && !plateCodesBiz.PlateCodeExist(plateCodeId.Value))
                {
                    output.Message = string.Format("Plate Code Id {0} Not Found", plateCodeId);
                    return output;
                }

                if (branchId.HasValue && !branchesBiz.BranchExist(branchId.Value))
                {
                    output.Message = string.Format("Branch Id {0} Not Found", branchId);
                    return output;
                }

                output.Result = biz.GetSectorsAtRisk(sectorId, vehicleTypeId, plateCodeId, branchId);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                output.Result = null;
                output.Success = false;
                output.Message = "Failed to Get Sector At Risk by Sector Id " + sectorId;
            }
            return output;
        }
    }
}