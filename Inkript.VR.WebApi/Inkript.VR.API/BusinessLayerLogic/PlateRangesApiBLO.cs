using Inkript.Logging;
using Inkript.VR.API.Models;
using Inkript.VR.Business;
using Inkript.VR.Business.BusinessLayer;
using Inkript.VR.Models;
using System;
using System.Collections.Generic;

namespace Inkript.VR.API
{
    public class PlateRangesApiBLO
    {
        public ObjectResult<GenericPagedList<PlateRanges>> GetAllPlateRangesPaged(int pageNumber, int pageSize)
        {
            PlateRangesBLO biz = new PlateRangesBLO();
            ObjectResult<GenericPagedList<PlateRanges>> output = new ObjectResult<GenericPagedList<PlateRanges>>();

            try
            {
                output.Result = biz.GetAllPlateRangesPaged(pageNumber, pageSize);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                output.Result = null;
                output.Success = false;
                output.Message = "Failed to Get All Plate Ranges Paged";
            }
            return output;
        }

        public ObjectResult<int> CreatePlateRange(PlateRangesCustom plateRange)
        {
            StatusBLO statusBiz = new StatusBLO();
            SectorsBLO sectorBiz = new SectorsBLO();
            PlateRangesBLO biz = new PlateRangesBLO();
            PlateCodesBLO plateCodesBiz = new PlateCodesBLO();
            VehicleTypesBLO vehicleTypesBiz = new VehicleTypesBLO();
            ObjectResult<int> output = new ObjectResult<int>();

            try
            {
                if (biz.PlateRangeExist(plateRange.RangeName))
                {
                    output.Message = string.Format("Plate Range Name: '{0}' Already Exists", plateRange.RangeName);
                    return output;
                }

                if (plateRange.StartNumber > plateRange.EndNumber)
                {
                    output.Message = string.Format("End Number {0} must be greater than Start Number {1}",
                        plateRange.EndNumber, plateRange.StartNumber);
                    return output;
                }

                if (biz.CheckPlateNumberPool(plateRange.StartNumber, plateRange.EndNumber) > 0)
                {
                    output.Message = string.Format("Plate Number Pool Range from '{0}' to '{1}' Already Exists",
                        plateRange.StartNumber, plateRange.EndNumber);
                    return output;
                }

                if (!statusBiz.StatusExist(plateRange.StatusId))
                {
                    output.Message = string.Format("Status Id: '{0}' Not Exists", plateRange.StatusId);
                    return output;
                }

                if (!sectorBiz.SectorExist(plateRange.SectorId))
                {
                    output.Message = string.Format("Sector Id: '{0}' Not Exists", plateRange.SectorId);
                    return output;
                }

                if (!vehicleTypesBiz.VehicleTypeExist(plateRange.VehicleTypeId))
                {
                    output.Message = string.Format("Vehicle Type Id: '{0}' Not Exists", plateRange.VehicleTypeId);
                    return output;
                }

                if (!plateCodesBiz.PlateCodeExist(plateRange.PlateCodeId))
                {
                    output.Message = string.Format("Plate Code Id: '{0}' Not Exists", plateRange.PlateCodeId);
                    return output;
                }

                output.Result = biz.CreatePlateRanges(InkriptMapper.Mapper.Map<PlateRanges>(plateRange));
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                output.Result = 0;
                output.Success = false;
                output.Message = "Failed to Create Plate Range";
            }
            return output;
        }

        public ObjectResult<List<PlateRanges>> PlateRangesFilter(int? sectorId, int? branchId, int? vehicleTypeId, int? plateCodeId)
        {
            SectorsBLO sectorsBiz = new SectorsBLO();
            BranchesBLO branchesBiz = new BranchesBLO();
            PlateCodesBLO plateCodesBiz = new PlateCodesBLO();
            PlateRangesBLO plateRangesBiz = new PlateRangesBLO();
            VehicleTypesBLO vehicleTypesBiz = new VehicleTypesBLO();
            ObjectResult<List<PlateRanges>> output = new ObjectResult<List<PlateRanges>>();

            try
            {
                if (sectorId.HasValue && !sectorsBiz.SectorExist(sectorId.Value))
                {
                    output.Message = string.Format("Sector Id {0} Not Found", sectorId);
                    return output;
                }

                if (vehicleTypeId.HasValue && !vehicleTypesBiz.VehicleTypeExist(vehicleTypeId.Value))
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

                output.Result = plateRangesBiz.PlateRangesFilter(sectorId, branchId, vehicleTypeId, plateCodeId);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                output.Result = null;
                output.Success = false;
                output.Message = "Failed to Get Plate Ranges by Filter";
            }
            return output;
        }        

        public ObjectResult<PlateRanges> UpdatePlateRangeStatus(int plateRangeId, int statusId)
        {
            StatusBLO statusBiz = new StatusBLO();
            PlateRangesBLO biz = new PlateRangesBLO();
            ObjectResult<PlateRanges> output = new ObjectResult<PlateRanges>();

            try
            {
                if (!biz.PlateRangeIdExist(plateRangeId))
                {
                    output.Message = string.Format("Plate Range Id: '{0}' Not Exists", plateRangeId);
                    return output;
                }

                if (!statusBiz.StatusExist(statusId))
                {
                    output.Message = string.Format("Status Id: '{0}' Not Exists", statusId);
                    return output;
                }

                PlateRanges plateRange = biz.GetByPlateRangesId(plateRangeId);
                plateRange.StatusId = statusId;

                biz.UpdatePlateRange(plateRange);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                output.Result = null;
                output.Success = false;
                output.Message = "Failed to Update Plate Range Id " + plateRangeId;
            }
            return output;
        }

        public ObjectResult<List<PlateRanges>> GetRangesByStatus(int statusId)
        {
            PlateRangesBLO biz = new PlateRangesBLO();
            ObjectResult<List<PlateRanges>> output = new ObjectResult<List<PlateRanges>>();

            try
            {
                if (!biz.ValidStatus(statusId))
                {
                    output.Message = string.Format("Invalid status: '{0}'", statusId);
                    return output;
                }

                output.Result = biz.GetRangesByStatus(statusId);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                output.Result = null;
                output.Success = false;
                output.Message = "Failed to Get Plate Ranges by Status " + statusId;
            }
            return output;
        }
    }
}