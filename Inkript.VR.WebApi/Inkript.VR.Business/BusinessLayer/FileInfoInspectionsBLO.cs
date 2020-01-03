using Inkript.VR.Business.DataAccessLayer;
using Inkript.VR.Models;
using System;

namespace Inkript.VR.Business.BusinessLayer
{
    public class FileInfoInspectionsBLO
    {
        #region Variables
        private FileInfoInspectionsDAO _da { get; set; }
        #endregion

        #region Methods
        public FileInfoInspectionsBLO()
        {
            _da = new FileInfoInspectionsDAO();
        }

        public void CreateFileInfoInspections(FileInfoInspections fileInfoInspections)
        {
            _da.CreateFileInfoInspections(fileInfoInspections);
        }

        public GenericPagedList<FileInfoInspections> GetAllFileInspectionsPaged(int pageNumber, int pageSize)
        {
            return _da.GetAllPaged(pageNumber, pageSize);
        }

        public bool FileInspectionsExist(int fileInspectionsId)
        {
            return _da.FileInspectionsExist(fileInspectionsId);
        }

        public FileInfoInspections GetByFileInspectionsId(int fileInspectionsId)
        {
            return _da.GetById(fileInspectionsId);
        }

        public void DeleteFileInspections(int fileInspectionsId)
        {
            _da.DeleteFileInspections(fileInspectionsId);
        }

        public void CreateOrUpdateFileInfoInspections(FileInfoInspections fileInfoInspections)
        {
            _da.CreateOrUpdateFileInfoInspections(fileInfoInspections);
        }
        #endregion
    }
}
