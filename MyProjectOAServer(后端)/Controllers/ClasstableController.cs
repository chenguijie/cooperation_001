using MyProjectOAServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyProjectOAServer.Controllers
{
    public class ClasstableController : Controller
    {
        // GET: Classtable
        public JsonResult Load()
        {
            ProjectDatabase ctx = new ProjectDatabase();
            return Json(new
            {
                success = true,
                message = "查询成功",
                RelateData = ctx.class_table.Select(s => new
                {
                    id = s.Id,
                    categoryname = s.Category_name,
                    classdescription = s.Class_description
                }).ToList()
            }, JsonRequestBehavior.AllowGet);
        }//类别表所有数据加载接口


        public JsonResult Search(int Id)
        {
            ProjectDatabase ctx = new ProjectDatabase();
            var you = ctx.class_table.FirstOrDefault(s => Id == s.Id);
            if (you != null)
            {
                var list = ctx.class_table.Where(s => Id == s.Id).ToList();
                return Json(new
                {
                    success = true,
                    message = "查询成功",
                    RelateData = list.Select(s => new
                    {
                        id = s.Id,
                        categoryname = s.Category_name,
                        classdescription = s.Class_description
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
        }//类别表指定数据查询接口


        public class tempClass
        {

            public string Categoryname { get; set; }
            public string Classdescription { get; set; }

        }


        public JsonResult Add(tempClass model)
        {
            var you = model;
            if (you != null)
            {
                ProjectDatabase use = new ProjectDatabase();
                class_table ctx = new class_table();
                ctx.Category_name = model.Categoryname;
                ctx.Class_description = model.Classdescription;
                use.class_table.Add(ctx);
                use.SaveChanges();
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


        }//类别表数据添加接口


        public class rempClass
        {
            public int Id { get; set; }
            public string Categoryname { get; set; }
            public string Classdescription { get; set; }

        }


        public JsonResult Reset(rempClass model)
        {
            ProjectDatabase use = new ProjectDatabase();
            var you = use.class_table.FirstOrDefault(s => model.Id == s.Id);
            if(you != null)
            {
                you.Category_name = model.Categoryname;
                you.Class_description = model.Classdescription;
                use.SaveChanges();
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
        }//类别表数据修改接口
    }
}