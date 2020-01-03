using System;
using System.Collections.Generic;
using System.Linq;
using Inkript.Logging;
using Inkript.VR.Business.Helpers;
using Inkript.VR.Models;
using NHibernate;
using NHibernate.Linq;
using NHibernate.Transform;

namespace Inkript.VR.Business.DataAccessLayer
{
    public class PersonDAO : GenericDAO<Person>
    {
        public List<Person> GetPersonByIds(int id)
        {
            using (ISession session = NHibernateHelper.OpenSession())
                try
                {
                    return session.Query<Person>()
                        .Where(c => c.DrivingLicenseId == id || c.NationalId == id)
                        .ToList();
                }
                catch (Exception ex)
                {
                    session.Clear();
                    Log.ErrorFormat("Cannot Get Person by Id {0}", id, ex);
                    throw new DALException("Cannot GetPersonById", ex);
                }
        }

        public bool DrivingLicenseExist(int drivingLicenseId)
        {
            using (ISession session = NHibernateHelper.OpenSession())
                try
                {
                    return session.Query<Person>().Any(c => (c.DrivingLicenseId == drivingLicenseId));
                }
                catch (Exception ex)
                {
                    session.Clear();
                    Log.ErrorFormat("Cannot check if Driving License Exist {0}", drivingLicenseId, ex);
                    throw new DALException("Cannot DrivingLicenseExist", ex);
                }
        }

        public Person GetPersonByDrivingLicense(int drivingLicenseId)
        {
            using (ISession session = NHibernateHelper.OpenSession())
                try
                {
                    return session.Query<Person>()
                        .Where(c => c.DrivingLicenseId == drivingLicenseId)
                        .FirstOrDefault();
                }
                catch (Exception ex)
                {
                    session.Clear();
                    Log.ErrorFormat("Cannot Get Person by Driving License Id {0}", drivingLicenseId, ex);
                    throw new DALException("Cannot GetPersonByDrivingLicense", ex);
                }
        }

        public Person GetPersonByNationality(int nationalId)
        {
            using (ISession session = NHibernateHelper.OpenSession())
                try
                {
                    return session.Query<Person>()
                        .Where(c =>c.NationalId == nationalId)
                        .FirstOrDefault();
                }
                catch (Exception ex)
                {
                    session.Clear();
                    Log.ErrorFormat("Cannot Get Person by Nationality Id {0}", nationalId, ex);
                    throw new DALException("Cannot GetPersonByNationality", ex);
                }
        }

        public bool NationalityExist(int nationalId)
        {
            using (ISession session = NHibernateHelper.OpenSession())
                try
                {
                    return session.Query<Person>().Any(c => (c.NationalId == nationalId));
                }
                catch (Exception ex)
                {
                    session.Clear();
                    Log.ErrorFormat("Cannot check if Nationality Exist {0}", nationalId, ex);
                    throw new DALException("Cannot NationalityExist", ex);
                }
        }

        public IList<Person> PersonFilter(string search)
        {
            using (ISession session = NHibernateHelper.OpenSession())
                try
                {
                    return session.GetNamedQuery("PersonFilter")
                         .SetParameter("search", search)
                         .SetResultTransformer(Transformers.AliasToBean(typeof(Person)))
                         .List<Person>();
                }
                catch (Exception ex)
                {
                    session.Clear();
                    Log.ErrorFormat("Cannot Get Person Filter Search {0}", search, ex);
                    throw new DALException("Cannot FeesFilter", ex);
                }
        }
    }
}
