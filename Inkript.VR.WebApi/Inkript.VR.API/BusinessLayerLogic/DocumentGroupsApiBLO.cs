using Inkript.Logging;
using Inkript.VR.API.Models;
using Inkript.VR.Business.BusinessLayer;
using Inkript.VR.Models;
using System;
using System.Collections.Generic;

namespace Inkript.VR.API
{
    public class DocumentGroupsApiBLO
    {
        public ObjectResult<List<DocumentGroups>> GetDocumentGroups(List<DocumentCustom> documents)
        {
            SectorsBLO sectorsBiz = new SectorsBLO();
            DocumentGroupsBLO biz = new DocumentGroupsBLO();
            VehicleTypesBLO vehicleTypesBiz = new VehicleTypesBLO();
            BusinessProcessesBLO businsessProcessesBiz = new BusinessProcessesBLO();
            ObjectResult<List<DocumentGroups>> output = new ObjectResult<List<DocumentGroups>>();

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

                output.Result = biz.GetDocumentGroups(documents);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                output.Result = null;
                output.Success = false;
                output.Message = "Failed to Get Document Groups";
            }
            return output;
        }
    }
}