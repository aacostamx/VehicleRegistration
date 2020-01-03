using Inkript.Logging;
using Inkript.VR.Business.Helpers;
using Inkript.VR.Models;
using NHibernate;
using NHibernate.Criterion;
using NHibernate.Linq;
using System;
using System.Linq;

namespace Inkript.VR.Business.DataAccessLayer
{
    public class ServerMessagesDAO : GenericDAO<ServerMessages>
    {
        public ServerMessages GetByCode(string code)
        {
            using (ISession session = NHibernateHelper.OpenSession())
                try
                {
                    return session.CreateCriteria<ServerMessages>()
                        .Add(Restrictions.Eq("Code", code))
                        .UniqueResult<ServerMessages>();
                }
                catch (Exception ex)
                {
                    session.Clear();
                    Log.ErrorFormat("Cannot Get Server Message by Code {0}", code, ex);
                    throw new DALException("Cannot Get By Code.", ex);
                }
        }

        public void CreateServerMessage(ServerMessages serverMessages)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            using (ITransaction transaction = session.BeginTransaction())
            {
                try
                {
                    session.Save(serverMessages);                    
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    session.Clear();
                    Log.ErrorFormat("Cannot Create Server Message", ex);
                    throw new DALException("Cannot Create Server Message Object", ex);
                }
            }
        }

        public void CreateOrUpdateServerMessage(ServerMessages serverMessages)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            using (ITransaction transaction = session.BeginTransaction())
            {
                try
                {
                    if (session.Query<ServerMessages>().Any(x => x.Code == serverMessages.Code))
                    {
                        ServerMessages serverMessageEntity = session.Query<ServerMessages>()
                            .Where(c => c.Code == serverMessages.Code)
                            .FirstOrDefault();

                        serverMessageEntity.Code = serverMessages.Code;
                        serverMessageEntity.Type = serverMessages.Type;
                        serverMessageEntity.Arabic = serverMessages.Arabic;
                        serverMessageEntity.English = serverMessages.English;

                        session.Update(serverMessageEntity);
                    }
                    else
                        session.Save(serverMessages);
                  
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    session.Clear();
                    Log.ErrorFormat("Cannot Create Or Update Server Message", ex);
                    throw new DALException("Cannot Create Or Update Server Message Object", ex);
                }
            }
        }

        public void DeleteServerMessage(int serverMessageId)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            using (ITransaction transaction = session.BeginTransaction())
            {
                try
                {
                    ServerMessages serverMessage = session.Query<ServerMessages>()
                        .Where(c => c.ServerMessagesId == serverMessageId)
                        .FirstOrDefault();

                    session.Delete(serverMessage);
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    session.Clear();
                    Log.ErrorFormat("Cannot Delete Server Message Id {0}", serverMessageId, ex);
                    throw new DALException("Cannot Delete Server Message Object", ex);
                }
            }
        }

        public bool MessageIdExist(int serverMessageId)
        {
            using (ISession session = NHibernateHelper.OpenSession())
                try
                {
                    return session.Query<ServerMessages>().Any(c => c.ServerMessagesId == serverMessageId);
                }
                catch (Exception ex)
                {
                    session.Clear();
                    Log.ErrorFormat("Cannot Check If Exist Server Message Id {0}", serverMessageId, ex);
                    throw new DALException("Cannot Message Id Exist", ex);
                }
        }

        public bool MessageCodeExist(string code)
        {
            using (ISession session = NHibernateHelper.OpenSession())
                try
                {
                    return session.Query<ServerMessages>().Any(c => c.Code == code);
                }
                catch (Exception ex)
                {
                    session.Clear();
                    Log.ErrorFormat("Cannot Check If Exist Server Message Code {0}", code, ex);
                    throw new DALException("Cannot Message Code Exist", ex);
                }
        }
    }
}
