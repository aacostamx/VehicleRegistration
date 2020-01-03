using Inkript.VR.Models;
using NHibernate;
using NHibernate.Cfg;

namespace Inkript.VR.Business.Helpers
{
    public class NHibernateHelper
    {
        private static ISessionFactory _sessionFactory;

        private static ISessionFactory SessionFactory
        {
            get
            {
                if (_sessionFactory == null)
                {
                    var configuration = new NHibernate.Cfg.Configuration();

                    configuration.Configure();

                    configuration.AddAssembly(typeof(BusinessProcesses).Assembly);

                    _sessionFactory = configuration.BuildSessionFactory();
                }
                return _sessionFactory;
            }
        }

        public static ISession OpenSession()
        {
            return SessionFactory.OpenSession();
        }

        public static IStatelessSession OpenStateLessSession()
        {
            return SessionFactory.OpenStatelessSession();
        }

        public static ITransaction BeginTransaction(ISession session)
        {
            ITransaction transaction;

            try
            {
                transaction = session.BeginTransaction();

            }
            catch (TransactionException)
            {
                session.Connection.Open();
                transaction = session.BeginTransaction();

            }

            return transaction;
        }
    }
}
