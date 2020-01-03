using System;
using Inkript.VR.Models;
using NHibernate;
using Inkript.VR.Business.Helpers;
using NHibernate.Linq;
using System.Linq;
using System.Collections.Generic;
using NHibernate.Criterion;
using NHibernate.Transform;
using Inkript.Logging;

namespace Inkript.VR.Business.DataAccessLayer
{
    public class ImportCustomsDAO : GenericDAO<ImportCustoms>
    {
        #region Methods
        public override GenericPagedList<ImportCustoms> GetAllPaged(int pageNumber, int pageSize)
        {
            GenericPagedList<ImportCustoms> result = base.GetAllPaged(pageNumber, pageSize);
            foreach (var item in result.PagedList)
            {
                item.FileInfoCustoms.ImportCustoms = new List<ImportCustoms>();
            }

            return result;
        }

        public override ImportCustoms GetById(int Id)
        {
            ImportCustoms result = base.GetById(Id);
            result.FileInfoCustoms.ImportCustoms = new List<ImportCustoms>();
            return result;
        }

        public IList<ImportCustoms> GetByCertificationId(string certificationId)
        {
            IList<ImportCustoms> importCustoms = new List<ImportCustoms>();

            using (ISession session = NHibernateHelper.OpenSession())
                try
                {
                    importCustoms = session.CreateCriteria<ImportCustoms>()
                        .Add(Restrictions.Like("CertificateId", "%" + certificationId + "%"))
                        .List<ImportCustoms>();

                    foreach (var item in importCustoms)
                    {
                        item.FileInfoCustoms.ImportCustoms = new List<ImportCustoms>();
                        if (item.ColorId != null && item.ColorId > 0)
                        {
                            item.Color = session.Query<Colors>().Where(c => c.ColorId == item.ColorId).FirstOrDefault(); 
                        }
                        if (item.BrandId != null && item.BrandId > 0)
                        {
                            item.Brand = session.Query<Brand>().Where(c => c.BrandId == item.BrandId).FirstOrDefault(); 
                        }
                        if (item.ModelId != null && item.ModelId > 0)
                        {
                            item.Model = session.Query<Model>().Where(c => c.ModelId == item.ModelId).FirstOrDefault(); 
                        }
                    }
                }
                catch (Exception ex)
                {
                    session.Clear();
                    Log.ErrorFormat("Cannot Get By Certification Id {0}", certificationId, ex);
                    throw new DALException("Cannot GetByCertificationId.", ex);
                }
            return importCustoms;
        }

        public bool ImportCustomsExist(int importCustomsId)
        {
            using (ISession session = NHibernateHelper.OpenSession())
                try
                {
                    return session.Query<ImportCustoms>().Any(c => c.ImportCustomId == importCustomsId);
                }
                catch (Exception ex)
                {
                    session.Clear();
                    Log.ErrorFormat("Cannot check if Import Custom Id Exist {0}", importCustomsId, ex);
                    throw new DALException("Cannot ImportCustomsExist", ex);
                }
        }

        public void UpdateImportCustom(int importCustomsId, ImportCustoms importCustom)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            using (ITransaction transaction = session.BeginTransaction())
            {
                try
                {
                    ImportCustoms entity = session.Query<ImportCustoms>()
                        .Where(c => c.ImportCustomId == importCustomsId)
                        .FirstOrDefault();

                    entity.CertificateDate = importCustom.CertificateDate;
                    entity.OperationType = importCustom.OperationType;
                    entity.FiscalYear = importCustom.FiscalYear;
                    entity.ImporterCode = importCustom.ImporterCode;
                    entity.ImporterName = importCustom.ImporterName;
                    entity.BrandId = importCustom.BrandId;
                    entity.BrandDesc = importCustom.BrandDesc;
                    entity.ModelId = importCustom.ModelId;
                    entity.ModelDesc = importCustom.ModelDesc;
                    entity.ProductionYear = importCustom.ProductionYear;
                    entity.ColorId = importCustom.ColorId;
                    entity.ColorDesc = importCustom.ColorDesc;
                    entity.Chassis = importCustom.Chassis;
                    entity.MotorNumber = importCustom.MotorNumber;
                    entity.Comments = importCustom.Comments;
                    entity.DateModified = DateTime.Now;
                    entity.Value = importCustom.Value;
                    entity.Taxes = importCustom.Taxes;
                    entity.Cylinders = importCustom.Cylinders;
                    entity.OfficeId = importCustom.OfficeId;
                    entity.Discounted = importCustom.Discounted;

                    session.Update(entity);
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    session.Clear();
                    Log.ErrorFormat("Cannot Update Import Custom", ex);
                    throw new DALException("Cannot Update Import Custom Object", ex);
                }
            }
        }

        public bool CertificationExist(string certificationId)
        {
            using (ISession session = NHibernateHelper.OpenSession())
                try
                {
                    return session.Query<ImportCustoms>().Any(c => c.CertificateId == certificationId);
                }
                catch (Exception ex)
                {
                    session.Clear();
                    Log.ErrorFormat("Cannot check if Certification Id Exist {0}", certificationId, ex);
                    throw new DALException("Cannot CertificationExist", ex);
                }
        }

        public bool ChassisExist(string chassis)
        {
            using (ISession session = NHibernateHelper.OpenSession())
                try
                {
                    return session.Query<ImportCustoms>().Any(c => c.Chassis == chassis);
                }
                catch (Exception ex)
                {
                    session.Clear();
                    Log.ErrorFormat("Cannot check if Chassis Exist {0}", chassis, ex);
                    throw new DALException("Cannot ChassisExist", ex);
                }
        }

        public IList<ImportCustoms> ImportCustomsFilter(DateTime yearFrom, DateTime yearTo, ImportCustoms importCustoms)
        {
            using (ISession session = NHibernateHelper.OpenSession())
                try
                {
                    IList<ImportCustoms> result = session.GetNamedQuery("ImportCustomsFilter")
                        .SetParameter("YearFrom", yearFrom)
                        .SetParameter("YearTo", yearTo)
                        .SetParameter("OperationType", importCustoms.OperationType)
                        .SetParameter("Chassis", importCustoms.Chassis)
                        .SetParameter("MotorNumber", importCustoms.MotorNumber)
                        .SetParameter("BrandId", importCustoms.BrandId)
                        .SetParameter("ModelId", importCustoms.ModelId)
                        .SetParameter("ColorId", importCustoms.ColorId)
                        .SetParameter("Cylinders", importCustoms.Cylinders)
                        .SetParameter("OfficeId", importCustoms.OfficeId)
                        .SetParameter("ProductionYear", importCustoms.ProductionYear)
                        .SetParameter("CertificateId", importCustoms.CertificateId)
                        .SetParameter("ImporterCode", importCustoms.ImporterCode)
                        .SetParameter("ImporterName", importCustoms.ImporterName)
                        .SetParameter("Discounted", importCustoms.Discounted)
                        .SetResultTransformer(Transformers.AliasToBean(typeof(ImportCustoms)))
                        .List<ImportCustoms>();

                    if (result != null && result.Count > 0)
                    {
                        foreach (var item in result)
                        {
                            item.FileInfoCustoms = session.Query<FileInfoCustoms>()
                                .Where(c => c.FileInfoCustomId == item.FileInfoCustomId)
                                .FirstOrDefault();
                            item.FileInfoCustoms.ImportCustoms = new List<ImportCustoms>();
                        }
                    }

                    return result;
                }
                catch (Exception ex)
                {
                    session.Clear();
                    Log.ErrorFormat("Cannot Get Import Customs by Filter", ex);
                    throw new DALException("Cannot ImportCustomsFilter", ex);
                }
        }

        public void DeleteImportCustom(int importCustomsId)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            using (ITransaction transaction = session.BeginTransaction())
            {
                try
                {
                    ImportCustoms importCustom = session.Query<ImportCustoms>()
                        .Where(c => c.ImportCustomId == importCustomsId)
                        .FirstOrDefault();

                    session.Delete(importCustom);
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    session.Clear();
                    Log.ErrorFormat("Cannot Get Import Customs by Filter", ex);
                    throw new DALException("Cannot Delete Import Custom Object", ex);
                }
            }
        }

        public void CreateImportCustom(int fileInfoId, ImportCustoms importCustom)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            using (ITransaction transaction = session.BeginTransaction())
            {
                try
                {
                    importCustom.FileInfoCustoms = new FileInfoCustoms { FileInfoCustomId = fileInfoId };
                    importCustom.CreatedDate = DateTime.Now;
                    session.Save(importCustom);
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    session.Clear();
                    Log.ErrorFormat("Cannot Add Import Custom", ex);
                    throw new DALException("Cannot Add Import Custom Object", ex);
                }
            }
        }



        public List<ImportCustoms> GetByFileInfoId(int fileInfoId)
        {
            using (ISession session = NHibernateHelper.OpenSession())
                try
                {
                    return session.QueryOver<FileInfoCustoms>().Where(f => f.FileInfoCustomId == fileInfoId).SingleOrDefault<FileInfoCustoms>().ImportCustoms.ToList<ImportCustoms>();
                }
                catch (Exception ex)
                {
                    session.Clear();
                    Log.ErrorFormat("Cannot Get By File Info Id {0}", fileInfoId, ex);
                    throw new DALException("Cannot ImportCustomsExist", ex);
                }
        }

        public string GetCarValueByCustomsCertificate(string certificationId)
        {
            using (ISession session = NHibernateHelper.OpenSession())
                try
                {
                    return session.GetNamedQuery("GetCarValueByCustomsCertificationId")
                        .SetParameter("CertificationId", certificationId)
                        .UniqueResult<string>();
                }
                catch (Exception ex)
                {
                    session.Clear();
                    Log.ErrorFormat("Cannot Get Car Value by Certification Id", ex);
                    throw new DALException("Cannot Get Car Value by Certification Id", ex);
                }
        }

        public string GetCarValueEstimationByCarSpecs
            (string brandId, int modelId, string trim, double cc, double numberHorses, string chassisNumber)
        {
            {
                using (ISession session = NHibernateHelper.OpenSession())
                    try
                    {
                        return session.GetNamedQuery("GetCarValueEstimationByCarSpecs")
                            .SetParameter("BrandId", brandId)
                            .SetParameter("ModelId", modelId)
                            .SetParameter("Trim", trim)
                            .SetParameter("CC", cc)
                            .SetParameter("NumberHorses", numberHorses)
                            .SetParameter("ChassisNumber", chassisNumber)
                            .UniqueResult<string>();
                    }
                    catch (Exception ex)
                    {
                        session.Clear();
                        Log.ErrorFormat("Cannot Get Car Value by Brand, Model, Trim, CC, NumberHorses, ChassisNumber", ex);
                        throw new DALException("Cannot Get Car Value by Brand, Model, Trim, CC, NumberHorses, ChassisNumber", ex);
                    }
            }
        }

        public CustomsInfo GetCustomsInfo(string chassis)
        {
            CustomsInfo customsInfo = new CustomsInfo();

            using (ISession session = NHibernateHelper.OpenSession())
                try
                {
                    ImportCustoms importCustoms = session.Query<ImportCustoms>()
                        .Where(c => c.Chassis == chassis)
                        .FirstOrDefault();

                    customsInfo.Value = importCustoms.Value;
                    customsInfo.Taxes = importCustoms.Taxes;

                    return customsInfo;
                }
                catch (Exception ex)
                {
                    session.Clear();
                    Log.ErrorFormat("Cannot Get Customs Info by Chassis", ex);
                    throw new DALException("Cannot Get Customs Info by Chassis", ex);
                }
        }
        #endregion
    }
}
