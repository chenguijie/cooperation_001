using MyProjectOAServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyProjectOAServer.Controllers
{
    public class MerchantlistController : Controller
    {
        // GET: Merchantlist
        public JsonResult Load()
        {
            ProjectDatabase ctx = new ProjectDatabase();
            return Json(new
            {
                success = true,
                message = "查询成功",
                RelateData = ctx.merchant_list.Select(s => new
                {
                    id = s.Id,
                    nameofmerchant = s.Name_of_merchant,
                    businesscontactnumber = s.Business_contact_number,
                    shopname = s.Shop_name,
                    shopaddress = s.Shop_address,
                    longitudeofstoreaddress = s.Longitude_of_store_address,
                    storeaddresslatitude = s.Store_address_latitude
                }).ToList()
            }, JsonRequestBehavior.AllowGet);
        }//商家表所有数据加载接口


        public JsonResult Search(int Id)
        {
            ProjectDatabase ctx = new ProjectDatabase();
            var you = ctx.merchant_list.FirstOrDefault(s => Id == s.Id);
            if (you != null)
            {
                var list = ctx.merchant_list.Where(s => Id == s.Id).ToList();
                return Json(new
                {
                    success = true,
                    message = "查询成功",
                    RelateData = list.Select(s => new
                    {
                        id = s.Id,
                        nameofmerchant = s.Name_of_merchant,
                        businesscontactnumber = s.Business_contact_number,
                        shopname = s.Shop_name,
                        shopaddress = s.Shop_address,
                        longitudeofstoreaddress = s.Longitude_of_store_address,
                        storeaddresslatitude = s.Store_address_latitude
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
        }//商家表指定数据查询接口


        public class tempClass
        {

            public string Nameofmerchant { get; set; }
            public string Businesscontactnumber { get; set; }
            public string Shopname { get; set; }
            public string Shopaddress { get; set; }
            public string Longitudeofstoreaddress { get; set; }
            public string Storeaddresslatitude { get; set; }

        }


        public JsonResult Add(tempClass model)
        {
            var you = model;
            if (you != null)
            {
                ProjectDatabase use = new ProjectDatabase();
                merchant_list ctx = new merchant_list();
                ctx.Name_of_merchant = model.Nameofmerchant;
                ctx.Business_contact_number = model.Businesscontactnumber;
                ctx.Shop_name = model.Shopname;
                ctx.Shop_address = model.Shopaddress;
                ctx.Longitude_of_store_address = model.Longitudeofstoreaddress;
                ctx.Store_address_latitude = model.Storeaddresslatitude;
                use.merchant_list.Add(ctx);
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


        }//商家表数据添加接口


        public class rempClass
        {
            public int Id { get; set; }
            public string Nameofmerchant { get; set; }
            public string Businesscontactnumber { get; set; }
            public string Shopname { get; set; }
            public string Shopaddress { get; set; }
            public string Longitudeofstoreaddress { get; set; }
            public string Storeaddresslatitude { get; set; }


        }


        public JsonResult Reset(rempClass model)
        {
            ProjectDatabase use = new ProjectDatabase();
            var you = use.merchant_list.FirstOrDefault(s => model.Id == s.Id);
            if (you != null)
            {
                you.Name_of_merchant = model.Nameofmerchant;
                you.Business_contact_number = model.Businesscontactnumber;
                you.Shop_name = model.Shopname;
                you.Shop_address = model.Shopaddress;
                you.Longitude_of_store_address = model.Longitudeofstoreaddress;
                you.Store_address_latitude = model.Storeaddresslatitude;
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
        }//商家表数据修改接口
    }
}