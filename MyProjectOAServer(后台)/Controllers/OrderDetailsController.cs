using MyProjectOAServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyProjectOAServer.Controllers
{
    public class OrderDetailsController : Controller
    {
        // GET: OrderDetails
        public JsonResult Load()
        {
            ProjectDatabase ctx = new ProjectDatabase();
            return Json(new
            {
                success = true,
                message = "查询成功",
                RelateData = ctx.order_details.Select(s => new
                {
                   id = s.Id,
                   orderid = s.OrderId,
                   commodityid = s.Commodity_Id,
                   itempricing = s.item_pricing,
                   quantityofcommodities = s.Quantity_of_commodities,
                   merchandisediscount = s.Merchandise_discount
                }).ToList()
            }, JsonRequestBehavior.AllowGet);
        }//订单明细表所有数据加载接口


        public JsonResult Search(int Id)
        {
            ProjectDatabase ctx = new ProjectDatabase();
            var you = ctx.order_details.FirstOrDefault(s => Id == s.OrderId);
            if (you != null)
            {
                var list = ctx.order_details.Where(s => Id == s.OrderId).ToList();
                return Json(new
                {
                    success = true,
                    message = "查询成功",
                    RelateData = list.Select(s => new
                    {
                        id = s.Id,
                        orderid = s.OrderId,
                        commodityid = s.Commodity_Id,
                        itempricing = s.item_pricing,
                        quantityofcommodities = s.Quantity_of_commodities,
                        merchandisediscount = s.Merchandise_discount
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
        }//订单明细表指定数据查询接口


        public class tempClass
        {

            public int OrderId { get; set; }
            public int CommodityId { get; set; }
            public int itempricing { get; set; }
            public int Quantityofcommodities { get; set; }
            public int Merchandisediscount { get; set; }

        }


        public JsonResult Add(tempClass model)
        {
            var you = model;
            if (you != null)
            {
                ProjectDatabase use = new ProjectDatabase();
                order_details ctx = new order_details();
                ctx.OrderId = model.OrderId;
                ctx.Commodity_Id = model.CommodityId;
                ctx.item_pricing = model.itempricing;
                ctx.Quantity_of_commodities = model.Quantityofcommodities;
                ctx.Merchandise_discount = model.Merchandisediscount;
                use.order_details.Add(ctx);
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


        }//订单明细表数据添加接口


        public class rempClass
        {
            public int Id { get; set; }
            public int OrderId { get; set; }
            public int CommodityId { get; set; }
            public int itempricing { get; set; }
            public int Quantityofcommodities { get; set; }
            public int Merchandisediscount { get; set; }


        }


        public JsonResult Reset(rempClass model)
        {
            ProjectDatabase use = new ProjectDatabase();
            var you = use.order_details.FirstOrDefault(s => model.Id == s.Id);
            if(you != null)
            {
                you.OrderId = model.OrderId;
                you.Commodity_Id = model.CommodityId;
                you.item_pricing = model.itempricing;
                you.Quantity_of_commodities = model.Quantityofcommodities;
                you.Merchandise_discount = model.Merchandisediscount;
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
        }//订单明细表数据修改接口
    }
}