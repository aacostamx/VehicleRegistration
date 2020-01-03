using System.Linq;
using Inkript.VR.Models;
using System.Collections.Generic;
using Inkript.VR.Business.DataAccessLayer;

namespace Inkript.VR.Business.BusinessLayer
{
    public class ModelBLO
    {
        #region Variables
        private ModelDAO _da { get; set; }
        #endregion

        #region Methods
        public ModelBLO()
        {
            _da = new ModelDAO();
        }

        public void CreateModel(Model entity)
        {
            _da.SaveOrUpdate(entity, string.Empty);
        }

        public bool ModelNameExist(string modelName)
        {
            return _da.ModelNameExist(modelName);
        }

        public List<Model> GetAllModel()
        {
            return _da.GetAll().ToList();
        }

        public bool ModelExist(int id)
        {
            return _da.Exist(id);
        }

        public Model GetModel(int id)
        {
            return _da.GetById(id);
        }

        public void UpdateModel(Model entity)
        {
            _da.SaveOrUpdate(entity, string.Empty);
        }

        public bool DeleteModel(int id)
        {
            return _da.Delete(GetModel(id));
        }
        #endregion
    }
}
