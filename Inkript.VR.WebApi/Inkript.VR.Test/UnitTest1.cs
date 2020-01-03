using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Inkript.VR.Models;
using System.Collections;
using System.Collections.Generic;
using Inkript.VR.Business.DataAccessLayer;

namespace Inkript.VR.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void SaveFileInfoAndImportsInspection()
        {
          //  FileInfoInspections FileInfoInsp = new FileInfoInspections();
          //  FileInfoInsp.BranchName = "BankAudi";
          //  FileInfoInsp.FileType = "txt";
          //  FileInfoInsp.FromDate = new DateTime(2012, 1, 1);
          //  FileInfoInsp.ImportedDate = DateTime.Now;
          //  FileInfoInsp.ImportStatus = "Final";
          //  FileInfoInsp.TillDate = DateTime.Now;
          //  FileInfoInsp.Name = "File6";
          //  FileInfoInsp.NoRecords = 0;

          //  List<ImportInspections> ImportList = new List<ImportInspections>();
          //  ImportInspections Import1 = new ImportInspections();
          //  Import1.Certificate = "CE12535";
          //  Import1.ChassisNumber = "fdh323j_342d";
          //  Import1.Code =7;
          //  Import1.Date = DateTime.Now;
          ////Import1.FileInfoInspections = FileInfoInsp;
          //  Import1.PlateNumber = "784323D";
          //  Import1.RowNumber = 1;
          //  Import1.Result = "Pending";
          //  ImportList.Add(Import1);

          //  ImportInspections Import2 = new ImportInspections();
          //  Import2.Certificate = "CD#233";
          //  Import2.ChassisNumber = "19db23";
          //  Import2.Code = 7;
          //  Import2.Date = DateTime.Now;
          // // Import2.FileInfoInspections = FileInfoInsp;
          //  Import2.PlateNumber = "31111F";
          //  Import2.RowNumber = 1;
          //  Import2.Result = "Success";
          //  ImportList.Add(Import2);

          //  FileInfoInsp.ImportInspections = ImportList;

          //  FileInfoInspectionsDAO DAO = new FileInfoInspectionsDAO();
          //  DAO.CreateFileInfoInspections(FileInfoInsp);
        }
        [TestMethod]
        public void GetAndUpdateFileInfoInspection()
        {
            //FileInfoInspectionsDAO DAO = new FileInfoInspectionsDAO();
            //FileInfoInspections file = DAO.GetById(5);
            //DAO.Delete(file,string.Empty);
            //file.BranchName = "Bank BBAC";
            //file.ImportInspections[0].ChassisNumber = "Chasii12";
            //DAO.CreateOrUpdateFileInfoInspections(file);
            //Do not work if we are updating the name
            //The Generic SaveUpdate works perfectly . (It updates both entities)
            //DAO.CreateOrUpdateFileInfoInspections(file);
            //DAO.DeleteFileInspections(1);
            //ImportInspectionsDAO IDAO = new ImportInspectionsDAO();
            //ImportInspections insp = IDAO.GetById(10);
            //IDAO.DeleteImportInspections(10);

            // The file is not returned 
            //insp.Result = "Failed";
            //insp.FileInfoInspections.BranchName = "LibanPostUpdated";
            //IDAO.SaveOrUpdate(insp, string.Empty);
        }

        [TestMethod]
        public void SaveFileInfoCustom()
        {
//FileInfoDAO fileDAO = new FileInfoDAO();
//bool res = fileDAO.FileInfoExist(7);
          //  FileInfo info = new FileInfo();
          //  info.ImportedDate = DateTime.Now;
          //  info.ImportStatus = "Status";
          ////  info.MessageError = "Error Message";
          //  info.Name = "FileC3";
          //  info.NoRecords = 0;
          //  List<ImportCustoms> custom = new List<ImportCustoms>();
          //  ImportCustoms importCust = new ImportCustoms();
          //  importCust.Certification_Id ="00022";
          //  importCust.Chassis = "ABCDE_2";
          //  importCust.Color = 3;
          //  importCust.Color_Desc = "Red";
          //  importCust.Cylinders = 4;
          //  importCust.Date = DateTime.Now;
          //  importCust.Discounted = true;
          //  importCust.LastDateModified = DateTime.Now;
          //  importCust.LastModifyField = "whatever";
          //  importCust.Mark = "Mercedes";
          //  importCust.Mark_Desc = "Walla Mercedes";
          //  importCust.Model = 6;
          //  importCust.Motor = "34";
          //  importCust.Office = 4;
          //  importCust.Serie = "serie A";
          //  importCust.Taxes = 20000;
          //  importCust.Year = 2017;
          //  importCust.Value = 10000;

          //  ImportCustoms importCust2 = new ImportCustoms();
          //  importCust2.Certification_Id = "00023";
          //  importCust2.Chassis = "ABCDE_23";
          //  importCust2.Color = 3;
          //  importCust2.Color_Desc = "Rede";
          //  importCust2.Cylinders = 4;
          //  importCust2.Date = DateTime.Now;
          //  importCust2.Discounted = true;
          //  importCust2.LastDateModified = DateTime.Now;
          //  importCust2.LastModifyField = "whateveedr";
          //  importCust2.Mark = "Mercedes";
          //  importCust2.Mark_Desc = "BM";
          //  importCust2.Model = 63;
          //  importCust2.Motor = "34e";
          //  importCust2.Office = 4;
          //  importCust2.Serie = "serie AB";
          //  importCust2.Taxes = 200002;
          //  importCust2.Year = 2017;
          //  importCust2.Value = 100010;

          //  custom.Add(importCust2); 
          //  custom.Add(importCust);
          //  info.ImportCustoms = custom;
          //  FileInfoDAO fileDAO = new FileInfoDAO();
          //  fileDAO.CreateFileInfo(info);
          //  fileDAO.CreateOrUpdate(info);
          //  //fileDAO.SaveOrUpdate(info,string.Empty);
        }
    }
}
