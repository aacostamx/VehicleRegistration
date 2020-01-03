using Inkript.Logging;
using Inkript.VR.Business.Helpers;
using Inkript.VR.Models;
using NHibernate;
using NHibernate.Criterion;
using NHibernate.Linq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Inkript.VR.Business.DataAccessLayer
{
    public class StatusDAO : GenericDAO<Status>
    {

        public override IList<Status> GetAll()
        {
            using (ISession session = NHibernateHelper.OpenSession())
                try
                {
                    return session.Query<Status>().ToList();
                }
                catch (Exception ex)
                {
                    session.Clear();
                    Log.ErrorFormat("Cannot Get All Status", ex);
                    throw new DALException("Cannot GetAllStatus", ex);
                }
        }
    }
}
