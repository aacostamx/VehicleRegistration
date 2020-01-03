using System;
using System.Collections.Generic;
using System.Linq;
using Inkript.Logging;
using Inkript.VR.Business.Helpers;
using Inkript.VR.Models;
using NHibernate;
using NHibernate.Linq;

namespace Inkript.VR.Business.DataAccessLayer
{
    public class DocumentGroupsDAO : GenericDAO<DocumentGroups>
    {
        public IList<DocumentGroups> GetDocumentGroups(List<DocumentCustom> inputDocuments)
        {
            List<Documents> documents = new List<Documents>();
            List<DocumentGroups> result = new List<DocumentGroups>();

            using (ISession session = NHibernateHelper.OpenSession())
                try
                {
                    if (inputDocuments != null && inputDocuments.Count > 0)
                    {
                        foreach (var item in inputDocuments)
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
                                        && !documents.Any(c => c.DocumentId == document.DocumentId))
                                    {
                                        document.Mandatory = rel.Mandatory;
                                        documents.Add(document);
                                    }
                                }
                            }
                        }
                    }

                    if (documents != null && documents.Count > 1)
                    {
                        documents = documents.OrderBy(c => c.DocumentId).ToList();
                    }

                    if (documents != null && documents.Count > 0)
                    {
                        foreach (var doc in documents)
                        {
                            if (doc.GroupId.HasValue)
                            {
                                if (result.Any(c => c.GroupId == doc.GroupId))
                                {
                                    DocumentGroups documentGroup = result.Where(c => c.GroupId == doc.GroupId).FirstOrDefault();
                                    documentGroup.Documents.Add(doc);
                                }
                                else
                                {
                                    DocumentGroups documentGroup = session.Query<DocumentGroups>()
                                        .Where(c => c.GroupId == doc.GroupId)
                                        .FirstOrDefault();
                                    documentGroup.Documents = new List<Documents> { doc };
                                    result.Add(documentGroup);
                                }
                            }
                            else
                            {
                                if (result.Any(c => c.GroupId == 0))
                                {
                                    DocumentGroups documentGroup = result.Where(c => c.GroupId == 0).FirstOrDefault();
                                    documentGroup.Documents.Add(doc);
                                }
                                else
                                {
                                    DocumentGroups documentGroup = new DocumentGroups { GroupId = 0, GroupName = "Ungroup" };
                                    documentGroup.Documents.Add(doc);
                                    result.Add(documentGroup);
                                }
                            }
                        }
                    }

                    if (result != null && result.Count > 1)
                    {
                        result = result.OrderBy(c => c.GroupId).ToList();
                    }

                    return result;
                }
                catch (Exception ex)
                {
                    session.Clear();
                    Log.ErrorFormat("Cannot Get Document Groups by List of parameters", ex);
                    throw new DALException("Cannot GetDocumentGroups", ex);
                }
        }
    }
}
