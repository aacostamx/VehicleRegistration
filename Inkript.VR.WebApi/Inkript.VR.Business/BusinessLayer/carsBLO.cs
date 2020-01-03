using Inkript.VR.Business.DataAccessLayer;
using Inkript.VR.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Inkript.VR.Business.BusinessLayer
{
    public class CarsBLO
    {
        public Cars GetById(int Id)
        {
            return new CarsDAO().GetById(Id);
        }
        public List<Cars> GetActiveCars()
        {
            return new CarsDAO().GetAll().Where(x => x.Status).ToList<Cars>();
        }

        public GenericPagedList<Cars> GetAllCarsPaged(int pageNumber, int pageSize)
        {
            return new CarsDAO().GetAllPaged(pageNumber, pageSize);
        }
    }
}
