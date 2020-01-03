using Inkript.VR.Business.DataAccessLayer;
using Inkript.VR.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Inkript.VR.Business.BusinessLayer
{
    public class StatusBLO
    {
        private StatusDAO _da { get; set; }

        public StatusBLO()
        {
            _da = new StatusDAO();
        }

        public List<Status> GetAllStatus()
        {
            return _da.GetAll().ToList();
        }

        public bool StatusExist(int statusId)
        {
            return _da.Exist(statusId);
        }

        public Status GetStatus(int statusId)
        {
            return _da.GetById(statusId);
        }
    }
}
