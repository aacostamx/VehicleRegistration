using Inkript.Logging;
using Inkript.VR.API.Models;
using Inkript.VR.Business.BusinessLayer;
using Inkript.VR.Models;
using System;
using System.Collections.Generic;
using System.Net;

namespace Inkript.VR.API
{
    public class ImportInspectionsApiBLO
    {
        public ObjectResult<GenericPagedList<ImportInspections>> GetAllImportInspectionsPaged(int pageNumber, int pageSize)
        {
            ImportInspectionsBLO biz = new ImportInspectionsBLO();
            ObjectResult<GenericPagedList<ImportInspections>> output = new ObjectResult<GenericPagedList<ImportInspections>>();

            try
            {
                output.Result = biz.GetAllImportInspectionsPaged(pageNumber, pageSize);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                output.Result = null;
                output.Success = false;
                output.Message = "Failed to Get All Import Inspections Paged";
            }
            return output;
        }

        public ObjectResult<ImportInspections> GetByImportInspectionsId(int importInspectsId)
        {
            ImportInspectionsBLO biz = new ImportInspectionsBLO();
            ObjectResult<ImportInspections> output = new ObjectResult<ImportInspections>();

            try
            {
                if (!biz.ImportInspectionsExist(importInspectsId))
                {
                    output.Message = string.Format("Import Inspections Id {0} Not Found", importInspectsId);
                    return output;
                }
                output.Result = biz.GetByImportInspectionsId(importInspectsId);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                output.Result = null;
                output.Success = false;
                output.Message = "Failed to Get Import Inspection by Id: " + importInspectsId;
            }
            return output;
        }

        public ObjectResult<List<ImportInspections>> ImportInspectionsFilter(ImportInspectionsFilter filter)
        {
            ImportInspectionsBLO biz = new ImportInspectionsBLO();
            ObjectResult<List<ImportInspections>> output = new ObjectResult<List<ImportInspections>>();

            try
            {
                output.Result = biz.ImportInspectionsFilter(filter.YearFrom, filter.YearTo, filter.PlateNumber, filter.PlateCodeId);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                output.Result = null;
                output.Success = false;
                output.Message = "Failed to Get Import Inspections by search filter";
            }
            return output;
        }

        public ObjectResult<bool> DeleteImportInspections(int importInspectsId)
        {
            ImportInspectionsBLO biz = new ImportInspectionsBLO();
            ObjectResult<bool> output = new ObjectResult<bool>();

            try
            {
                output.Result = biz.DeleteImportInspections(importInspectsId);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                output.Result = false;
                output.Success = false;
                output.Message = "Failed to Delete Import Inspection Id " + importInspectsId;
            }
            return output;
        }

        public ObjectResult<ImportInspections> CreateImportInspections(ImportInspectionsCustom importInspections)
        {
            ImportInspectionsBLO importInspectionsBiz = new ImportInspectionsBLO();
            FileInfoInspectionsBLO fileInfoInspectionsBiz = new FileInfoInspectionsBLO();
            ObjectResult<ImportInspections> output = new ObjectResult<ImportInspections>();

            try
            {
                if (!fileInfoInspectionsBiz.FileInspectionsExist(importInspections.FileInfoInspectionId))
                {
                    output.Message = string.Format("File Info Inspections Id {0} Not Found", importInspections.FileInfoInspectionId);
                    return output;
                }
                importInspectionsBiz.CreateImportInspections(InkriptMapper.Mapper.Map<ImportInspections>(importInspections));
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                output.Result = null;
                output.Success = false;
                output.Message = "Failed to Create Import Inspection";
            }
            return output;
        }

        public ObjectResult<int> CheckInspection(int carUniqueNumber)
        {
            ObjectResult<int> output = new ObjectResult<int>();
            ImportInspectionsBLO biz = new ImportInspectionsBLO();

            try
            {
                if (!biz.CarUniqueNumberExist(carUniqueNumber))
                {
                    output.Message = string.Format("Car Unique Number {0} Not Found", carUniqueNumber);
                    return output;
                }

                output.Result = biz.CheckInspection(carUniqueNumber);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                output.Result = 0;
                output.Success = false;
                output.Message = "Failed to Check Inspection by Car Unique Number: " + carUniqueNumber;
            }
            return output;
        }
    }
}