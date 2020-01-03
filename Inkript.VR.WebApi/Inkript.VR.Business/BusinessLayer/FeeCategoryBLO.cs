using Inkript.VR.Business.DataAccessLayer;
using Inkript.VR.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Inkript.VR.Business.BusinessLayer
{
    public class FeeCategoryBLO
    {
        private FeeCategoryDAO _da { get; set; }

        public FeeCategoryBLO()
        {
            _da = new FeeCategoryDAO();
        }

        public List<FeeCategory> GetAllFeeCategories()
        {
            return _da.GetAll().ToList();
        }

        public bool FeeCategoryExist(int feeCategoryId)
        {
            return _da.Exist(feeCategoryId);
        }

        public FeeCategory GetFeecategory(int feeCategoryId)
        {
            return _da.GetById(feeCategoryId);
        }
    }
}
