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
    public class DocumentsDAO : GenericDAO<Documents>
    {
        public IList<Documents> GetDocuments(int BPId, int SectorId, int VehicleTypeId)
        {
            List<Documents> documents = new List<Documents>();

            using (ISession session = NHibernateHelper.OpenSession())
                try
                {
                    IList<DocumentProcessRelationship> documentProcessRelationships = session
                        .Query<DocumentProcessRelationship>()
                        .Where(c => c.BPId == BPId && c.SectorId == SectorId && c.VehicleTypeId == VehicleTypeId)
                        .ToList();

                    if (documentProcessRelationships != null && documentProcessRelationships.Count > 0)
                    {
                        foreach (var item in documentProcessRelationships)
                        {
                            Documents document = session.Query<Documents>()
                                .Where(c => c.DocumentId == item.DocumentId)
                                .Fetch(c => c.DocumentInput)
                                .SingleOrDefault();

                            documents.Add(document);
                        }
                    }

                    return documents;
                }
                catch (Exception ex)
                {
                    session.Clear();
                    Log.ErrorFormat("Cannot Get Documents by BPId {0}, SectorId {1}, VehicleTypeId {2}",
                        BPId, SectorId, VehicleTypeId, ex);
                    throw new DALException("Cannot GetDocuments", ex);
                }
        }

        public IList<Documents> GetDocuments(List<DocumentCustom> documents)
        {
            List<Documents> result = new List<Documents>();

            using (ISession session = NHibernateHelper.OpenSession())
                try
                {

                    if (documents != null && documents.Count > 0)
                    {
                        foreach (var item in documents)
                        {
                            IList<DocumentProcessRelationship> documentProcessRelationships = session.Query<DocumentProcessRelationship>()
                                .Where(c => c.BPId == item.BusinessProccessId && c.SectorId == item.SectorId && c.VehicleTypeId == item.VehicleTypeId)
                                .ToList();

                            if (documentProcessRelationships != null && documentProcessRelationships.Count > 0)
                            {
                                foreach (var rel in documentProcessRelationships)
                                {
                                    Documents document = session.Query<Documents>()
                                        .Where(c => c.DocumentId == rel.DocumentId)
                                        .FirstOrDefault();

                                    if (document != null
                                        && document.DocumentId > 0
                                        && !result.Any(c => c.DocumentId == document.DocumentId))
                                    {
                                        result.Add(document);
                                    }
                                }
                            }
                        }
                    }

                    if (result != null && result.Count > 1)
                    {
                        result = result.OrderBy(c => c.DocumentId).ToList();
                    }

                    return result;
                }
                catch (Exception ex)
                {
                    session.Clear();
                    Log.ErrorFormat("Cannot Get Documents by List of parameters", ex);
                    throw new DALException("Cannot GetDocuments", ex);
                }
        }

        public override IList<Documents> GetAll()
        {
            using (ISession session = NHibernateHelper.OpenSession())
                try
                {
                    return session.Query<Documents>()
                        .Fetch(c => c.DocumentInput)
                        .ToList();
                }
                catch (Exception ex)
                {
                    session.Clear();
                    Log.ErrorFormat("Cannot Get Documents", ex);
                    throw new DALException("Cannot GetDocuments", ex);
                }
        }

        public IList<Documents> GetBusinessProcessDocuments(int businessProcessId)
        {
            List<Documents> bpDocs = new List<Documents>();
            using (ISession session = NHibernateHelper.OpenSession())
                try
                {
                    List<DocumentProcessRelationship> documentProcessRelationships =
                        session.Query<DocumentProcessRelationship>()
                        .Where(p => p.BPId == businessProcessId)
                        .ToList();

                    if (documentProcessRelationships != null && documentProcessRelationships.Count > 0)
                    {
                        foreach (var item in documentProcessRelationships)
                        {
                            Documents document = session.Query<Documents>()
                                .Where(p => p.DocumentId == item.DocumentId)
                                .FirstOrDefault();

                            bpDocs.Add(document);
                        }
                    }

                    return bpDocs;
                }
                catch (Exception ex)
                {
                    session.Clear();
                    Log.ErrorFormat("Cannot Get Business Process Documents by businessProcessId {0}",
                        businessProcessId, ex);
                    throw new DALException("Cannot GetBusinessProcessDocuments", ex);
                }
        }
    }
}