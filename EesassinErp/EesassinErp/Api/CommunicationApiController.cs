using BAL;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.IO;


namespace EesassinErp.Controllers
{
    public class CommunicationApiController : ApiController
    {
        [HttpPost]
        public async Task<string> GetCommunication(DocumentBAL obj)
        {
            string result = await Task.Factory.StartNew(() => JsonConvert.SerializeObject(DAL.DLL.dll.GetCommunication(obj)));
            return result;
        }

        [HttpPost]
        public async Task<string> IUDCommunication(DocumentBAL obj)
        {
            string result = await Task.Factory.StartNew(() => JsonConvert.SerializeObject(DAL.DLL.dll.IUDCommunication(obj)));
            return result;
        }
        [HttpPost]
        public async Task<string> DownloadFiles(TblVendorInvoiceBAL obj)
        {

            string result = await Task.Factory.StartNew(() => JsonConvert.SerializeObject(DAL.DLL.dll.DownloadFiles(obj)));
            return result;
        }
    }
}