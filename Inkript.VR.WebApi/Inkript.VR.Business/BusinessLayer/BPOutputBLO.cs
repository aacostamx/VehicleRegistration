using System;
using System.Collections.Generic;
using Inkript.VR.Business.DataAccessLayer;
using Inkript.VR.Models;

namespace Inkript.VR.Business.BusinessLayer
{
    public class BPOutputBLO
    {
        private BPOutputDAO _da { get; set; }

        public BPOutputBLO()
        {
            _da = new BPOutputDAO();
        }
    }
}
