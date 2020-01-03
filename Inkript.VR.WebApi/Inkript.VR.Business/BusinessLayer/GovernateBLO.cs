using Inkript.VR.Business.DataAccessLayer;
using Inkript.VR.Models;
using System.Collections.Generic;
using System.Linq;

namespace Inkript.VR.Business.BusinessLayer
{
    public class GovernateBLO
    {
        public GovernateDAO _da { get; set; }

        public GovernateBLO()
        {
            _da = new GovernateDAO();
        }

        public List<Governate> GetAllGovernates()
        {
            return _da.GetAll().ToList();
        }

        public Governate GetByGovernateId(int gobernateId)
        {
            return _da.GetById(gobernateId);
        }
    }
}
