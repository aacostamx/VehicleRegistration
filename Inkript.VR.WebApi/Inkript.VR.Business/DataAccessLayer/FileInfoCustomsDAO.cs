using Inkript.Logging;
using Inkript.VR.Business.Helpers;
using Inkript.VR.Models;
using NHibernate;
using NHibernate.Linq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Inkript.VR.Business.DataAccessLayer
{
    public class FileInfoCustomsDAO : GenericDAO<FileInfoCustoms>
    {
        #region Methods
        public override IList<FileInfoCustoms> GetAll()
        {
            using (ISession session = NHibernateHelper.OpenSession())
                try
                {
                    return session.Query<FileInfoCustoms>().ToList();
                }
                catch (Exception ex)
                {
                    session.Clear();
                    Log.ErrorFormat("Cannot get all file Info", ex);
                    throw new DALException("Cannot GetAll.", ex);
                }
        }

        public FileInfoCustoms CreateFileInfoCustoms(FileInfoCustoms fileInfoCustom)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            using (ITransaction transaction = session.BeginTransaction())
            {
                try
                {
                    IList<ImportCustoms> importCustoms = fileInfoCustom.ImportCustoms;
                    fileInfoCustom.ImportCustoms = null;
                    session.Save(fileInfoCustom);

                    if (importCustoms != null && importCustoms.Count != 0)
                    {
                        foreach (var item in importCustoms)
                        {
                            bool exist = session.Query<ImportCustoms>().Any(x => x.CertificateId == item.CertificateId);
                            if ((item.OperationType == "NEW" || item.OperationType == "MODIFY") && !exist)
                            {
                                item.CreatedDate = DateTime.Now;
                                item.FileInfoCustoms = fileInfoCustom;
                                session.Save(item);
                            }
                            else
                            {
                                if (item.OperationType == "MODIFY" && exist)
                                {
                                    ImportCustoms importEntity = session.Query<ImportCustoms>()
                                        .Where(c => c.CertificateId == item.CertificateId)
                                        .FirstOrDefault();

                                    importEntity.CertificateDate = item.CertificateDate;
                                    importEntity.OperationType = item.OperationType;
                                    importEntity.CertificateId = item.CertificateId;
                                    importEntity.FiscalYear = item.FiscalYear;
                                    importEntity.ImporterCode = item.ImporterCode;
                                    importEntity.ImporterName = item.ImporterName;
                                    importEntity.BrandId = item.BrandId;
                                    importEntity.BrandDesc = item.BrandDesc;
                                    importEntity.ModelId = item.ModelId;
                                    importEntity.ModelDesc = item.ModelDesc;
                                    importEntity.ProductionYear = item.ProductionYear;
                                    importEntity.ColorId = item.ColorId;
                                    importEntity.ColorDesc = item.ColorDesc;
                                    importEntity.Chassis = item.Chassis;
                                    importEntity.MotorNumber = item.MotorNumber;
                                    importEntity.Comments = item.Comments;
                                    importEntity.DateModified = DateTime.Now;
                                    importEntity.Value = item.Value;
                                    importEntity.Taxes = item.Taxes;
                                    importEntity.Cylinders = item.Cylinders;
                                    importEntity.OfficeId = item.OfficeId;
                                    importEntity.Discounted = item.Discounted;
                                    importEntity.FileInfoCustoms = fileInfoCustom;

                                    session.Update(importEntity);
                                }
                            }
                        }
                    }
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    session.Clear();
                    Log.ErrorFormat("Cannot create file Info", ex);
                    throw new DALException("Cannot CreateFileInfo", ex);
                }
            }
            return fileInfoCustom;
        }

        public FileInfoCustoms CheckDuplicateCertifications(FileInfoCustoms fileInfoCustom)
        {
            using (ISession session = NHibernateHelper.OpenSession())
                try
                {
                    if (fileInfoCustom.ImportCustoms != null && fileInfoCustom.ImportCustoms.Count != 0)
                    {
                        foreach (var item in fileInfoCustom.ImportCustoms)
                        {
                            if (item.OperationType == "NEW")
                            {
                                if (session.Query<ImportCustoms>().Any(x => x.CertificateId == item.CertificateId))
                                {
                                    fileInfoCustom.ImportStatus = "Fail";
                                    fileInfoCustom.ImportCustoms = new List<ImportCustoms>();
                                    fileInfoCustom.MessageError = string.Format("Duplicate Certification Id: {0}", item.CertificateId);
                                    break;
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    session.Clear();
                    Log.ErrorFormat("Cannot check file Info duplicates", ex);
                    throw new DALException("Cannot CheckDuplicateCertifications", ex);
                }

            return fileInfoCustom;
        }

        public bool DeleteFileInfoCustoms(int fileInfoId)
        {
            bool result = false;
            using (ISession session = NHibernateHelper.OpenSession())
            using (ITransaction transaction = session.BeginTransaction())
            {
                try
                {
                    FileInfoCustoms fileInfo = session.Query<FileInfoCustoms>()
                        .Where(c => c.FileInfoCustomId == fileInfoId).FirstOrDefault();

                    if (fileInfo.ImportCustoms != null && fileInfo.ImportCustoms.Count > 0)
                    {
                        foreach (var item in fileInfo.ImportCustoms)
                        {
                            session.Delete(item);
                        }
                    }

                    if (fileInfo != null && fileInfo.FileInfoCustomId != 0)
                    {
                        session.Delete(fileInfo);
                        transaction.Commit();
                        result = true;
                    }
                    return result;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    session.Clear();
                    Log.ErrorFormat("Cannot Delete file Info of ID {0}", fileInfoId, ex);
                    throw new DALException("Cannot DeleteFileInfo", ex);
                }
            }
        }

        public bool FileInfoCustomsNameExist(string name)
        {
            using (ISession session = NHibernateHelper.OpenSession())
                try
                {
                    return session.Query<FileInfoCustoms>().Any(c => c.Name == name);
                }
                catch (Exception ex)
                {
                    session.Clear();
                    Log.ErrorFormat("Cannot check if file info exists : {0}", name, ex);
                    throw new DALException("Cannot FileInfoNameExist", ex);
                }
        }

        public bool FileInfoCustomsExist(int fileInfoCustoms)
        {
            using (ISession session = NHibernateHelper.OpenSession())
                try
                {
                    return session.Query<FileInfoCustoms>().Any(c => c.FileInfoCustomId == fileInfoCustoms);
                }
                catch (Exception ex)
                {
                    session.Clear();
                    Log.ErrorFormat("Cannot Find file Info having Id : {0}", fileInfoCustoms, ex);
                    throw new DALException("Cannot FileInfoExist", ex);
                }
        }

        public IList<FileInfoCustoms> GetByFileInfoCustomsName(string name)
        {
            using (ISession session = NHibernateHelper.OpenSession())
                try
                {
                    return session.Query<FileInfoCustoms>().Where(c => c.Name.Contains(name)).ToList();
                }
                catch (Exception ex)
                {
                    session.Clear();
                    Log.ErrorFormat("Cannot get the file Info having the name : {0}", name, ex);
                    throw new DALException("Cannot GetByFileInfoName", ex);
                }
        }

        public FileInfoCustoms GetByFileInfoCustomsId(int fileInfoCustomId)
        {
            using (ISession session = NHibernateHelper.OpenSession())
                try
                {
                    return session.Query<FileInfoCustoms>()
                        .Where(c => c.FileInfoCustomId == fileInfoCustomId)
                        .FirstOrDefault();
                }
                catch (Exception ex)
                {
                    session.Clear();
                    Log.ErrorFormat("Cannot get file Info by Id : {0}", fileInfoCustomId);
                    throw new DALException("Cannot GetByFileInfoId", ex);
                }
        }

        public void UpdateFileInfoCustoms(FileInfoCustoms fileInfoCustom)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            using (ITransaction transaction = session.BeginTransaction())
            {
                try
                {
                    IList<ImportCustoms> importCustoms = fileInfoCustom.ImportCustoms;
                    fileInfoCustom.ImportCustoms = null;

                    session.Update(fileInfoCustom);

                    foreach (var item in importCustoms)
                    {
                        if (session.Query<ImportCustoms>().Any(c => c.ImportCustomId == item.ImportCustomId))
                        {
                            ImportCustoms importCustom = session.Query<ImportCustoms>()
                              .Where(c => c.ImportCustomId == item.ImportCustomId)
                              .FirstOrDefault();

                            importCustom.OperationType = item.OperationType;
                            importCustom.FiscalYear = item.FiscalYear;
                            importCustom.ImporterCode = item.ImporterCode;
                            importCustom.ImporterName = item.ImporterName;
                            importCustom.BrandId = item.BrandId;
                            importCustom.BrandDesc = item.BrandDesc;
                            importCustom.ModelId = item.ModelId;
                            importCustom.ModelDesc = item.ModelDesc;
                            importCustom.ProductionYear = item.ProductionYear;
                            importCustom.ColorId = item.ColorId;
                            importCustom.ColorDesc = item.ColorDesc;
                            importCustom.Chassis = item.Chassis;
                            importCustom.MotorNumber = item.MotorNumber;
                            importCustom.Comments = item.Comments;
                            importCustom.DateModified = DateTime.Now;
                            importCustom.Value = item.Value;
                            importCustom.Taxes = item.Taxes;
                            importCustom.Cylinders = item.Cylinders;
                            importCustom.OfficeId = item.OfficeId;
                            importCustom.Discounted = item.Discounted;

                            session.Update(importCustom);
                        }
                        else
                        {
                            item.FileInfoCustoms = fileInfoCustom;
                            session.Save(item);
                        }
                    }

                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    session.Clear();
                    Log.ErrorFormat("Cannot Update File Info ", ex);
                    throw new DALException("Cannot UpdateFileInfo", ex);
                }
            }
        }

        #endregion
    }
}
