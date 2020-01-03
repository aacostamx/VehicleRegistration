using System;
using System.Collections.Generic;
using System.Linq;
using Inkript.VR.Business.DataAccessLayer;
using Inkript.VR.Models;

namespace Inkript.VR.Business.BusinessLayer
{
    public class ImportInspectionsBLO
    {
        #region Variables
        private ImportInspectionsDAO _da { get; set; }
        #endregion

        #region Methods
        public ImportInspectionsBLO()
        {
            _da = new ImportInspectionsDAO();
        }

        public GenericPagedList<ImportInspections> GetAllImportInspectionsPaged(int pageNumber, int pageSize)
        {
            return _da.GetAllPaged(pageNumber, pageSize);
        }

        public bool ImportInspectionsExist(int importInspectsId)
        {
            return _da.ImportInspectionsExist(importInspectsId);
        }

        public ImportInspections GetByImportInspectionsId(int importInspectsId)
        {
            return _da.GetById(importInspectsId);
        }

        public bool DeleteImportInspections(int importInspectsId)
        {
            return _da.Delete(GetByImportInspectionsId(importInspectsId));
        }

        public void CreateImportInspections(ImportInspections importInspects)
        {
            importInspects.ImportDate = DateTime.Now;
            _da.SaveOrUpdate(importInspects, string.Empty);
        }

        public List<ImportInspections> ImportInspectionsFilter
            (DateTime yearFrom, DateTime yearTo, string plateNumber, int? code)
        {
            return _da.ImportInspectionsFilter(yearFrom, yearTo, plateNumber, code).ToList();
        }

        public bool CarUniqueNumberExist(int carUniqueNumber)
        {
            return _da.CarUniqueNumberExist(carUniqueNumber);
        }

        public int CheckInspection(int carUniqueNumber)
        {
            return _da.CheckInspection(carUniqueNumber);
        }
        #endregion
    }
}
