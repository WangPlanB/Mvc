using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using PetMvc.Models;

namespace PetMvc.Controllers
{
    public class PetController : Controller
    {
        // GET: Pet
        public ActionResult Index()    // 主模板
        {
            return View();
        }

        public ActionResult Home()    // 系统首页
        {
            double a = 0;
            int a1=0, a2=0, a3=0,b1=0,b2=0;

            string str = HttpClientHelper.Send("get", "api/Order", "");
            List<OrderModel> Orderlist = JsonConvert.DeserializeObject<List<OrderModel>>(str);

            string str2 = HttpClientHelper.Send("get", "api/Pets", "");
            List<PetModel> Petlist = JsonConvert.DeserializeObject<List<PetModel>>(str2);

            string str1 = HttpClientHelper.Send("get", "api/UsersApi", "");
            List<UserModel> Userlist = JsonConvert.DeserializeObject<List<UserModel>>(str1);

            foreach (var item in Orderlist)
            {
                a = a + item.Price;
            }

            foreach (var item in Orderlist)
            {
                if (item.State == 1)
                {
                    a1++;
                } else if (item.State==2)
                {
                    a2++;
                }
                else {
                    a3++;
                }
            }

            foreach (var item in Petlist)
            {
                if (item.PetState==1)
                {
                    b1++;
                } else 
                {
                    b2++;
                }
            }

            ViewBag.RenShu = Userlist.Count();
            ViewBag.Price = a;
            ViewBag.DingDan = Orderlist.Count();
            ViewBag.a1 = a1;
            ViewBag.a2 = a2;
            ViewBag.a3 = a3;
            ViewBag.b1 = Petlist.Count();
            ViewBag.b2 = b1;
            ViewBag.a3 = a2;
            return View();
        }

        public ActionResult admin_info()   // 个人资料
        {
            return View();
        }


        //[HttpGet]
        //public ActionResult Add()
        //{

        //}
        //[HttpPost]
        //public ActionResult Add()
        //{

        //}
    }
}