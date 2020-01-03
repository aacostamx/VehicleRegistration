using Inkript.VR.Business.DataAccessLayer;
using Inkript.VR.Models;
using System.Collections.Generic;
using System.Linq;

namespace Inkript.VR.Business.BusinessLayer
{
    public class FileInfoCustomsBLO
    {
        #region Variables
        private FileInfoCustomsDAO _da { get; set; }
        #endregion

        #region Methods
        public FileInfoCustomsBLO()
        {
            _da = new FileInfoCustomsDAO();
        }

        public List<FileInfoCustoms> GetAll()
        {
            return _da.GetAll().ToList();
        }

        public FileInfoCustoms GetByFileInfoCustomsId(int FileInfoCustomsId)
        {
            return _da.GetByFileInfoCustomsId(FileInfoCustomsId);
        }

        public List<FileInfoCustoms> GetByFileInfoCustomsName(string name)
        {
            return _da.GetByFileInfoCustomsName(name).ToList();
        }

        public void UpdateFileInfoCustoms(FileInfoCustoms FileInfoCustoms)
        {
            _da.UpdateFileInfoCustoms(FileInfoCustoms);
        }

        public bool FileInfoCustomsExist(int FileInfoCustomsId)
        {
            return _da.FileInfoCustomsExist(FileInfoCustomsId);
        }

        public bool FileInfoCustomsNameExist(string name)
        {
            return _da.FileInfoCustomsNameExist(name);
        }

        public FileInfoCustoms CreateFileInfoCustoms(FileInfoCustoms FileInfoCustoms)
        {
            return _da.CreateFileInfoCustoms(FileInfoCustoms);
        }

        public GenericPagedList<FileInfoCustoms> GetAllFileInfoCustomsPaged(int pageNumber, int pageSize)
        {
            return _da.GetAllPaged(pageNumber, pageSize);
        }

        public bool DeleteFileInfoCustoms(int FileInfoCustomsId)
        {
            return _da.DeleteFileInfoCustoms(FileInfoCustomsId);
        }

        public FileInfoCustoms CheckDuplicateCertifications(FileInfoCustoms FileInfoCustoms)
        {
            return _da.CheckDuplicateCertifications(FileInfoCustoms);
        }

        public bool ValidImportCustomType(FileInfoCustoms FileInfoCustoms)
        {
            bool valid = false;

            if (FileInfoCustoms.ImportCustoms != null && FileInfoCustoms.ImportCustoms.Count != 0)
            {
                foreach (var item in FileInfoCustoms.ImportCustoms)
                {
                    if (item.OperationType == "NEW" || item.OperationType == "MODIFY")
                    {
                        return true;
                    }
                }
            }

            return valid;
        }
        #endregion
    }
}
