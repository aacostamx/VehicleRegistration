using Inkript.Logging;
using Inkript.VR.Business.Helpers;
using Inkript.VR.Models;
using NHibernate;
using NHibernate.Linq;
using System;
using System.Linq;

namespace Inkript.VR.Business.DataAccessLayer
{
    public class PlateCodesDAO : GenericDAO<PlateCodes>
    {
        public bool PlateCodeForBranch(int branchId)
        {
            using (ISession session = NHibernateHelper.OpenSession())
                try
                {
                    return session.Query<PlateCodes>().Any(c => c.BranchId == branchId);
                }
                catch (Exception ex)
                {
                    session.Clear();
                    Log.ErrorFormat("Cannot Get Plate Code For Branch id {0}", branchId, ex);
                    throw new DALException("Cannot PlateCodeForBranch.", ex);
                }
        }
    }
}
