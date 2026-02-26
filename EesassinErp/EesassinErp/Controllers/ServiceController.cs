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
    public class ServiceController : Controller
    {
        public ActionResult DocumentMaster()
        {
            return View();
        }
        public ActionResult ServiceMaster()
        {
            return View();
        }

    }
}