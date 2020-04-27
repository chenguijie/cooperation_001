using MyProjectOAServer.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyProjectOAServer.Controllers
{
    public class CommoditylistController : Controller
    {
        // GET: Commoditylist
        public JsonResult Load()
        {
            ProjectDatabase ctx = new ProjectDatabase();
            return Json(new
            {
                success = true,
                message = "查询成功",
                RelateData = ctx.commodity_list.Select(s => new
                {
                    id = s.Id,
                    merchantid = s.Merchant_Id,
                    categoryid = s.categoryId,
                    tradename = s.Trade_name,
                    commoditypictures = s.Commodity_pictures,
                    commoditydescription = s.Commodity_Description,
                    itempricing = s.item_pricing,
                    merchandisediscount = s.Merchandise_discount,
                    commodityinventory = s.Commodity_inventory,
                    orderquantity = s.Order_quantity
                }).ToList()
            }, JsonRequestBehavior.AllowGet);
        }//商品表所有数据加载接口


        public JsonResult Search(int Id)
        {
            ProjectDatabase ctx = new ProjectDatabase();
            var you = ctx.commodity_list.FirstOrDefault(s => Id == s.Id);
            if (you != null)
            {
                var list = ctx.commodity_list.Where(s => Id == s.Id).ToList();
                return Json(new
                {
                    success = true,
                    message = "查询成功",
                    RelateData = list.Select(s => new
                    {
                        id = s.Id,
                        merchantid = s.Merchant_Id,
                        categoryid = s.categoryId,
                        tradename = s.Trade_name,
                        commoditypictures = s.Commodity_pictures,
                        commoditydescription = s.Commodity_Description,
                        itempricing = s.item_pricing,
                        merchandisediscount = s.Merchandise_discount,
                        commodityinventory = s.Commodity_inventory,
                        orderquantity = s.Order_quantity
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
        }//商品表指定数据查询接口


        public class tempClass
        {

            public int MerchantId { get; set; }
            public int categoryId { get; set; }
            public string Tradename { get; set; }
            public HttpPostedFileBase Commoditypictures { get; set; }
            public string CommodityDescription { get; set; }
            public int itempricing { get; set; }
            public int Merchandisediscount { get; set; }
            public int Commodityinventory { get; set; }

            public int Orderquantity { get; set; }

        }


        public JsonResult Add(tempClass model)
        {
            // 设定保存位置和文件名

            var list = new List<string> { ".png", ".jpg" };
            if (list.Contains(Path.GetExtension(model.Commoditypictures.FileName)) && model.Commoditypictures.ContentLength < 1024 * 1024 * 4)
            {
                var path = "/upload/" + DateTime.Now.ToString("yyyyMMddHHmmssfff") + Path.GetExtension(model.Commoditypictures.FileName);
                ProjectDatabase use = new ProjectDatabase();
                commodity_list ctx = new commodity_list();
                ctx.Merchant_Id = model.MerchantId;
                ctx.categoryId = model.categoryId;
                ctx.Trade_name = model.Tradename;
                ctx.Commodity_pictures = path;
                ctx.Commodity_Description = model.CommodityDescription;
                ctx.item_pricing = model.itempricing;
                ctx.Merchandise_discount = model.Merchandisediscount;
                ctx.Commodity_inventory = model.Commodityinventory;
                ctx.Order_quantity = model.Orderquantity;
                use.commodity_list.Add(ctx);
                use.SaveChanges();
                model.Commoditypictures.SaveAs(Server.MapPath(path));


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
        }//商品表数据添加接口


        public class rempClass
        {
            public int Id { get; set; }
            public int MerchantId { get; set; }
            public int categoryId { get; set; }
            public string Tradename { get; set; }
            public HttpPostedFileBase Commoditypictures{ get; set; }
            public string CommodityDescription { get; set; }
            public int itempricing { get; set; }
            public int Merchandisediscount { get; set; }
            public int Commodityinventory { get; set; }
            public int Orderquantity { get; set; }
        }


        public JsonResult Reset(rempClass model)
        {

            // 设定保存位置和文件名

            var list = new List<string> { ".png", ".jpg" };
            if (list.Contains(Path.GetExtension(model.Commoditypictures.FileName)) && model.Commoditypictures.ContentLength < 1024 * 1024 * 4)
            {
                var path = "/upload/" + DateTime.Now.ToString("yyyyMMddHHmmssfff") + Path.GetExtension(model.Commoditypictures.FileName);
                ProjectDatabase use = new ProjectDatabase();
                var you = use.commodity_list.FirstOrDefault(s => model.Id == s.Id);
                if(you != null)
                {
                    you.Merchant_Id = model.MerchantId;
                    you.categoryId = model.categoryId;
                    you.Trade_name = model.Tradename;
                    you.Commodity_pictures = path;
                    you.Commodity_Description = model.CommodityDescription;
                    you.item_pricing = model.itempricing;
                    you.Merchandise_discount = model.Merchandisediscount;
                    you.Commodity_inventory = model.Commodityinventory;
                    you.Order_quantity = model.Orderquantity;
                    model.Commoditypictures.SaveAs(Server.MapPath(path));
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

        }//商品表数据修改接口
    }
}