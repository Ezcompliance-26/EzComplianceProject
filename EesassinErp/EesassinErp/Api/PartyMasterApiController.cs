using BAL;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
namespace EesassinErp.Controllers
{
    public class PartyMasterApiController : ApiController
    {
        [HttpPost]
        public async Task<string> GetPartyMasterDT(TblPartyMaster obj)
        {
            string result = await Task.Factory.StartNew(() => JsonConvert.SerializeObject(DAL.DLL.PartyMaster(obj)));
            return result;
        }

        [HttpPost]
        public async Task<string> InsertUpdateDelPartyMaster(TblPartyMaster obj)
        {
            string result = await Task.Factory.StartNew(() => JsonConvert.SerializeObject(DAL.DLL.InsertUpdateDelPartyMaster(obj)));
            return result;
        }


        [HttpPost]
        public async Task<string> GetSearchLocation(TblPartyMaster obj)
        {
            string result = await Task.Factory.StartNew(() => JsonConvert.SerializeObject(DAL.DLL.GetSearchLocation(obj)));
            return result;
        }

        [HttpPost]
        public async Task<string> InsertUpdateDelLocation(TblPartyMaster obj)
        {
            string result = await Task.Factory.StartNew(() => JsonConvert.SerializeObject(DAL.DLL.InsertUpdateDelLocation(obj)));
            return result;
        }
    }
}