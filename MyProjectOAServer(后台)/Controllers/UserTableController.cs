using MyProjectOAServer.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyProjectOAServer.Controllers
{
    public class UserTableController : Controller
    {
        // GET: UserTable

        public JsonResult Load()
        {
            ProjectDatabase ctx = new ProjectDatabase();
            return Json(new
            {
                success = true,
                message = "查询成功",
                RelateData = ctx.usertable.Select(s => new
                {
                    id = s.Id,
                    accountnumber = s.Account_number,
                    password = s.Password,
                    username = s.UserName,
                    userhead = s.User_head
                }).ToList()
            }, JsonRequestBehavior.AllowGet);
        }//用户表所有数据加载接口


        public JsonResult Search(int Id)
        {
            ProjectDatabase ctx = new ProjectDatabase();
            var you = ctx.usertable.FirstOrDefault(s => Id == s.Id);
            if (you != null)
            {
                var list = ctx.usertable.Where(s => Id == s.Id).ToList();
                return Json(new
                {
                    success = true,
                    message = "查询成功",
                    RelateData = list.Select(s => new
                    {
                        id = s.Id,
                        accountnumber = s.Account_number,
                        password = s.Password,
                        username = s.UserName,
                        userhead = s.User_head
                    }).ToList()
                }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new
                {
                    success = false,
                    message = "查询失败"
                }, JsonRequestBehavior.AllowGet);
            }
        }//用户表指定数据查询接口


        public class tempClass
        {

            public string Accountnumber { get; set; }
            public string Password { get; set; }
            public string Username { get; set; }
            public HttpPostedFileBase Userhead { get; set; }
        }


        public JsonResult Add(tempClass model)
        {
            // 设定保存位置和文件名

            var list = new List<string> { ".png", ".jpg" };
            if (list.Contains(Path.GetExtension(model.Userhead.FileName)) && model.Userhead.ContentLength < 1024 * 1024 * 4)
            {
                var path = "/upload/" + DateTime.Now.ToString("yyyyMMddHHmmssfff") + Path.GetExtension(model.Userhead.FileName);
                ProjectDatabase use = new ProjectDatabase();
                usertable ctx = new usertable();
                ctx.Account_number = model.Accountnumber;
                ctx.Password = model.Password;
                ctx.UserName = model.Username;
                ctx.User_head = path;
                use.usertable.Add(ctx);
                use.SaveChanges();
                model.Userhead.SaveAs(Server.MapPath(path));


                return Json(new
                {
                    success = true,
                    message = "添加成功"
                }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new
                {
                    success = false,
                    message = "添加失败"
                }, JsonRequestBehavior.AllowGet);
            }
        }//用户表数据添加接口


        public class rempClass
        {
            public int Id { get; set; }
            public string Accountnumber { get; set; }
            public string Password { get; set; }
            public string Username { get; set; }
            public HttpPostedFileBase Userhead { get; set; }
        }


        public JsonResult Reset(rempClass model)
        {

                // 设定保存位置和文件名

                var list = new List<string> { ".png", ".jpg" };
                if (list.Contains(Path.GetExtension(model.Userhead.FileName)) && model.Userhead.ContentLength < 1024 * 1024 * 4)
                {
                    var path = "/upload/" + DateTime.Now.ToString("yyyyMMddHHmmssfff") + Path.GetExtension(model.Userhead.FileName);
                    ProjectDatabase use = new ProjectDatabase();
                    var you = use.usertable.FirstOrDefault(s => model.Id == s.Id);
                    if(you != null)
                    {
                        you.Account_number = model.Accountnumber;
                        you.Password = model.Password;
                        you.UserName = model.Username;
                        you.User_head = path;
                        model.Userhead.SaveAs(Server.MapPath(path));
                        use.SaveChanges();
                    }
                    return Json(new
                    {
                        success = true,
                        message = "修改成功"
                    }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new
                    {
                        success = false,
                        message = "修改失败"
                    }, JsonRequestBehavior.AllowGet);
                }
            
        }//用户表数据修改接口
    }
}