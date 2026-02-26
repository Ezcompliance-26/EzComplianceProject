using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using BAL;
using System.Text;
using System.IO;
using System.Data;
using Newtonsoft.Json;
using DAL;
using System.Drawing;
using System.Drawing.Text;
using System.Drawing.Drawing2D;  
using System;

namespace EesassinErp.Controllers
{
    public class LoginApiController : ApiController
    {
        [HttpPost]
        public async Task<string> SendGeneralSMS(SMSBAL obj)
        {

            string result = await Task.Factory.StartNew(() => JsonConvert.SerializeObject(DLL.dll.SendGeneralSMS(obj)));
            return result;
        }
        [HttpPost]
        public async Task<string> GetUserId(LoginBAL obj)
        {
            string result = await Task.Factory.StartNew(() => JsonConvert.SerializeObject(DLL.dll.LoginVerify(obj)));
            return result; 
        }
        [HttpPost]
        public async Task<string> chkUserId(LoginBAL obj)
        { 
                string result = await Task.Factory.StartNew(() => JsonConvert.SerializeObject(DLL.dll.LoginVerify(obj)));
                return result;
            
        }
        [HttpPost]
        public async Task<string> UrlAccessPermission(BCommon obj)
        {
            string result = await Task.Factory.StartNew(() => JsonConvert.SerializeObject(DLL.dll.GetUrlAccessPermission(obj))); 
            return result;
        }
    }
}