using Inkript.VR.Business.DataAccessLayer;
using Inkript.VR.Models;
using System.Collections.Generic;
using System.Linq;
using System;

namespace Inkript.VR.Business.BusinessLayer
{
    public class ImportCustomsBLO
    {
        #region Variables
        private ImportCustomsDAO _da { get; set; }
        #endregion

        #region Methods
        public ImportCustomsBLO()
        {
            _da = new ImportCustomsDAO();
        }

        public List<ImportCustoms> GetAll()
        {
            return _da.GetAll().ToList();
        }

        public ImportCustoms GetByImportCustomsId(int importCustomsId)
        {
            return _da.GetById(importCustomsId);
        }

        public GenericPagedList<ImportCustoms> GetAllImportCustomsPaged(int pageNumber, int pageSize)
        {
            return _da.GetAllPaged(pageNumber, pageSize);
        }

        public List<ImportCustoms> GetByCertificationId(string certificationId)
        {
            return _da.GetByCertificationId(certificationId).ToList();
        }

        public bool ImportCustomsExist(int importCustomsId)
        {
            return _da.ImportCustomsExist(importCustomsId);
        }

        public List<ImportCustoms> GetByFileInfoId(int fileInfoId)
        {
            return _da.GetByFileInfoId(fileInfoId);
        }

        public void CreateImportCustom(int fileInfoId, ImportCustoms importCustom)
        {
            _da.CreateImportCustom(fileInfoId, importCustom);
        }

        public bool DeleteImportCustom(int importCustomsId)
        {
            return _da.Delete(GetByImportCustomsId(importCustomsId));
        }

        public void UpdateImportCustom(int importCustomsId, ImportCustoms importCustom)
        {
            _da.UpdateImportCustom(importCustomsId, importCustom);
        }

        public List<ImportCustoms> ImportCustomsFilter(DateTime yearFrom, DateTime yearTo, ImportCustoms importCustoms)
        {
            return _da.ImportCustomsFilter(yearFrom, yearTo, importCustoms).ToList();
        }

        public bool CertificationExist(string importCustomsId)
        {
            return _da.CertificationExist(importCustomsId);
        }

        public bool ChassisExist(string chassis)
        {
            return _da.ChassisExist(chassis);
        }

        public string GetCarValueByCustomsCertificate(string certificationId)
        {
            return _da.GetCarValueByCustomsCertificate(certificationId);
        }

        public string GetCarValueEstimationByCarSpecs
            (string brandId, int modelId, string trim, double cc, double numberHorses, string chassisNumber)
        {
            return _da.GetCarValueEstimationByCarSpecs
                (brandId, modelId, trim, cc, numberHorses, chassisNumber);
        }

        public CustomsInfo GetCustomsInfo(string chassis)
        {
            return _da.GetCustomsInfo(chassis);
        }
        #endregion
    }
}
