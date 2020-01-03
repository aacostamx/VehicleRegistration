using Inkript.Logging;
using Inkript.VR.API.Models;
using Inkript.VR.Business.BusinessLayer;
using Inkript.VR.Models;
using System;
using System.Collections.Generic;

namespace Inkript.VR.API
{
    public class BusinessProcessesApiBLO
    {
        public ObjectResult<GenericPagedList<BusinessProcesses>> GetAllBusinessProcessesPaged(int pageNumber, int pageSize)
        {
            BusinessProcessesBLO biz = new BusinessProcessesBLO();
            ObjectResult<GenericPagedList<BusinessProcesses>> output = new ObjectResult<GenericPagedList<BusinessProcesses>>();

            try
            {
                output.Result = biz.GetAllBusinessProcessesPaged(pageNumber, pageSize);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                output.Result = null;
                output.Success = false;
                output.Message = "Failed to Get All Business Processes Paged";
            }
            return output;
        }

        public ObjectResult<BusinessProcesses> GetByBusinessProcessId(int businessProcessId)
        {
            BusinessProcessesBLO biz = new BusinessProcessesBLO();
            ObjectResult<BusinessProcesses> output = new ObjectResult<BusinessProcesses>();

            try
            {
                if (!biz.BusinessProcessExist(businessProcessId))
                {
                    output.Message = string.Format("Business Process Id {0} Not Found", businessProcessId);
                    return output;
                }
                output.Result = biz.GetByBusinessProcessAndSecondaries(businessProcessId);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                output.Result = null;
                output.Success = false;
                output.Message = "Failed to Get Business Process by Id";
            }
            return output;
        }

        public ObjectResult<List<BusinessProcesses>> GetBusinessProcessDeliverables(int businessProcessId)
        {
            BusinessProcessesBLO biz = new BusinessProcessesBLO();
            ObjectResult<List<BusinessProcesses>> output = new ObjectResult<List<BusinessProcesses>>();

            try
            {
                if (!biz.BusinessProcessExist(businessProcessId))
                {
                    output.Message = string.Format("Business Process Id {0} Not Found", businessProcessId);
                    return output;
                }
                output.Result = biz.GetAllBusinessProcessDeliverables(businessProcessId);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                output.Result = null;
                output.Success = false;
                output.Message = "Failed to Get Business Process Deliverables";
            }
            return output;
        }

        public ObjectResult<List<SecondaryBusinessProcesses>> GetSecondaryBusinessProcessesBy
            (int primaryBPId, int? sectorId, int? vehicleTypeId, int? carUniqueNumber)
        {
            SectorsBLO sectorsBiz = new SectorsBLO();
            BusinessProcessesBLO biz = new BusinessProcessesBLO();
            VehicleTypesBLO vehicleTypesBiz = new VehicleTypesBLO();
            RegisteredVehiclesBLO registeredCarsBiz = new RegisteredVehiclesBLO();
            CarUniqueNumberBLO carUniqueNumberBiz = new CarUniqueNumberBLO();
            ObjectResult<List<SecondaryBusinessProcesses>> output = new ObjectResult<List<SecondaryBusinessProcesses>>();

            try
            {
                if (!biz.BusinessProcessExist(primaryBPId))
                {
                    output.Message = string.Format("Business Process Id {0} Not Found", primaryBPId);
                    return output;
                }
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

                BusinessProcesses businessProcess = biz.GetByBusinessProcessId(primaryBPId);
                if (businessProcess.BPType.ToLower() != "primary")
                {
                    output.Message = string.Format("The Business Process Type must be Primary");
                    return output;
                }

                output.Result = biz.GetSecondaryBusinessProcessesBy(primaryBPId, sectorId, vehicleTypeId, carUniqueNumber);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                output.Result = null;
                output.Success = false;
                output.Message = "Failed to Get Business Processes by params";
            }
            return output;
        }

        public ObjectResult<List<BusinessProcesses>> GetAllBusinessProcesses()
        {
            BusinessProcessesBLO biz = new BusinessProcessesBLO();
            ObjectResult<List<BusinessProcesses>> output = new ObjectResult<List<BusinessProcesses>>();

            try
            {
                output.Result = biz.GetAllBusinessProcesses();
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                output.Result = null;
                output.Success = false;
                output.Message = "Failed to Get All Business Processes";
            }
            return output;
        }

        public ObjectResult<List<BusinessProcesses>> BusinessProcessesFilter(string search)
        {
            BusinessProcessesBLO biz = new BusinessProcessesBLO();
            ObjectResult<List<BusinessProcesses>> output = new ObjectResult<List<BusinessProcesses>>();

            try
            {
                output.Result = biz.BusinessProcessesFilter(search);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                output.Result = null;
                output.Success = false;
                output.Message = "Cannot get business processes by search:" + search;
            }
            return output;
        }

        public ObjectResult<List<BusinessProcesses>> GetPrimaryBusinessProcesses()
        {
            BusinessProcessesBLO biz = new BusinessProcessesBLO();
            ObjectResult<List<BusinessProcesses>> output = new ObjectResult<List<BusinessProcesses>>();

            try
            {
                output.Result = biz.GetPrimaryBusinessProcesses();
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                output.Result = null;
                output.Success = false;
                output.Message = "Cannot get primary business processes available.";
            }
            return output;
        }

        public ObjectResult<BusinessProcesses> CreateBusinessProcess(BusinessProcessesCustom businessProcess)
        {
            SectorsBLO sectorBiz = new SectorsBLO();
            BusinessProcessesBLO biz = new BusinessProcessesBLO();
            VehicleTypesBLO vehicleTypeBiz = new VehicleTypesBLO();
            ObjectResult<BusinessProcesses> output = new ObjectResult<BusinessProcesses>();

            try
            {
                if (biz.BPNameEnExist(businessProcess.BPNameEn))
                {
                    output.Message = string.Format("English Business Process Name: '{0}' Already Exists",
                        businessProcess.BPNameEn);
                    return output;
                }

                if (biz.BPNameArExist(businessProcess.BPNameAr))
                {
                    output.Message = string.Format("Arabic Business Process Name: '{0}' Already Exists",
                        businessProcess.BPNameAr);
                    return output;
                }

                if (!string.IsNullOrEmpty(businessProcess.HotKey)
                    && biz.HotKeyExist(businessProcess.HotKey))
                {
                    output.Message = string.Format("HotKey: '{0}' Already Assigned", businessProcess.HotKey);
                    return output;
                }

                if (businessProcess.BPRelationships != null
                    && businessProcess.BPRelationships.Count > 0)
                {
                    foreach (var item in businessProcess.BPRelationships)
                    {
                        if (!biz.BusinessProcessExist(item.BPId))
                        {
                            output.Message = string.Format("Relationship Business Process Id: '{0}' Not Found", item.BPId);
                            return output;
                        }
                    }
                }

                if (businessProcess.BPSectorVehicle != null 
                    && businessProcess.BPSectorVehicle.Count > 0)
                {
                    foreach (var item in businessProcess.BPSectorVehicle)
                    {
                        if (!vehicleTypeBiz.VehicleTypeExist(item.VehicleTypeId))
                        {
                            output.Message = string.Format("Vehicle Type Id: '{0}' Not Found", item.VehicleTypeId);
                            return output;
                        }
                        if (!sectorBiz.SectorExist(item.SectorId))
                        {
                            output.Message = string.Format("Sector Id: '{0}' Not Found", item.SectorId);
                            return output;
                        }
                    }
                }

                biz.CreateBusinessProcess(InkriptMapper.Mapper.Map<BusinessProcesses>(businessProcess));
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                output.Result = null;
                output.Success = false;
                output.Message = "Unable to create Business Process object";
            }
            return output;
        }

        public ObjectResult<BusinessProcesses> UpdateBusinessProcess(int businessProcessesId, BusinessProcessesCustom businessProcess)
        {
            SectorsBLO sectorBiz = new SectorsBLO();
            BusinessProcessesBLO biz = new BusinessProcessesBLO();
            VehicleTypesBLO vehicleTypeBiz = new VehicleTypesBLO();
            ObjectResult<BusinessProcesses> output = new ObjectResult<BusinessProcesses>();

            try
            {
                if (!biz.BusinessProcessExist(businessProcessesId))
                {
                    output.Message = string.Format("Business Process Id {0} Not Found", businessProcessesId);
                    return output;
                }

                BusinessProcesses dbBusinessProcess = biz.GetByBusinessProcessId(businessProcessesId);

                if (dbBusinessProcess.BPNameEn != businessProcess.BPNameEn)
                {
                    if (biz.BPNameEnExist(businessProcess.BPNameEn))
                    {
                        output.Message = string.Format("English Business Process Name: '{0}' Already Exists", businessProcess.BPNameEn);
                        return output;
                    }
                }

                if (dbBusinessProcess.BPNameAr != businessProcess.BPNameAr)
                {
                    if (biz.BPNameArExist(businessProcess.BPNameAr))
                    {
                        output.Message = string.Format("Arabic Business Process Name: '{0}' Already Exists", businessProcess.BPNameAr);
                        return output;
                    }
                }

                if (dbBusinessProcess.HotKey != businessProcess.HotKey)
                {
                    if (biz.HotKeyExist(businessProcess.HotKey))
                    {
                        output.Message = string.Format("HotKey: '{0}' Already Assigned", businessProcess.HotKey);
                        return output;
                    }
                }

                if (businessProcess.BPRelationships != null
                    && businessProcess.BPRelationships.Count > 0)
                {
                    foreach (var item in businessProcess.BPRelationships)
                    {
                        if (!biz.BusinessProcessExist(item.BPId))
                        {
                            output.Message = string.Format("Relationship Business Process Id: '{0}' Not Found", item.BPId);
                            return output;
                        }
                    }
                }

                if (businessProcess.BPSectorVehicle != null
                    && businessProcess.BPSectorVehicle.Count > 0)
                {
                    foreach (var item in businessProcess.BPSectorVehicle)
                    {
                        if (!vehicleTypeBiz.VehicleTypeExist(item.VehicleTypeId))
                        {
                            output.Message = string.Format("Vehicle Type Id: '{0}' Not Found", item.VehicleTypeId);
                            return output;
                        }
                        if (!sectorBiz.SectorExist(item.SectorId))
                        {
                            output.Message = string.Format("Sector Id: '{0}' Not Found", item.SectorId);
                            return output;
                        }
                    }
                }

                BusinessProcesses entity = InkriptMapper.Mapper.Map<BusinessProcesses>(businessProcess);
                entity.BPId = businessProcessesId;
                biz.UpdateBusinessProcess(entity);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                output.Result = null;
                output.Success = false;
                output.Message = "Unable to update business process Id:" + businessProcessesId;
            }
            return output;

        }

        public ObjectResult<BusinessProcesses> ChangeStatusBusinessProcess(int businessProcessId)
        {
            ObjectResult<BusinessProcesses> output = new ObjectResult<BusinessProcesses>();
            BusinessProcessesBLO biz = new BusinessProcessesBLO();

            try
            {
                if (!biz.BusinessProcessExist(businessProcessId))
                {
                    output.Message = string.Format("Business Processes Id {0} Not Found", businessProcessId);
                    return output;
                }

                biz.ChangeStatusBusinessProcess(businessProcessId);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                output.Result = null;
                output.Success = false;
                output.Message = "Unable to change business process Id:" + businessProcessId + " Status";
            }
            return output;
        }
    }
}