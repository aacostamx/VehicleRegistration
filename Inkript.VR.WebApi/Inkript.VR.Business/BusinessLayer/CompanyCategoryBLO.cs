using System;
using System.Collections.Generic;
using System.Linq;
using Inkript.VR.Business.DataAccessLayer;
using Inkript.VR.Models;

namespace Inkript.VR.Business.BusinessLayer
{
    public class CompanyCategoryBLO
    {
        public CompanyCategoryDAO _da { get; set; }

        public CompanyCategoryBLO()
        {
            _da = new CompanyCategoryDAO();
        }

        public bool CompanyCategoryExist(int companyCategoryId)
        {
            return _da.Exist(companyCategoryId);
        }

        public List<CompanyCategory> GetAllCompanyCategories()
        {
            return _da.GetAll().ToList();
        }
    }
}
