using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using BAL;
using DAL;
using System.Threading.Tasks;
using Newtonsoft.Json; 

namespace EesassinErp.Controllers
{
    public class ReportApiController : ApiController
    {
        [HttpPost]
        public async Task<string> SearchReport(TblPartyMaster obj)
        {
            string result = await Task.Factory.StartNew(() => JsonConvert.SerializeObject(DLL.dll.SearchReport(obj)));
            return result;
        } 
    }
}