using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using BAL;
using System.Text;
using System.IO;
using System.Data;
using Newtonsoft.Json;
using DAL;

namespace EesassinErp.Controllers
{
    public class DashboardController : Controller
    {
        #region Akhand

        public ActionResult unit()
        {
            return View();
        }
        public ActionResult employee()
        {
            return View();
        }
        public ActionResult communication()
        {
            return View();
        }
        public ActionResult documentsMaster()
        {
            return View();
        }
        public ActionResult unitdocuments()
        {
            return View();
        }
        public ActionResult unitdocumentsDetails()
        {
            return View();
        }
        public ActionResult viewunitdocuments()
        {
            return View();
        }
        #endregion
        // GET: Dashboard
        public ActionResult Dashboard()
        {
            return View();
        }
        public ActionResult AuditorComplianceReport()
        {
            return View();
        }
        public ActionResult PrintComplianceReport()
        {
            return View();
        }


        public ActionResult AdminDashBoard()
        {
            return View();
        }
        public ActionResult VendorDashBoard()
        {

            return View();
        }
        public ActionResult AuditorDashBoard()
        {

            return View();
        }
        public ActionResult ClientDashBoard()
        {

            return View();
        }
        public async Task<string> NavMenuList(Module obj)
        {
            string result = await Task.Factory.StartNew(() => JsonConvert.SerializeObject(DLL.dll.NavMenuList(obj)));
            return result;
        }

        public ActionResult BranchMenuPermission()
        {
            return View();
        }

        public async Task<string> ModuleList(Module obj)
        {
            string result = await Task.Factory.StartNew(() => JsonConvert.SerializeObject(DLL.dll.ModuleList(obj)));
            return result;
        }
 
        public async Task<string> SubMenuList(Module obj)
        {
            string result = await Task.Factory.StartNew(() => JsonConvert.SerializeObject(DLL.dll.SubMenuList(obj)));
            return result;
        }

        public async Task<string> InsertMenuPermission(MenuPermission obj)
        {
            string result = await Task.Factory.StartNew(() => JsonConvert.SerializeObject(DLL.dll.MenuPermission(obj)));
            return result;
        }



        public async Task<string> InsertBranchMenuPermission(MenuPermission obj)
        {
            string result = await Task.Factory.StartNew(() => JsonConvert.SerializeObject(DLL.dll.BranchMenuPermission(obj)));
            return result;
        }

        public async Task<string> SearchBranchMenuPermission(BranchAuthorization obj)
        {
            string result = await Task.Factory.StartNew(() => JsonConvert.SerializeObject(DLL.dll.SearchBranchMenuPermission(obj)));
            return result;
        }

         

        public async Task<string> InsertSectionPermissionForRole(RolePermission obj)
        {
            string result = await Task.Factory.StartNew(() => JsonConvert.SerializeObject(DLL.dll.InsertSectionPermissionForRole(obj)));
            return result;
        }


 


        public ActionResult CompanyBranchUserAssignment()
        {
            return View();
        }

        public ActionResult NavMenuPermission()
        {
            return View();
        }
        public ActionResult LoginPermission()
        {
            return View();
        }
        public async Task<string> GetCompanyAndBranchMaster(BCommon obj)
        {
            string result = await Task.Factory.StartNew(() => JsonConvert.SerializeObject(DLL.dll.GetCompanyAndBranchMaster(obj)));
            return result;
        }

        public async Task<string> InsertUpdateDeleteCompanyBranchUserPermission(BCommon obj)
        {
            string result = await Task.Factory.StartNew(() => JsonConvert.SerializeObject(DLL.dll.InsertUpdateDeleteCompanyBranchUserPermission(obj)));
            return result;
        }
        public async Task<string> SearchMenuPermission(BranchAuthorization obj)
        {
            string result = await Task.Factory.StartNew(() => JsonConvert.SerializeObject(DLL.dll.SearchMenuPermission(obj)));
            return result;
        }
        public async Task<string> UpdateAllMembers(BranchAuthorization obj)
        {
            string result = await Task.Factory.StartNew(() => JsonConvert.SerializeObject(DLL.dll.UpdateAllMembers(obj)));
            return result;
        }
        public async Task<string> SeprateUpdateMembers(BranchAuthorization obj)
        {
            string result = await Task.Factory.StartNew(() => JsonConvert.SerializeObject(DLL.dll.SeprateUpdateMembers(obj)));
            return result;
        }
        public async Task<string> GetLoginMemberDetails(BranchAuthorization obj)
        {
            string result = await Task.Factory.StartNew(() => JsonConvert.SerializeObject(DLL.dll.GetLoginMemberDetails(obj)));
            return result;
        }
        public ActionResult ReportHeader()
        {
            return View();
        }
        public async Task<string> InsertUpdateDeleteReportHeader(BranchAuthorization obj)
        {
            string result = await Task.Factory.StartNew(() => JsonConvert.SerializeObject(DLL.dll.InsertUpdateDeleteReportHeader(obj)));
            return result;
        }
        public async Task<string> GetReportHeader(BCommon obj)
        {
            string result = await Task.Factory.StartNew(() => JsonConvert.SerializeObject(DLL.dll.GetReportHeader(obj)));
            return result;
        }

        #region  
        public ActionResult UserRegistration()
        {
            return View();
        }

        public async Task<string> GetUserRegistration(BCommon obj)
        {
            string result = await Task.Factory.StartNew(() => JsonConvert.SerializeObject(DAL.DLL.dll.GetUserRegistration(obj)));
            return result;
        }


        public async Task<string> IUDUserRegistration(BCommon obj)
        {
            string result = await Task.Factory.StartNew(() => JsonConvert.SerializeObject(DAL.DLL.dll.IUDUserRegistration(obj)));
            return result;
        }

        #endregion


        #region  RoleMenu Permission
        public ActionResult RoleMenuPermission()
        {
            return View();
        }


        public async Task<string> RoleList(Module obj)
        {
            string result = await Task.Factory.StartNew(() => JsonConvert.SerializeObject(DLL.dll.RoleList(obj)));
            return result;
        }

        public async Task<string> PagesSectionMasterList(Module obj)
        {
            string result = await Task.Factory.StartNew(() => JsonConvert.SerializeObject(DLL.dll.PagesSectionMasterList(obj)));
            return result;
        }

        public async Task<string> SearchSectionandRoleMenuPermission(BranchAuthorization obj)
        {
            string result = await Task.Factory.StartNew(() => JsonConvert.SerializeObject(DLL.dll.SearchSectionandRoleMenuPermission(obj)));
            return result;
        }
        #endregion
        

        
    }
}