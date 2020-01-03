using Inkript.Logging;
using Inkript.VR.API.Models;
using Inkript.VR.Business.BusinessLayer;
using Inkript.VR.Models;
using System;
using System.Collections.Generic;

namespace Inkript.VR.API
{
    public class ImportCustomsApiBLO
    {
        public ObjectResult<GenericPagedList<ImportCustoms>> GetAllImportCustomsPaged(int pageNumber, int pageSize)
        {
            ImportCustomsBLO biz = new ImportCustomsBLO();
            ObjectResult<GenericPagedList<ImportCustoms>> output = new ObjectResult<GenericPagedList<ImportCustoms>>();

            try
            {
                output.Result = biz.GetAllImportCustomsPaged(pageNumber, pageSize);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                output.Result = null;
                output.Success = false;
                output.Message = "Failed to Get All Import Customs Paged";
            }
            return output;
        }

        public ObjectResult<ImportCustoms> GetByImportCustomsId(int importCustomsId)
        {
            ImportCustomsBLO biz = new ImportCustomsBLO();
            ObjectResult<ImportCustoms> output = new ObjectResult<ImportCustoms>();

            try
            {
                if (!biz.ImportCustomsExist(importCustomsId))
                {
                    output.Message = string.Format("Import Customs Id {0} Not Found", importCustomsId);
                    return output;
                }
                output.Result = biz.GetByImportCustomsId(importCustomsId);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                output.Result = null;
                output.Success = false;
                output.Message = "Failed to Get Import Custom Id " + importCustomsId ;
            }
            return output;
        }

        public ObjectResult<List<ImportCustoms>> GetByCertificationId(string certificationId)
        {
            ImportCustomsBLO biz = new ImportCustomsBLO();
            ObjectResult<List<ImportCustoms>> output = new ObjectResult<List<ImportCustoms>>();

            try
            {
                if (!biz.CertificationExist(certificationId))
                {
                    output.Message = string.Format("Certification Id {0} Not Found", certificationId);
                    return output;
                }
                output.Result = biz.GetByCertificationId(certificationId);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                output.Result = null;
                output.Success = false;
                output.Message = "Failed to Get Import Custom by Certification Id" + certificationId;
            }
            return output;
        }

        public ObjectResult<List<ImportCustoms>> GetByFileInfoId(int fileInfoId)
        {
            FileInfoCustomsBLO fileInfoBiz = new FileInfoCustomsBLO();
            ImportCustomsBLO importCustomsBiz = new ImportCustomsBLO();
            ObjectResult<List<ImportCustoms>> output = new ObjectResult<List<ImportCustoms>>();

            try
            {
                if (!fileInfoBiz.FileInfoCustomsExist(fileInfoId))
                {
                    output.Message = string.Format("File Info Id {0} Not Found", fileInfoId);
                    return output;
                }
                output.Result = importCustomsBiz.GetByFileInfoId(fileInfoId);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                output.Result = null;
                output.Success = false;
                output.Message = "Failed to Get Import Custom by File Info Id" + fileInfoId;
            }
            return output;
        }

        public ObjectResult<List<ImportCustoms>> ImportCustomsFilter(ImportCustomFilter filter)
        {
            ImportCustomsBLO biz = new ImportCustomsBLO();
            ObjectResult<List<ImportCustoms>> output = new ObjectResult<List<ImportCustoms>>();

            try
            {
                output.Result = biz.ImportCustomsFilter(filter.YearFrom, filter.YearTo, InkriptMapper.Mapper.Map<ImportCustoms>(filter));
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                output.Result = null;
                output.Success = false;
                output.Message = "Failed to Get Import Customs by search";
            }
            return output;
        }

        public ObjectResult<ImportCustoms> CreateImportCustom(int fileInfoId, ImportCustomsCustom importCustom)
        {
            FileInfoCustomsBLO fileInfoBiz = new FileInfoCustomsBLO();
            ImportCustomsBLO importCustomsBiz = new ImportCustomsBLO();
            ObjectResult<ImportCustoms> output = new ObjectResult<ImportCustoms>();

            try
            {
                if (!fileInfoBiz.FileInfoCustomsExist(fileInfoId))
                {
                    output.Message = string.Format("File Info Id {0} Not Found", fileInfoId);
                    return output;
                }
                importCustomsBiz.CreateImportCustom(fileInfoId, InkriptMapper.Mapper.Map<ImportCustoms>(importCustom));
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                output.Result = null;
                output.Success = false;
                output.Message = "Failed to Add Import Custom";
            }
            return output;
        }

        public ObjectResult<ImportCustoms> UpdateImportCustom(int importCustomsId, ImportCustomsCustom importCustom)
        {
            ImportCustomsBLO biz = new ImportCustomsBLO();
            ObjectResult<ImportCustoms> output = new ObjectResult<ImportCustoms>();

            try
            {
                if (!biz.ImportCustomsExist(importCustomsId))
                {
                    output.Message = string.Format("Import Customs Id {0} Not Found", importCustomsId);
                    return output;
                }
                biz.UpdateImportCustom(importCustomsId, InkriptMapper.Mapper.Map<ImportCustoms>(importCustom));
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                output.Result = null;
                output.Success = false;
                output.Message = "Failed to Update Import Custom Id: " + importCustomsId;
            }
            return output;
        }

        public ObjectResult<bool> DeleteImportCustom(int importCustomsId)
        {
            ImportCustomsBLO biz = new ImportCustomsBLO();
            ObjectResult<bool> output = new ObjectResult<bool>();

            try
            {
                if (!biz.ImportCustomsExist(importCustomsId))
                {
                    output.Message = string.Format("Import Customs Id {0} Not Found", importCustomsId);
                    return output;
                }
                output.Result = biz.DeleteImportCustom(importCustomsId);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                output.Result = false;
                output.Success = false;
                output.Message = "Failed to Delete Import Custom Id: " + importCustomsId;
            }
            return output;
        }

        public ObjectResult<string> GetCarValueByCustomsCertificate(string certificationId)
        {
            ImportCustomsBLO biz = new ImportCustomsBLO();
            ObjectResult<string> output = new ObjectResult<string>();

            try
            {
                if (!biz.CertificationExist(certificationId))
                {
                    output.Message = string.Format("Certification Id {0} Not Found", certificationId);
                    return output;
                }
                output.Result = biz.GetCarValueByCustomsCertificate(certificationId);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                output.Result = null;
                output.Success = false;
                output.Message = "Failed to Get Car Value by Certificate id: " + certificationId;
            }
            return output;
        }

        public ObjectResult<string> GetCarValueEstimationByCarSpecs
            (string brandId, int modelId, string trim, double cc, double numberHorses, string chassisNumber)
        {
            ImportCustomsBLO biz = new ImportCustomsBLO();
            ObjectResult<string> output = new ObjectResult<string>();

            try
            {
                output.Result = biz.GetCarValueEstimationByCarSpecs
                    (brandId, modelId, trim, cc, numberHorses, chassisNumber);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                output.Result = null;
                output.Success = false;
                output.Message = 
                    "Failed to Get Car Value by Brand: "+brandId
                    +", Model: "+modelId+", Trim: "+trim+", CC: "+cc+", NumberHorses: "+numberHorses
                    +", Chassis: "+chassisNumber;
            }
            return output;
        }

        public ObjectResult<CustomsInfo> GetCustomsInfo(string chassis)
        {
            ImportCustomsBLO biz = new ImportCustomsBLO();
            ObjectResult<CustomsInfo> output = new ObjectResult<CustomsInfo>();

            try
            {
                if (!biz.ChassisExist(chassis))
                {
                    output.Message = string.Format("Chassis {0} Not Found", chassis);
                    return output;
                }
                output.Result = biz.GetCustomsInfo(chassis);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                output.Result = null;
                output.Success = false;
                output.Message = "Failed to Get Customs Info by Chassis" + chassis;
            }
            return output;
        }
    }
}