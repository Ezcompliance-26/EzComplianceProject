using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BAL;
using DAL;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace EesassinErp.Controllers
{
    public class ReportController : Controller
    {
        // GET: Report
        public ActionResult VendorReport()
        {
            return View();
        }
        public async Task<string> SearchReport(TblPartyMaster obj)
        {
            string result = await Task.Factory.StartNew(() => JsonConvert.SerializeObject(DLL.dll.SearchReport(obj)));
            return result;
        }
        public ActionResult RegisteredPartyMaster()
        {
            return View();
        }
        public ActionResult TransportReport()
        {
            return View();
        }
        public ActionResult BranchReport()
        {
            return View();
        }
        public ActionResult EmployeeReport()
        {
            return View();
        }
        public ActionResult CashBook()
        {
            return View();
        }
        public ActionResult SuperVisiorAttendance()
        {
            return View();
        }
        public ActionResult PurchaseReport()
        {
            return View();
        }
        
    }
}