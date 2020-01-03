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
    public class BusinessProcessesDAO : GenericDAO<BusinessProcesses>
    {
        public bool BPNameEnExist(string bPNameEn)
        {
            using (ISession session = NHibernateHelper.OpenSession())
                try
                {
                    return session.Query<BusinessProcesses>().Any(c => (c.BPNameEn == bPNameEn));
                }
                catch (Exception ex)
                {
                    session.Clear();
                    Log.ErrorFormat("Cannot check BPNameEn exist {0}", bPNameEn, ex);
                    throw new DALException("Cannot BPNameEnExist", ex);
                }
        }

        public BusinessProcesses GetSecondaryBusinessProcesses(BusinessProcesses businessProcess)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                try
                {
                    if (businessProcess.BPRelationships != null && businessProcess.BPRelationships.Count() > 0)
                    {
                        foreach (var item in businessProcess.BPRelationships)
                        {
                            BusinessProcesses secundary = session.Query<BusinessProcesses>()
                                .Where(c => c.BPId == item.AssociatedBP)
                                .FirstOrDefault();

                            if (secundary != null)
                            {
                                businessProcess.SecondaryBusinessProcesses.Add(new SecondaryBusinessProcesses
                                {
                                    BPRelationshipsId = item.BPRelationshipsId,
                                    BPId = item.BPId,
                                    AssociatedBP = secundary.BPId,
                                    BPNameAr = secundary.BPNameAr,
                                    BPNameEn = secundary.BPNameEn,
                                    BPType = secundary.BPType,
                                    Icon = secundary.Icon,
                                    HotKey = secundary.HotKey,
                                    BPUrl = secundary.BPUrl,
                                    CarStatusId = secundary.CarStatusId,
                                    StatusId = secundary.StatusId
                                });
                            }
                        }
                    }

                    return businessProcess;
                }
                catch (Exception ex)
                {
                    session.Clear();
                    Log.ErrorFormat("Cannot Get All Business Processes", ex);
                    throw new DALException("Cannot GetAllBusinessProcesses", ex);
                }
            }
        }

        public List<BusinessProcesses> GetAllBusinessProcessDeliverables(int businessProcessId)
        {
            using (ISession session = NHibernateHelper.OpenSession())
                try
                {
                    List<BusinessProcesses> deliverables = session.Query<BusinessProcesses>()
                        .Where(c => c.BPId == businessProcessId)
                        .FetchMany(c => c.BPOutputRel)
                        .ToList();

                    return deliverables;
                }
                catch (Exception ex)
                {
                    session.Clear();
                    Log.ErrorFormat("Cannot Get All Business Process Deliverables by BPId {0}", businessProcessId, ex);
                    throw new DALException("Cannot GetAllBusinessProcessDeliverables", ex);
                }
        }

        public int GetCarStatus(int businessProcessId)
        {
            using (ISession session = NHibernateHelper.OpenSession())
                try
                {
                    return session.Query<BusinessProcesses>()
                        .Where(c => (c.BPId == businessProcessId))
                        .Select(c => c.CarStatusId)
                        .FirstOrDefault();
                }
                catch (Exception ex)
                {
                    session.Clear();
                    Log.ErrorFormat("Cannot Get Car Status Id from Business Process Id {0}", businessProcessId, ex);
                    throw new DALException("Cannot GetCarStatus", ex);
                }
        }

        public bool BPNameArExist(string bPNameAr)
        {
            using (ISession session = NHibernateHelper.OpenSession())
                try
                {
                    return session.Query<BusinessProcesses>().Any(c => (c.BPNameAr == bPNameAr));
                }
                catch (Exception ex)
                {
                    session.Clear();
                    Log.ErrorFormat("Cannot check BPNameAr exist {0}", bPNameAr, ex);
                    throw new DALException("Cannot BPNameArExist", ex);
                }
        }

        public void CreateBusinessProcess(BusinessProcesses businessProcess)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            using (ITransaction transaction = session.BeginTransaction())
            {
                try
                {
                    List<BPRelationships> relationships = businessProcess.BPRelationships.ToList();
                    businessProcess.BPRelationships = null;
                    session.Save(businessProcess);

                    if (relationships != null && relationships.Count > 0)
                    {
                        foreach (var item in relationships)
                        {
                            if (businessProcess.BPType.ToLower().Equals("secondary"))
                            {
                                item.AssociatedBP = businessProcess.BPId;
                                item.BPId = item.BPId;
                            }
                            else
                            {
                                item.AssociatedBP = item.BPId;
                                item.BPId = businessProcess.BPId;
                            }
                            session.Save(item);
                        }
                    }

                    if (businessProcess.BPSectorVehicle != null 
                        && businessProcess.BPSectorVehicle.Count > 0)
                    {
                        foreach (var item in businessProcess.BPSectorVehicle)
                        {
                            item.BPId = businessProcess.BPId;
                            session.Save(item);
                        }
                    }

                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    session.Clear();
                    Log.ErrorFormat("Cannot Create Business Process", ex);
                    throw new DALException("Cannot CreateBusinessProcess", ex);
                }
            }
        }

        public IList<BusinessProcesses> BusinessProcessesFilter(string search)
        {
            using (ISession session = NHibernateHelper.OpenSession())
                try
                {
                    return session.GetNamedQuery("BusinessProcessesFilter")
                         .SetString("search", search)
                         .SetResultTransformer(Transformers.AliasToBean(typeof(BusinessProcesses))).List<BusinessProcesses>();
                }
                catch (Exception ex)
                {
                    session.Clear();
                    Log.ErrorFormat("Cannot get search {0}", search, ex);
                    throw new DALException("Cannot BusinessProcessesFilter", ex);
                }
        }

        public List<BusinessProcesses> GetPrimaryBusinessProcesses()
        {
            List<BusinessProcesses> primaryBusinessProcesses = new List<BusinessProcesses>();

            using (ISession session = NHibernateHelper.OpenSession())
                try
                {
                    return session.Query<BusinessProcesses>()
                         .Where(p => p.BPType.ToLower() == "primary" && p.StatusId == (int)FlagStatus.Active)
                         .ToList();
                }
                catch (Exception ex)
                {
                    session.Clear();
                    Log.ErrorFormat("Cannot get primary business processes", ex);
                    throw new DALException("Cannot BusinessProcessesFilter", ex);
                }
        }

        public bool HotKeyExist(string hotKey)
        {
            using (ISession session = NHibernateHelper.OpenSession())
                try
                {
                    return session.Query<BusinessProcesses>().Any(c => (c.HotKey == hotKey));
                }
                catch (Exception ex)
                {
                    session.Clear();
                    Log.ErrorFormat("HotKey Already Exist {0}", hotKey, ex);
                    throw new DALException("Cannot HotKeyExist", ex);
                }
        }

        public IList<SecondaryBusinessProcesses> GetSecondaryBusinessProcessesBy
            (int businessProcessId, int? sectorId, int? vehicleTypeId, int? carUniqueNumber)
        {
            using (ISession session = NHibernateHelper.OpenSession())
                try
                {
                    return session.GetNamedQuery("GetSecondaryBusinessProcessesBy")
                        .SetParameter("BusinessProcessId", businessProcessId)
                        .SetParameter("SectorId", sectorId)
                        .SetParameter("VehicleTypeId", vehicleTypeId)
                        .SetParameter("CarUniqueNumber", carUniqueNumber)
                        .SetResultTransformer(Transformers.AliasToBean(typeof(SecondaryBusinessProcesses)))
                        .List<SecondaryBusinessProcesses>();
                }
                catch (Exception ex)
                {
                    session.Clear();
                    Log.ErrorFormat("Cannot Get Secondary Business Processes By Params", ex);
                    throw new DALException("Cannot GetSecondaryBusinessProcessesBy", ex);
                }
        }
    }
}
