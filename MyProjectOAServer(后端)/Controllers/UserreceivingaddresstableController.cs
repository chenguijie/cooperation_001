using MyProjectOAServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyProjectOAServer.Controllers
{
    public class UserreceivingaddresstableController : Controller
    {
        // GET: Userreceivingaddresstable
        public JsonResult Load()
        {
            ProjectDatabase ctx = new ProjectDatabase();
            return Json(new
            {
                success = true,
                message = "查询成功",
                RelateData = ctx.user_receiving_address_table.Select(s => new
                {
                    id = s.Id,
                    userid = s.UserId,
                    nameofshipper = s.Name_of_shipper,
                    receivingaddress = s.Receiving_address,
                    longitudeofreceivingaddress = s.Longitude_of_receiving_address,
                    receivingaddresslatitude = s .Receiving_address_latitude
                }).ToList()
            }, JsonRequestBehavior.AllowGet);
        }//用户收货地址表所有数据加载接口


        public JsonResult Search(int Id)
        {
            ProjectDatabase ctx = new ProjectDatabase();
            var you = ctx.user_receiving_address_table.FirstOrDefault(s => Id == s.UserId);
            if (you != null)
            {
                var list = ctx.user_receiving_address_table.Where(s => Id == s.UserId).ToList();
                return Json(new
                {
                    success = true,
                    message = "查询成功",
                    RelateData = list.Select(s => new
                    {
                       id = s.Id,
                       userid = s.UserId,
                       nameofshipper = s.Name_of_shipper,
                       receivingaddress = s.Receiving_address,
                       longitudeofreceivingaddress = s.Longitude_of_receiving_address,
                       receivingaddresslatitude = s.Receiving_address_latitude
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
        }//用户收货地址表指定数据查询接口


        public class tempClass
        {

            public int UserId { get; set; }
            public string Nameofshipper { get; set; }
            public string Receivingaddress { get; set; }
            public string Longitudofreceivingaddress { get; set; }
            public string Receivingaddresslatitude { get; set; }

        }


        public JsonResult Add(tempClass model)
        {
            var you = model;
            if (you != null)
            {
                ProjectDatabase use = new ProjectDatabase();
                user_receiving_address_table ctx = new user_receiving_address_table();
                ctx.UserId = model.UserId;
                ctx.Name_of_shipper = model.Nameofshipper;
                ctx.Receiving_address = model.Receivingaddress;
                ctx.Longitude_of_receiving_address = model.Longitudofreceivingaddress;
                ctx.Receiving_address_latitude = model.Receivingaddresslatitude;
                use.user_receiving_address_table.Add(ctx);
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


        }//用户收货地址表数据添加接口


        public class rempClass
        {
            public int Id { get; set; }
            public int UserId { get; set; }
            public string Nameofshipper { get; set; }
            public string Receivingaddress { get; set; }
            public string Longitudofreceivingaddress { get; set; }
            public string Receivingaddresslatitude { get; set; }
           
        }


        public JsonResult Reset(rempClass model)
        {
            ProjectDatabase use = new ProjectDatabase();
            var you = use.user_receiving_address_table.FirstOrDefault(s => model.Id == s.Id);
            if(you != null)
            {
                you.UserId = model.UserId;
                you.Name_of_shipper = model.Nameofshipper;
                you.Receiving_address = model.Receivingaddress;
                you.Longitude_of_receiving_address = model.Longitudofreceivingaddress;
                you.Receiving_address_latitude = model.Receivingaddresslatitude;
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
        }//用户收货地址表数据修改接口
    }
}