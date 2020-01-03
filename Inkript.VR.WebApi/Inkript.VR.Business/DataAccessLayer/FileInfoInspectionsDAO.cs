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
    public class FileInfoInspectionsDAO : GenericDAO<FileInfoInspections>
    {
        public void CreateFileInfoInspections(FileInfoInspections file)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            using (ITransaction transaction = session.BeginTransaction())
            {
                try
                {
                    IList<ImportInspections> importInspections = file.ImportInspections;
                    file.ImportInspections = null;
                    session.Save(file);

                    foreach (var item in importInspections)
                    {
                        item.ImportDate = DateTime.Now;
                        item.FileInfoInspections = file;
                        session.Save(item);
                    }

                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    session.Clear();
                    Log.ErrorFormat("Cannot Create File Info Inspection", ex);
                    throw new DALException("Cannot CreateFileInfoInspections", ex);
                }
            }
        }

        public void DeleteFileInspections(int fileInspectionsId)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            using (ITransaction transaction = session.BeginTransaction())
            {
                try
                {
                    FileInfoInspections fileInfo = session.Query<FileInfoInspections>()
                        .Where(c => c.FileInfoInspectionId == fileInspectionsId)
                        .FirstOrDefault();

                    if (fileInfo.ImportInspections != null && fileInfo.ImportInspections.Count != 0)
                    {
                        foreach (var item in fileInfo.ImportInspections)
                        {
                            session.Delete(item);
                        }
                    }

                    session.Delete(fileInfo);
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    session.Clear();
                    Log.ErrorFormat("Cannot Delete File Info Inspection Id {0}", fileInspectionsId, ex);
                    throw new DALException("Cannot DeleteFileInspections", ex);
                }
            }
        }

        public void CreateOrUpdateFileInfoInspections(FileInfoInspections file)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            using (ITransaction transaction = session.BeginTransaction())
            {
                try
                {
                    IList<ImportInspections> importInspections = file.ImportInspections;

                    if (session.Query<FileInfoInspections>().Any(x => x.Name == file.Name))
                    {
                        FileInfoInspections fileEntity = session.Query<FileInfoInspections>()
                            .Where(c => c.Name == file.Name)
                            .FirstOrDefault();

                        fileEntity.BranchName = file.BranchName;
                        fileEntity.FileType = file.FileType;
                        fileEntity.FromDate = file.FromDate;
                        fileEntity.TillDate = file.TillDate;
                        fileEntity.Name = file.Name;
                        fileEntity.NoRecords = file.NoRecords;
                        fileEntity.ImportedDate = file.ImportedDate;
                        fileEntity.ImportStatus = file.ImportStatus;

                        session.Update(fileEntity);
                    }
                    else
                    {
                        file.ImportedDate = DateTime.Now;
                        session.Save(file);
                    }

                    if (importInspections != null && importInspections.Count != 0)
                    {
                        foreach (var item in importInspections)
                        {
                            if (session.Query<ImportInspections>().Any(x => x.CertificateNo == item.CertificateNo))
                            {
                                ImportInspections importInspect = session.Query<ImportInspections>()
                                    .Where(c => c.CertificateNo == item.CertificateNo)
                                    .FirstOrDefault();

                                importInspect.CarUniqueNumber = item.CarUniqueNumber;
                                importInspect.InspectionDate = item.InspectionDate;
                                importInspect.PlateNumber = item.PlateNumber;
                                importInspect.PlateCodeId = item.PlateCodeId;
                                importInspect.CertificateNo = item.CertificateNo;
                                importInspect.Result = item.Result;
                                importInspect.CreatedBy = item.CreatedBy;
                                importInspect.Chassis = item.Chassis;

                                session.Update(importInspect);
                            }
                        }
                    }
                    else
                    {
                        if (importInspections != null && importInspections.Count != 0)
                        {
                            foreach (var item in importInspections)
                            {
                                item.FileInfoInspections = file;
                                item.ImportDate = DateTime.Now;
                                session.Save(item);
                            }
                        }
                    }
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    session.Clear();
                    Log.ErrorFormat("Cannot Create Or Update File Info Inspections", ex);
                    throw new DALException("Cannot CreateOrUpdateFileInfoInspections", ex);
                }
            }
        }

        public bool FileInspectionsExist(int fileInspectionsId)
        {
            using (ISession session = NHibernateHelper.OpenSession())
                try
                {
                    return session.Query<FileInfoInspections>().Any(c => c.FileInfoInspectionId == fileInspectionsId);
                }
                catch (Exception ex)
                {
                    session.Clear();
                    Log.ErrorFormat("Cannot check File Info Inspection exist {0}", fileInspectionsId, ex);
                    throw new DALException("Cannot FileInspectionsExist", ex);
                }
        }
    }
}
