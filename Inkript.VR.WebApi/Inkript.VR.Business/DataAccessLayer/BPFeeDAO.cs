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
    public class BPFeeDAO : GenericDAO<BPFee>
    {
        public bool BPFeeExist(int bpId, int sectorId, int vtId)
        {
            using (ISession session = NHibernateHelper.OpenSession())
                try
                {
                    return session.Query<BPFee>().Any(c => (c.BPId == bpId && c.SectorId == sectorId && c.VTId == vtId));
                }
                catch (Exception ex)
                {
                    session.Clear();
                    Log.ErrorFormat("Cannot check if Business Process Fee Exist", ex);
                    throw new DALException("Cannot BPFeeExist", ex);
                }
        }

        public BPFee GetBPFee(int bpId, int sectorId, int vtId)
        {
            using (ISession session = NHibernateHelper.OpenSession())
                try
                {
                    return session.Query<BPFee>().Where(c => (c.BPId == bpId && c.SectorId == sectorId && c.VTId == vtId))
                        .FirstOrDefault();
                }
                catch (Exception ex)
                {
                    session.Clear();
                    Log.ErrorFormat("Cannot Get Business Process Fee", ex);
                    throw new DALException("Cannot GetBPFee", ex);
                }
        }

        public List<BPFee> GetBPFees(int bpId, int sectorId, int vehicleTypeId)
        {
            using (ISession session = NHibernateHelper.OpenSession())
                try
                {
                    return session.Query<BPFee>()
                        .Where(c => c.BPId == bpId && c.SectorId == sectorId && c.VTId == vehicleTypeId)
                        .ToList();
                }
                catch (Exception ex)
                {
                    session.Clear();
                    Log.ErrorFormat("Cannot Get Business Process Fee by Params", ex);
                    throw new DALException("Cannot GetBPFees", ex);
                }
        }
    }
}
