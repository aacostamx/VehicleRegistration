using System;
using System.Collections.Generic;
using System.Linq;
using Inkript.VR.Business.DataAccessLayer;
using Inkript.VR.Models;

namespace Inkript.VR.Business.BusinessLayer
{
    public class ColorsBLO
    {
        private ColorsDAO _da { get; set; }

        public ColorsBLO()
        {
            _da = new ColorsDAO();
        }

        public List<Colors> GetAllColors()
        {
            return _da.GetAll().ToList();
        }
    }
}
