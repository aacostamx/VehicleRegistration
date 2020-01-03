using Inkript.Logging;
using Inkript.VR.Business.Helpers;
using Inkript.VR.Models;
using NHibernate;
using NHibernate.Criterion;
using System;
using System.Collections.Generic;
using System.Reflection;
using Inkript.Json;

namespace Inkript.VR.Business.DataAccessLayer
{
    public abstract class GenericDAO<T>
    {
        #region Methods
        public virtual void AuditLog(string activityName, string description, int userId, string jsonObject = "", int activityStatus = 0)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            using (ITransaction transaction = session.BeginTransaction())
            {
                try
                {
                    string sql = @"EXEC AuditLogging '" + activityName + "', '" + description + "', '" 
                        + Enum.GetName(typeof(FlagStatusCode), activityStatus) + "', " + userId + ", '" 
                        + jsonObject + "'";
                    session.CreateSQLQuery(sql).ExecuteUpdate();
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    session.Clear();
                    Log.Error("Cannot Audit Log", ex);
                }
            }
        }

        public virtual T GetById(int Id)
        {
            using (ISession session = NHibernateHelper.OpenSession())
                try
                {
                    AuditLog(MethodBase.GetCurrentMethod().Name, typeof(T).Name, 0, JsonConvert.SerializeObject(Id));
                    return session.Get<T>(Id);
                }
                catch (Exception ex)
                {
                    session.Clear();
                    Log.ErrorFormat("Cannot Get By Id {0}", Id, ex);
                    AuditLog(MethodBase.GetCurrentMethod().Name, typeof(T).Name, 0, JsonConvert.SerializeObject(Id), 1);
                    throw new DALException("Cannot GetById.", ex);
                }
        }

        public virtual bool RecordExist(string tableName, string columnName, string recordValue)
        {
            bool recordExist = false;
            using (ISession session = NHibernateHelper.OpenSession())
                try
                {
                    string sql = @"select * from " + tableName + " where " + columnName + " = :recordValue";

                    var result = session.CreateSQLQuery(sql)
                        .SetString("recordValue", recordValue)
                        .UniqueResult();

                    if (result != null)
                        recordExist = true;
                }
                catch (Exception ex)
                {
                    session.Clear();
                    Log.ErrorFormat("Cannot check if Record exist", ex);
                    throw new DALException("Cannot RecordExist.", ex);
                }
            return recordExist;
        }

        public virtual bool Exist(int id)
        {
            bool exist = false;
            using (ISession session = NHibernateHelper.OpenSession())
                try
                {
                    if (session.Get<T>(id) != null)
                        exist = true;
                }
                catch (Exception ex)
                {
                    session.Clear();
                    Log.ErrorFormat("Cannot check if exist id {0}", id, ex);
                    throw new DALException("Cannot Exist.", ex);
                }

            return exist;
        }

        public virtual T GetById(Int64 Id)
        {
            using (ISession session = NHibernateHelper.OpenSession())
                try
                {
                    AuditLog(MethodBase.GetCurrentMethod().Name, typeof(T).Name, 0, JsonConvert.SerializeObject(Id));
                    return session.Get<T>(Id);
                }
                catch (Exception ex)
                {
                    session.Clear();
                    Log.ErrorFormat("Cannot Get By Id {0}", Id, ex);
                    AuditLog(MethodBase.GetCurrentMethod().Name, typeof(T).Name, 0, JsonConvert.SerializeObject(Id), 1);
                    throw new DALException("Cannot GetById Int64.", ex);
                }
        }

        public virtual IList<T> GetAll()
        {
            using (ISession session = NHibernateHelper.OpenSession())
                try
                {
                    AuditLog(MethodBase.GetCurrentMethod().Name, typeof(T).Name, 0);

                    ICriteria criteria = session.CreateCriteria(typeof(T));

                    IList<T> objectsList = new List<T>();
                    objectsList = criteria.List<T>() as List<T>;
                    if (objectsList == null)
                    {
                        objectsList = new List<T>();
                    }
                    return objectsList;
                }
                catch (Exception ex)
                {
                    session.Clear();
                    Log.ErrorFormat("Cannot Get All", ex);
                    AuditLog(MethodBase.GetCurrentMethod().Name, typeof(T).Name, 0, string.Empty, 1);
                    throw new DALException("Cannot GetAllObjects.", ex);
                }
        }

        public virtual GenericPagedList<T> GetAllPaged(int pageNumber, int pageSize)
        {
            using (ISession session = NHibernateHelper.OpenSession())
                try
                {
                    AuditLog(MethodBase.GetCurrentMethod().Name, typeof(T).Name, 0);

                    pageNumber = pageNumber == 0 ? 1 : pageNumber;

                    ICriteria criteria = session.CreateCriteria(typeof(T));
                    int totalRows = criteria.SetProjection(Projections.RowCount()).FutureValue<Int32>().Value;

                    ICriteria criteriaList = session.CreateCriteria(typeof(T));
                    IList<T> result = criteriaList.SetFirstResult(pageSize * (pageNumber - 1)).SetMaxResults(pageSize).List<T>();
                    return new GenericPagedList<T>(totalRows, result);
                }
                catch (Exception ex)
                {
                    session.Clear();
                    Log.Error("Cannot Get all paged", ex);
                    AuditLog(MethodBase.GetCurrentMethod().Name, typeof(T).Name, 0, string.Empty, 1);
                    throw new DALException("Cannot GetAllPaged", ex);
                }
        }

        public GenericPagedList<T> GetAllPagedWithSorting(int pageNumber, int pageSize, int number)
        {
            using (ISession session = NHibernateHelper.OpenSession())
                try
                {
                    AuditLog(MethodBase.GetCurrentMethod().Name, typeof(T).Name, 0);

                    pageNumber = pageNumber == 0 ? 1 : pageNumber;

                    ICriteria criteria = session.CreateCriteria(typeof(T));
                    int totalRows = criteria.SetProjection(Projections.RowCount()).FutureValue<Int32>().Value;

                    ICriteria criteriaList = session.CreateCriteria(typeof(T));
                    IList<T> result = new List<T>();

                    result = criteriaList.SetFirstResult(pageSize * (pageNumber - 1)).SetMaxResults(pageSize).List<T>();
                    return new GenericPagedList<T>(totalRows, result);
                }
                catch (Exception ex)
                {
                    session.Clear();
                    Log.Error("Cannot Get all paged with sorting", ex);
                    throw new DALException("Cannot GetAllPagedWithSorting.", ex);
                }
        }

        public virtual void SaveOrUpdate(T obj, string ipAddress)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            using (ITransaction transaction = session.BeginTransaction())
            {
                try
                {
                    AuditLog(MethodBase.GetCurrentMethod().Name, typeof(T).Name, 0, JsonConvert.SerializeObject(obj));
                    string objectTypeName = (obj).GetType().Name;
                    string daoName = this.GetType().Name;
                    session.SaveOrUpdate(obj);
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    session.Clear();
                    Log.Error("Cannot Save or Update", ex);
                    AuditLog(MethodBase.GetCurrentMethod().Name, typeof(T).Name, 0, JsonConvert.SerializeObject(obj), 1);
                    throw new DALException("Cannot SaveOrUpdate Object", ex);
                }
            }
        }

        public void Merge(T obj)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            using (ITransaction transaction = session.BeginTransaction())
            {
                try
                {
                    AuditLog(MethodBase.GetCurrentMethod().Name, typeof(T).Name, 0, JsonConvert.SerializeObject(obj));
                    session.Merge<Object>(obj);
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    session.Clear();
                    Log.Error("Cannot Merge", ex);
                    AuditLog(MethodBase.GetCurrentMethod().Name, typeof(T).Name, 0, JsonConvert.SerializeObject(obj), 1);
                    throw new DALException("Cannot SaveOrUpdate Object", ex);
                }
            }
        }

        public virtual void Delete(T obj, string iPAddress)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            using (ITransaction transaction = session.BeginTransaction())
            {
                try
                {
                    AuditLog(MethodBase.GetCurrentMethod().Name, typeof(T).Name, 0, JsonConvert.SerializeObject(obj));
                    session.Delete(obj);
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    session.Clear();
                    Log.Error("Cannot Delete", ex);
                    AuditLog(MethodBase.GetCurrentMethod().Name, typeof(T).Name, 0, JsonConvert.SerializeObject(obj), 1);
                    throw new DALException("Cannot Delete Object", ex);
                }
            }
        }

        public virtual bool Delete(T obj)
        {
            bool deleted = false;
            using (ISession session = NHibernateHelper.OpenSession())
            using (ITransaction transaction = session.BeginTransaction())
            {
                try
                {
                    AuditLog(MethodBase.GetCurrentMethod().Name, typeof(T).Name, 0, JsonConvert.SerializeObject(obj));
                    session.Delete(obj);
                    transaction.Commit();
                    deleted = true;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    session.Clear();
                    Log.Error("Cannot Delete", ex);
                    AuditLog(MethodBase.GetCurrentMethod().Name, typeof(T).Name, 0, JsonConvert.SerializeObject(obj), 1);
                    throw new DALException("Cannot Delete Object", ex);
                }
            }
            return deleted;
        }
        #endregion
    }
}
