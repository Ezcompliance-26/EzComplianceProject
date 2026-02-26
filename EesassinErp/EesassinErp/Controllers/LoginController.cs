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
using System.Drawing;
using System.Drawing.Text;
using System.Drawing.Drawing2D;  
using System;

namespace EesassinErp.Controllers
{
    public class LoginController : Controller
    {
        public string CaptchaImage()
        {
            bool noisy = true;
            string base64;
            var rand = new Random((int)DateTime.Now.Ticks);
            //generate new question 
            int a = rand.Next(10, 99);
            int b = rand.Next(0, 9);
            var captcha = string.Format("{0} + {1} = ?", a, b);

            //store answer 
            Session["Captcha"] = a + b;

            //image stream 
            FileContentResult img = null;

            using (var mem = new MemoryStream())
            using (var bmp = new Bitmap(130, 30))
            using (var gfx = Graphics.FromImage((Image)bmp))
            {
                gfx.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
                gfx.SmoothingMode = SmoothingMode.AntiAlias;
                gfx.FillRectangle(Brushes.White, new Rectangle(0, 0, bmp.Width, bmp.Height));

                //add noise 
                if (noisy)
                {
                    int i, r, x, y;
                    var pen = new Pen(Color.Yellow);
                    for (i = 1; i < 10; i++)
                    {
                        pen.Color = Color.FromArgb(
                        (rand.Next(0, 255)),
                        (rand.Next(0, 255)),
                        (rand.Next(0, 255)));

                        r = rand.Next(0, (130 / 3));
                        x = rand.Next(0, 130);
                        y = rand.Next(0, 30);

                        gfx.DrawEllipse(pen, x - r, y - r, r, r);
                    }
                }

                //add question 
                gfx.DrawString(captcha, new Font("Tahoma", 15), Brushes.Gray, 2, 3);

                //render as Jpeg 
                bmp.Save(mem, System.Drawing.Imaging.ImageFormat.Jpeg);
                img = this.File(mem.GetBuffer(), "image/Jpeg");
                base64 = Convert.ToBase64String(mem.ToArray());
            }
            return "data:image/jpeg;base64," + base64;
        }
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }

        public ActionResult forget()
        {
            return View();
        }
        
      public async Task<string> SendGeneralSMS(SMSBAL obj)
        {

            string result = await Task.Factory.StartNew(() => JsonConvert.SerializeObject(DLL.dll.SendGeneralSMS(obj)));
            return result;
        }
        public async Task<string> GetUserId(LoginBAL obj)
        {
            if (Session["Captcha"] == null) return "0";
            if (obj.Captcha == Session["Captcha"].ToString())
            {
                string result = await Task.Factory.StartNew(() => JsonConvert.SerializeObject(DLL.dll.LoginVerify(obj)));
            return result;
            }
            else
            {
                return "89";
            }
        }
        public async Task<string> chkUserId(LoginBAL obj)
        { 
                string result = await Task.Factory.StartNew(() => JsonConvert.SerializeObject(DLL.dll.LoginVerify(obj)));
                return result;
            
        }
        public async Task<string> UrlAccessPermission(BCommon obj)
        {
            string result = await Task.Factory.StartNew(() => JsonConvert.SerializeObject(DLL.dll.GetUrlAccessPermission(obj))); 
            return result;
        }
        public async Task<string> GetModulePermission(BCommon obj)
        {
            string result = await Task.Factory.StartNew(() => JsonConvert.SerializeObject(DLL.dll.GetModulePermission(obj)));
            return result;
        }
        
    }
}