using MyProjectOAServer.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyProjectOAServer.Controllers
{
    public class RidingawatchController : Controller
    {
        // GET: Ridingawatch
        public JsonResult Load()
        {
            ProjectDatabase ctx = new ProjectDatabase();
            return Json(new
            {
                success = true,
                message = "查询成功",
                RelateData = ctx.riding_a_watch.Select(s => new
                {
                    id = s.Id,
                    nameofrider = s.Name_of_rider,
                    dateofbirth = s.Date_of_birth,
                    dateofentry = s.Date_of_entry,
                    rideraddress = s.Rider_address,
                    ridercontactnumber = s.Rider_contact_number,
                    photosofriders = s.Photos_of_riders,
                    rideridnumber = s.Rider_ID_number,
                    riderincome = s.Rider_income
                }).ToList()
            }, JsonRequestBehavior.AllowGet);
        }//骑手表所有数据加载接口


        public JsonResult Search(int Id)
        {
            ProjectDatabase ctx = new ProjectDatabase();
            var you = ctx.riding_a_watch.FirstOrDefault(s => Id == s.Id);
            if (you != null)
            {
                var list = ctx.riding_a_watch.Where(s => Id == s.Id).ToList();
                return Json(new
                {
                    success = true,
                    message = "查询成功",
                    RelateData = list.Select(s => new
                    {
                        id = s.Id,
                        nameofrider = s.Name_of_rider,
                        dateofbirth = s.Date_of_birth,
                        dateofentry = s.Date_of_entry,
                        rideraddress = s.Rider_address,
                        ridercontactnumber = s.Rider_contact_number,
                        photosofriders = s.Photos_of_riders,
                        rideridnumber = s.Rider_ID_number,
                        riderincome = s.Rider_income
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
        }//骑手表指定数据查询接口


        public class tempClass
        {

            public string Nameofrider { get; set; }
            public string Dateofbirth { get; set; }
            public string Dateofentry { get; set; }
            public string Rideraddress { get; set; }
            public string Ridercontactnumber { get; set; }
            public HttpPostedFileBase Photosofriders { get; set; }
            public string RiderIDnumber { get; set; }
            public string Riderincome { get; set; }
        }


        public JsonResult Add(tempClass model)
        {
            // 设定保存位置和文件名

            var list = new List<string> { ".png", ".jpg" };
            if (list.Contains(Path.GetExtension(model.Photosofriders.FileName)) && model.Photosofriders.ContentLength < 1024 * 1024 * 4)
            {
                var path = "/upload/" + DateTime.Now.ToString("yyyyMMddHHmmssfff") + Path.GetExtension(model.Photosofriders.FileName);
                ProjectDatabase use = new ProjectDatabase();
                riding_a_watch ctx = new riding_a_watch();
                ctx.Name_of_rider = model.Nameofrider;
                ctx.Date_of_birth = model.Dateofbirth;
                ctx.Date_of_entry = model.Dateofentry;
                ctx.Rider_address = model.Rideraddress;
                ctx.Rider_contact_number = model.Ridercontactnumber;
                ctx.Photos_of_riders = path;
                ctx.Rider_ID_number = model.RiderIDnumber;
                ctx.Rider_income = model.Riderincome;
                use.riding_a_watch.Add(ctx);
                use.SaveChanges();
                model.Photosofriders.SaveAs(Server.MapPath(path));


                return Json(new
                {
                    success = true,
                    message = "添加成功"
                });
            }
            else
            {
                return Json(new
                {
                    success = false,
                    message = "添加失败"
                });
            }
        }//骑手表数据添加接口


        public class rempClass
        {
            public int Id { get; set; }
            public string Nameofrider { get; set; }
            public string Dateofbirth { get; set; }
            public string Dateofentry { get; set; }
            public string Rideraddress{ get; set; }
            public string Ridercontactnumber { get; set; }
            public HttpPostedFileBase Photosofriders { get; set; }
            public string RiderIDnumber { get; set; }
            public string Riderincome{ get; set; }

        }


        public JsonResult Reset(rempClass model)
        {

            // 设定保存位置和文件名

            var list = new List<string> { ".png", ".jpg" };
            if (list.Contains(Path.GetExtension(model.Photosofriders.FileName)) && model.Photosofriders.ContentLength < 1024 * 1024 * 4)
            {
                var path = "/upload/" + DateTime.Now.ToString("yyyyMMddHHmmssfff") + Path.GetExtension(model.Photosofriders.FileName);
                ProjectDatabase use = new ProjectDatabase();
                var you = use.riding_a_watch.FirstOrDefault(s => model.Id == s.Id);
                if (you != null)
                {
                    you.Name_of_rider = model.Nameofrider;
                    you.Date_of_birth = model.Dateofbirth;
                    you.Date_of_entry = model.Dateofentry;
                    you.Rider_address = model.Rideraddress;
                    you.Rider_contact_number = model.Ridercontactnumber;
                    you.Photos_of_riders = path;
                    you.Rider_ID_number = model.RiderIDnumber;
                    you.Rider_income = model.Riderincome;
                    model.Photosofriders.SaveAs(Server.MapPath(path));
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

        }//骑手表数据修改接口
    }
}