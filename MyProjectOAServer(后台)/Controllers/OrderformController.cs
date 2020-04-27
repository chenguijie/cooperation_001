using MyProjectOAServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyProjectOAServer.Controllers
{
    public class OrderformController : Controller
    {
        // GET: Orderform


        public JsonResult Load()
        {
            ProjectDatabase ctx = new ProjectDatabase();
            return Json(new
            {
                success = true,
                message = "查询成功",
                RelateData = ctx.order_form.Select(s => new
                {
                    id = s.Id,
                    userid = s.UserId,
                    riderid = s.RiderId,
                    ordertime = s.Order_time,
                    deliverytime = s.Delivery_time,
                    servicetime = s.Service_time,
                    nameofshipper = s.Name_of_shipper,
                    contactnumber = s.Contact_number,
                    receivingaddress = s.Receiving_address,
                    longitudeofreceivingaddress = s.Longitude_of_receiving_address,
                    receivingaddresslatitude =s.Receiving_address_latitude,
                    redenvelopededuction = s.Red_envelope_deduction,
                    totalorderconsumption = s.Total_order_consumption
                }).ToList()
            }, JsonRequestBehavior.AllowGet);
        }//订单表所有数据加载接口


        public JsonResult Search(int Id)
        {
            ProjectDatabase ctx = new ProjectDatabase();
            var you = ctx.order_form.FirstOrDefault(s => Id == s.Id);
            if(you != null)
            {
                var list = ctx.order_form.Where(s => Id == s.Id).ToList();
                return Json(new
                {
                    success = true,
                    message = "查询成功",
                    RelateData = list.Select(s => new
                    {
                        id = s.Id,
                        userid = s.UserId,
                        riderid = s.RiderId,
                        ordertime = s.Order_time,
                        deliverytime = s.Delivery_time,
                        servicetime = s.Service_time,
                        nameofshipper = s.Name_of_shipper,
                        contactnumber = s.Contact_number,
                        receivingaddress = s.Receiving_address,
                        longitudeofreceivingaddress = s.Longitude_of_receiving_address,
                        receivingaddresslatitude = s.Receiving_address_latitude,
                        redenvelopededuction = s.Red_envelope_deduction,
                        totalorderconsumption = s.Total_order_consumption
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
        }//订单表指定数据查询接口


        public class tempClass
        {

            public int UserId { get; set; }
            public int RiderId { get; set; }
            public string Ordertime { get; set; }
            public string Deliverytime { get; set; }
            public string Servicetime { get; set; }
            public string Nameofshipper { get; set; }
            public string Contactnumber { get; set; }
            public string Receivingaddress { get; set; }
            public string Longitudeofreceivingaddress { get; set; }
            public string Receivingaddresslatitude { get; set; }
            public int Redenvelopededuction { get; set; }
            public int Totalorderconsumption { get; set; }

        }


        public JsonResult Add(tempClass model)
        {
            var you = model;
            if(you != null)
            {
                ProjectDatabase use = new ProjectDatabase();
                order_form ctx = new order_form();
                ctx.UserId = model.UserId;
                ctx.RiderId = model.RiderId;
                ctx.Order_time = model.Ordertime;
                ctx.Delivery_time = model.Deliverytime;
                ctx.Service_time = model.Servicetime;
                ctx.Name_of_shipper = model.Nameofshipper;
                ctx.Contact_number = model.Contactnumber;
                ctx.Receiving_address = model.Receivingaddress;
                ctx.Longitude_of_receiving_address = model.Longitudeofreceivingaddress;
                ctx.Receiving_address_latitude = model.Receivingaddresslatitude;
                ctx.Red_envelope_deduction = model.Redenvelopededuction;
                ctx.Total_order_consumption = model.Totalorderconsumption;
                use.order_form.Add(ctx);
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
           
           
        }//订单表数据添加接口


        public class rempClass
        {
            public int Id { get; set; }
            public int UserId { get; set; }
            public int RiderId { get; set; }
            public string Ordertime { get; set; }
            public string Deliverytime { get; set; }
            public string Servicetime{ get; set; }
            public string Nameofshipper { get; set; }
            public string Contactnumber { get; set; }
            public string Receivingaddress { get; set; }
            public string Longitudeofreceivingaddress { get; set; }
            public string Receivingaddresslatitude { get; set; }
            public int Redenvelopededuction { get; set; }
            public int Totalorderconsumption { get; set; }

        }


        public JsonResult Reset(rempClass model)
        {
            ProjectDatabase use = new ProjectDatabase();
            var you = use.order_form.FirstOrDefault(s => model.Id == s.Id);
            if(you != null)
            {
                you.UserId = model.Id;
                you.RiderId = model.RiderId;
                you.Order_time = model.Ordertime;
                you.Delivery_time = model.Deliverytime;
                you.Service_time = model.Deliverytime;
                you.Name_of_shipper = model.Nameofshipper;
                you.Contact_number = model.Contactnumber;
                you.Receiving_address = model.Receivingaddress;
                you.Longitude_of_receiving_address = model.Longitudeofreceivingaddress;
                you.Receiving_address_latitude = model.Receivingaddresslatitude;
                you.Red_envelope_deduction = model.Redenvelopededuction;
                you.Total_order_consumption = model.Totalorderconsumption;
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
        }//订单表数据修改接口
    }
}