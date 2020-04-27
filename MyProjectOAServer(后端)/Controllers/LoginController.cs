using MyProjectOAServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MyProjectOAServer.Controllers
{
    public class LoginController : Controller
    {
        // GET: Home
        public JsonResult Verification(string Account,string Password)
        {
            ProjectDatabase ctx = new ProjectDatabase();
            var zh = ctx.usertable.FirstOrDefault(s => Account == s.Account_number);
            var pw = ctx.usertable.FirstOrDefault(s => Password == s.Password);
            if (zh != null && pw != null)
            {
                FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, Account, DateTime.Now, DateTime.Now.Add(FormsAuthentication.Timeout), true, "管理员");
                var SecreStr = FormsAuthentication.Encrypt(ticket);
                Response.Cookies.Add(new HttpCookie(FormsAuthentication.FormsCookieName)
                {
                    HttpOnly = true,
                    Path = FormsAuthentication.FormsCookiePath,
                    Expires = DateTime.Now.Add(FormsAuthentication.Timeout),
                    Value = SecreStr
                });
                return Json(new
                {
                    success = true,
                    message = "登录成功"
                }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new
                {
                    success = false,
                    message = "登录失败"
                }, JsonRequestBehavior.AllowGet);
            }
        }//登录界面登录验证接口
    }
}





