using Inkript.Logging;
using Inkript.VR.Business.Helpers;
using Inkript.VR.Models;
using NHibernate;
using NHibernate.Linq;
using NHibernate.Transform;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Inkript.VR.Business.DataAccessLayer
{
    public class ImportInspectionsDAO : GenericDAO<ImportInspections>
    {
        public override ImportInspections GetById(int Id)
        {
            ImportInspections importInspection = base.GetById(Id);
            importInspection.FileInfoInspections.ImportInspections = new List<ImportInspections>();
            return importInspection;
        }

        public override GenericPagedList<ImportInspections> GetAllPaged(int pageNumber, int pageSize)
        {
            GenericPagedList<ImportInspections> importInspections = base.GetAllPaged(pageNumber, pageSize);
            foreach (var item in importInspections.PagedList)
            {
                item.FileInfoInspections.ImportInspections = new List<ImportInspections>();
            }
            return importInspections;
        }

        public IList<ImportInspections> ImportInspectionsFilter
            (DateTime yearFrom, DateTime yearTo, string plateNumber, int? code)
        {
            using (ISession session = NHibernateHelper.OpenSession())
                try
                {
                    IList<ImportInspections> importInspections = session.GetNamedQuery("ImportInspectionsFilter")
                        .SetParameter("YearFrom", yearFrom)
                        .SetParameter("YearTo", yearTo)
                        .SetParameter("PlateNumber", plateNumber)
                        .SetParameter("PlateCodeId", code)
                        .SetResultTransformer(Transformers.AliasToBean(typeof(ImportInspections)))
                        .List<ImportInspections>();

                    if (importInspections != null && importInspections.Count > 0)
                    {
                        foreach (var item in importInspections)
                        {
                            item.FileInfoInspections = session.Query<FileInfoInspections>()
                                .Where(c => c.FileInfoInspectionId == item.FileInfoInspectionId)
                                .FirstOrDefault();

                            item.FileInfoInspections.ImportInspections = new List<ImportInspections>();
                        }
                    }

                    return importInspections;                    
                }
                catch (Exception ex)
                {
                    session.Clear();
                    Log.ErrorFormat("Cannot Get Import Inspections By Search Filter", ex);
                    throw new DALException("Cannot ImportInspectionsFilter", ex);
                }
        }

        public int CheckInspection(int carUniqueNumber)
        {
            using (ISession session = NHibernateHelper.OpenSession())
                try
                {
                    string sql = @"EXEC CheckInspection " + carUniqueNumber.ToString();
                    return Convert.ToInt32(session.CreateSQLQuery(sql).UniqueResult());
                }
                catch (Exception ex)
                {
                    session.Clear();
                    Log.ErrorFormat("Cannot Check Inspection for Car Unique Number {0}", carUniqueNumber, ex);
                    throw new DALException("Cannot CheckInspection", ex);
                }
        }

        public bool CarUniqueNumberExist(int carUniqueNumber)
        {
            using (ISession session = NHibernateHelper.OpenSession())
                try
                {
                    return session.Query<ImportInspections>().Any(c => c.CarUniqueNumber == carUniqueNumber);
                }
                catch (Exception ex)
                {
                    session.Clear();
                    Log.ErrorFormat("Cannot Check If Car Unique Number {0} Exist", carUniqueNumber, ex);
                    throw new DALException("Cannot CarUniqueNumberExist", ex);
                }
        }

        public void DeleteImportInspections(int importInspectsId)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            using (ITransaction transaction = session.BeginTransaction())
            {
                try
                {
                    ImportInspections importInspections = session.Query<ImportInspections>()
                        .Where(c => c.ImportInspectionId == importInspectsId)
                        .FirstOrDefault();

                    session.Delete(importInspections);
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    session.Clear();
                    Log.ErrorFormat("Cannot Delete Import Inspection Id {0}", importInspectsId, ex);
                    throw new DALException("Cannot DeleteImportInspections", ex);
                }
            }
        }

        public bool ImportInspectionsExist(int importInspectsId)
        {
            using (ISession session = NHibernateHelper.OpenSession())
                try
                {
                    return session.Query<ImportInspections>().Any(c => c.ImportInspectionId == importInspectsId);
                }
                catch (Exception ex)
                {
                    session.Clear();
                    Log.ErrorFormat("Cannot Check If Import Inspection Id {0} Exist", importInspectsId, ex);
                    throw new DALException("Cannot ImportInspectionsExist", ex);
                }
        }
    }
}
