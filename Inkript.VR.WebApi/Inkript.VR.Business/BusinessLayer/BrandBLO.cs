using System;
using System.Linq;
using Inkript.VR.Models;
using System.Collections.Generic;
using Inkript.VR.Business.DataAccessLayer;

namespace Inkript.VR.Business.BusinessLayer
{
    public class BrandBLO
    {
        #region Variables
        private BrandDAO _da { get; set; }
        #endregion

        #region Methods
        public BrandBLO()
        {
            _da = new BrandDAO();
        }

        public void CreateBrand(Brand entity)
        {
            _da.SaveOrUpdate(entity, string.Empty);
        }

        public List<Brand> GetAllBrand()
        {
            return _da.GetAll().ToList();
        }

        public bool BrandExist(int id)
        {
            return _da.Exist(id);
        }

        public bool BrandNameEnExist(string brandNameEn)
        {
            return _da.RecordExist(nameof(Brand), nameof(Brand.BrandNameEN), brandNameEn);
           
        }

        public bool BrandNameArExist(string brandNameAr)
        {
            return _da.RecordExist(nameof(Brand), nameof(Brand.BrandNameAR), brandNameAr);
          
        }

        public Brand GetBrand(int id)
        {
            return _da.GetById(id);
        }

        public void UpdateBrand(Brand entity)
        {
            _da.SaveOrUpdate(entity, string.Empty);
        }

        public bool DeleteBrand(int id)
        {
            return _da.Delete(GetBrand(id));
        }
        #endregion
    }
}
