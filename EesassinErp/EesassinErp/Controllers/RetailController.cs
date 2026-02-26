using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BAL;
using DAL;
using System.Threading.Tasks;
using Newtonsoft.Json;
using EesassinErp.BAL;

namespace EesassinErp.Controllers
{
    public class RetailController : Controller
    {
        public ActionResult Retail()
        {
            return View();
        }

        public ActionResult ModuleRegMaster()
        {
            return View();
        }
        public ActionResult ModuleMappingMaster()
        {
            return View();
        }
        public async Task<string> GetSearchModuleReg(TblModuleRegMaster obj)
        {
            string result = await Task.Factory.StartNew(() => JsonConvert.SerializeObject(DAL.DLL.GetSearchModuleReg(obj)));
            return result;
        }
        public async Task<string> SearchRetailAssignExecuter(TblPartyMaster obj)
        {
            string result = await Task.Factory.StartNew(() => JsonConvert.SerializeObject(DAL.DLL.SearchRetailAssignExecuter(obj)));
            return result;
        }
        public async Task<string> IUDRetailAssignExecuter(TblPartyMaster obj)
        {
            string result = await Task.Factory.StartNew(() => JsonConvert.SerializeObject(DAL.DLL.IUDRetailAssignExecuter(obj)));
            return result;
        }
        

        public async Task<string> InsertUpdateDelModuleReg(TblModuleRegMaster obj)
        {
            string result = await Task.Factory.StartNew(() => JsonConvert.SerializeObject(DAL.DLL.InsertUpdateDelModuleRegMaster(obj)));
            return result;
        }

        public async Task<string> GetSearchModuleMappingMaster(TblModuleMappingMaster obj)
        {
            string result = await Task.Factory.StartNew(() => JsonConvert.SerializeObject(DAL.DLL.GetSearchModuleMappingMaster(obj)));
            return result;
        }


        public async Task<string> InsertUpdateDelMappingMaster(TblModuleMappingMaster obj)
        {
            string result = await Task.Factory.StartNew(() => JsonConvert.SerializeObject(DAL.DLL.InsertUpdateDelModuleMappingMaster(obj)));
            return result;
        }


        public ActionResult RoleMaster()
        {
            return View();
        }
        public async Task<string> SearchRoleMaster(TblPartyMaster obj)
        {
            string result = await Task.Factory.StartNew(() => JsonConvert.SerializeObject(DAL.DLL.SearchRoleMaster(obj)));
            return result;
        }


        public async Task<string> InsertUpdateDelRoleMaster(TblPartyMaster obj)
        {
            string result = await Task.Factory.StartNew(() => JsonConvert.SerializeObject(DAL.DLL.InsertUpdateDelRoleMaster(obj)));
            return result;
        }


        public ActionResult GradeMaster()
        {
            return View();
        }

        public async Task<string> SearchGradeMaster(TblPartyMaster obj)
        {
            string result = await Task.Factory.StartNew(() => JsonConvert.SerializeObject(DAL.DLL.SearchGradeMaster(obj)));
            return result;
        }
        public async Task<string> InsertUpdateDelGradeMaster(TblPartyMaster obj)
        {
            string result = await Task.Factory.StartNew(() => JsonConvert.SerializeObject(DAL.DLL.InsertUpdateDelGradeMaster(obj)));
            return result;
        }

        public ActionResult LicenseMaster()
        {
            return View();
        }


        public async Task<string> GetLicenseMasterDocumentList()
        {
            string result = await Task.Factory.StartNew(() => JsonConvert.SerializeObject(DAL.DLL.GetLicenseMasterDocumentList()));
            return result;
        }

        public async Task<string> InsertUpdateDelLicenseDocumentMaster(RetailLicenseDocuementMaster obj)
        {
            string result = await Task.Factory.StartNew(() => JsonConvert.SerializeObject(DAL.DLL.InsertUpdateDelLicenseMasterDocumentList(obj)));
            return result;
        }

        public async Task<string> SearchLicenseDocumentMaster(TblPartyMaster obj)
        {
            string result = await Task.Factory.StartNew(() => JsonConvert.SerializeObject(DAL.DLL.SearchLicenseDocumentMaster(obj)));
            return result;
        }


        public ActionResult StoreMapping()
        {
            return View();
        }

        public async Task<string> GetStore(RetialStoreManager obj)
        {
            string result = await Task.Factory.StartNew(() => JsonConvert.SerializeObject(DAL.DLL.GetStore(obj)));
            return result;
        }

        public async Task<string> InsertUpdateDelStoreMapping(RetailLicenseDocuementMaster obj)
        {
            string result = await Task.Factory.StartNew(() => JsonConvert.SerializeObject(DAL.DLL.InsertUpdateDelStoreMapping(obj)));
            return result;
        }


        public async Task<string> SearchStoreMapping(TblPartyMaster obj)
        {
            string result = await Task.Factory.StartNew(() => JsonConvert.SerializeObject(DAL.DLL.SearchStoreMapping(obj)));
            return result;
        }


 

        public ActionResult StorePrefix()
        {
            return View();
        }

        public async Task<string> InsertUpdateDelStorePrefix(StorePrefix obj)
        {
            string result = await Task.Factory.StartNew(() => JsonConvert.SerializeObject(DAL.DLL.InsertUpdateDelStorePrefix(obj)));
            return result;
        }
        public async Task<string> DelStorePrefix(StorePrefix obj)
        {
            string result = await Task.Factory.StartNew(() => JsonConvert.SerializeObject(DAL.DLL.DelStorePrefix(obj)));
            return result;
        }
        
        public async Task<string> SearchStorePrefix(StorePrefix obj)
        {
            string result = await Task.Factory.StartNew(() => JsonConvert.SerializeObject(DAL.DLL.SearchStorePrefix(obj)));
            return result;
        }
        #region Store compliance Department Master 
        public ActionResult DepartmentMaster()
       {
            return View();
        }
        public async Task<string> InsertUpdateDelDepartmentMaster(TblPartyMaster obj)
        {
            string result = await Task.Factory.StartNew(() => JsonConvert.SerializeObject(DAL.DLL.InsertUpdateDelDepartmentMaster(obj)));
            return result;
        }
        public async Task<string> SearchDepartmentMaster(TblPartyMaster obj)
        {
            string result = await Task.Factory.StartNew(() => JsonConvert.SerializeObject(DAL.DLL.SearchDepartmentMaster(obj)));
            return result;
        }

        #endregion
        #region StoreComplianceStatus Master 
        public ActionResult StoreComplianceStatusMaster()
        {
            return View();
        }
        public async Task<string> InsertUpdateDelStoreComplianceStatusMaster(TblPartyMaster obj)
        {
            string result = await Task.Factory.StartNew(() => JsonConvert.SerializeObject(DAL.DLL.InsertUpdateDelStoreComplianceStatusMaster(obj)));
            return result;
        }
        public async Task<string> SearchStoreComplianceStatusMaster(TblPartyMaster obj)
        {
            string result = await Task.Factory.StartNew(() => JsonConvert.SerializeObject(DAL.DLL.SearchStoreComplianceStatusMaster(obj)));
            return result;
        }

        #endregion
        #region Retail Department Master 
        public ActionResult RetailDocumentMaster()
        {
            return View();
        }
        public async Task<string> InsertUpdateDelRetailDocumentMaster(DocumentBAL obj)
        {
            string result = await Task.Factory.StartNew(() => JsonConvert.SerializeObject(DAL.DLL.InsertUpdateDelRetailDocumentMaster(obj)));
            return result;
        }
        public async Task<string> SearchRetailDocumentMaster(DocumentBAL obj)
        {
            string result = await Task.Factory.StartNew(() => JsonConvert.SerializeObject(DAL.DLL.SearchRetailDocumentMaster(obj)));
            return result;
        }

        #endregion
        
        #region Retail Department Master 
        public ActionResult RetailClientDocMapping()
        {
            return View();
        }
        public async Task<string> IUDRetailClientDocMapping(MenuPermission obj)
        {
            string result = await Task.Factory.StartNew(() => JsonConvert.SerializeObject(DAL.DLL.IUDRetailClientDocMapping(obj)));
            return result;
        }

        public async Task<string> SearchRetailClientDocMapping(MenuPermission obj)
        {
            string result = await Task.Factory.StartNew(() => JsonConvert.SerializeObject(DAL.DLL.SearchRetailClientDocMapping(obj)));
            return result;
        }

        #endregion
        #region Retail Create Executer 
        public ActionResult RetailCreateExecuter()
        {
            return View();
        }
        public async Task<string> IUDRetailCreateExecuter(TblPartyMaster obj)
        {
            string result = await Task.Factory.StartNew(() => JsonConvert.SerializeObject(DAL.DLL.IUDRetailCreateExecuter(obj)));
            return result;
        }

        public async Task<string> SearchRetailCreateExecuter(TblPartyMaster obj)
        {
            string result = await Task.Factory.StartNew(() => JsonConvert.SerializeObject(DAL.DLL.SearchRetailCreateExecuter(obj)));
            return result;
        }

        #endregion
        #region Retail Assign Executer 
        public ActionResult RetailAssignExecuter()
        {
            return View();
        }
        public async Task<string> IUDClientActMapping(MenuPermission obj)
        {
            string result = await Task.Factory.StartNew(() => JsonConvert.SerializeObject(DAL.DLL.IUDClientActMapping(obj)));
            return result;
        }

        public async Task<string> SearchClientActMapping(MenuPermission obj)
        {
            string result = await Task.Factory.StartNew(() => JsonConvert.SerializeObject(DAL.DLL.SearchClientActMapping(obj)));
            return result;
        }

        #endregion

       
    }
}