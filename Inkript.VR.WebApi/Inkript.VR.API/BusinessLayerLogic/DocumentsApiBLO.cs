using Inkript.Logging;
using Inkript.VR.API.Models;
using Inkript.VR.Business.BusinessLayer;
using Inkript.VR.Models;
using System;
using System.Collections.Generic;

namespace Inkript.VR.API
{
    public class DocumentsApiBLO
    {
        public ObjectResult<List<Documents>> GetDocuments(int BPId, int SectorId, int VehicleTypeId)
        {
            DocumentsBLO biz = new DocumentsBLO();
            BusinessProcessesBLO businsessProcessesBiz = new BusinessProcessesBLO();
            SectorsBLO sectorsBiz = new SectorsBLO();
            VehicleTypesBLO vehicleTypesBiz = new VehicleTypesBLO();
            ObjectResult<List<Documents>> output = new ObjectResult<List<Documents>>();

            try
            {
                if (!businsessProcessesBiz.BusinessProcessExist(BPId))
                {
                    output.Message = string.Format("BP Id {0} Not Found", BPId);
                    return output;
                }

                if (!sectorsBiz.SectorExist(SectorId))
                {
                    output.Message = string.Format("Sector Id {0} Not Found", SectorId);
                    return output;
                }

                if (!vehicleTypesBiz.VehicleTypeExist(VehicleTypeId))
                {
                    output.Message = string.Format("VehicleType Id {0} Not Found", VehicleTypeId);
                    return output;
                }

                output.Result = biz.GetDocuments(BPId, SectorId, VehicleTypeId);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                output.Result = null;
                output.Success = false;
                output.Message = "Failed to Get Documents";
            }
            return output;
        }

        public ObjectResult<List<Documents>> GetDocuments(List<DocumentCustom> documents)
        {
            DocumentsBLO biz = new DocumentsBLO();
            BusinessProcessesBLO businsessProcessesBiz = new BusinessProcessesBLO();
            SectorsBLO sectorsBiz = new SectorsBLO();
            VehicleTypesBLO vehicleTypesBiz = new VehicleTypesBLO();
            ObjectResult<List<Documents>> output = new ObjectResult<List<Documents>>();

            try
            {
                foreach (var item in documents)
                {
                    if (!businsessProcessesBiz.BusinessProcessExist(item.BusinessProccessId))
                    {
                        output.Message = string.Format("Business Process Id {0} Not Found", item.BusinessProccessId);
                        return output;
                    }

                    if (!sectorsBiz.SectorExist(item.SectorId))
                    {
                        output.Message = string.Format("Sector Id {0} Not Found", item.SectorId);
                        return output;
                    }

                    if (!vehicleTypesBiz.VehicleTypeExist(item.VehicleTypeId))
                    {
                        output.Message = string.Format("VehicleType Id {0} Not Found", item.VehicleTypeId);
                        return output;
                    } 
                }

                output.Result = biz.GetDocuments(documents);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                output.Result = null;
                output.Success = false;
                output.Message = "Failed to Get Documents";
            }
            return output;
        }


        public ObjectResult<List<Documents>> GetAllDocuments()
        {
            DocumentsBLO biz = new DocumentsBLO();
            ObjectResult<List<Documents>> output = new ObjectResult<List<Documents>>();

            try
            {
                output.Result = biz.GetAllDocuments();
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                output.Result = null;
                output.Success = false;
                output.Message = "Failed to Get Documents";
            }
            return output;
        }

        public ObjectResult<List<Documents>> GetBusinessProcessDocuments(int businessProcessId)
        {
            DocumentsBLO biz = new DocumentsBLO();
            ObjectResult<List<Documents>> output = new ObjectResult<List<Documents>>();

            try
            {
                output.Result = biz.GetBusinessProcessDocuments(businessProcessId);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                output.Result = null;
                output.Success = false;
                output.Message = "Failed to Get Business Process Documents";
            }
            return output;
        }
    }
}