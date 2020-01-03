using System;
using System.Collections.Generic;
using System.Linq;
using Inkript.VR.Business.DataAccessLayer;
using Inkript.VR.Models;

namespace Inkript.VR.Business.BusinessLayer
{
    public class BusinessProcessesBLO
    {
        private BusinessProcessesDAO _da { get; set; }

        public BusinessProcessesBLO()
        {
            _da = new BusinessProcessesDAO();
        }

        public GenericPagedList<BusinessProcesses> GetAllBusinessProcessesPaged(int pageNumber, int pageSize)
        {
            return _da.GetAllPaged(pageNumber, pageSize);
        }

        public bool BusinessProcessExist(int businessProcessId)
        {
            return _da.Exist(businessProcessId);
        }

        public BusinessProcesses GetByBusinessProcessAndSecondaries(int businessProcessId)
        {
            return _da.GetSecondaryBusinessProcesses(_da.GetById(businessProcessId));
        }

        public BusinessProcesses GetByBusinessProcessId(int businessProcessId)
        {
            return _da.GetById(businessProcessId);
        }

        public List<BusinessProcesses> GetPrimaryBusinessProcesses()
        {
            return _da.GetPrimaryBusinessProcesses();
        }

        public bool BPNameEnExist(string bPNameEn)
        {
            return _da.BPNameEnExist(bPNameEn);
        }

        public bool BPNameArExist(string bPNameAr)
        {
            return _da.BPNameArExist(bPNameAr);
        }

        public void CreateBusinessProcess(BusinessProcesses businessProcess)
        {
            if (businessProcess.BPRelationships != null && businessProcess.BPRelationships.Count() > 0)
            {
                businessProcess.BPRelationships = businessProcess.BPRelationships
                    .Where(c => c.BPId != 0)
                    .ToList();
            }
            _da.CreateBusinessProcess(businessProcess);
        }

        public void UpdateBusinessProcess(BusinessProcesses businessProcesses)
        {
            _da.SaveOrUpdate(businessProcesses, string.Empty);
        }

        public List<BusinessProcesses> BusinessProcessesFilter(string search)
        {
            return _da.BusinessProcessesFilter(search).ToList();
        }

        public List<BusinessProcesses> GetAllBusinessProcesses()
        {
            return _da.GetAll().ToList();
        }

        public List<BusinessProcesses> GetAllBusinessProcessDeliverables(int businessProcessId)
        {
            return _da.GetAllBusinessProcessDeliverables(businessProcessId);
        }

        public bool HotKeyExist(string hotKey)
        {
            return _da.HotKeyExist(hotKey);
        }

        public void ChangeStatusBusinessProcess(int businessProcessId)
        {
            int statusId = 1;
            BusinessProcesses businessProcess = _da.GetById(businessProcessId);
            if (businessProcess.StatusId == (int)FlagStatus.Active)
                statusId = (int)FlagStatus.Inactive;
            else
                statusId = (int)FlagStatus.Active;

            businessProcess.StatusId = statusId;
            UpdateBusinessProcess(businessProcess);
        }

        public int GetCarStatus(int businessProcessId)
        {
            return _da.GetCarStatus(businessProcessId);
        }

        public List<SecondaryBusinessProcesses> GetSecondaryBusinessProcessesBy
            (int businessProcessId, int? sectorId, int? vehicleTypeId, int? CarUniqueNumber)
        {
            return _da.GetSecondaryBusinessProcessesBy(businessProcessId, sectorId, vehicleTypeId, CarUniqueNumber).ToList();
        }
    }
}
