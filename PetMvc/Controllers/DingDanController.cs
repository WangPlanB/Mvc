using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using PetMvc.Models;

namespace PetMvc.Controllers
{  
    public class DingDanController : Controller
    {
        // GET: DingDan
        public ActionResult Index()
        {
            int a = 0, b = 0, c = 0, d = 0;
            string str = HttpClientHelper.Send("get", "api/Order", "");
            List<OrderModel> list = JsonConvert.DeserializeObject<List<OrderModel>>(str);
            foreach (var item in list)
            {
                a++;
                if (item.State == 1)
                {
                    b++;
                }
                else if (item.State == 2)
                {
                    c++;
                }
                else
                {
                    d++;
                }
            }
            ViewBag.a = a;
            ViewBag.b = b;
            ViewBag.c = c;
            ViewBag.d = d;
            ViewBag.data = list;
            return View();
        }

        [HttpGet]
        public ActionResult Home(int id)
        {
            double price = 0;
            string str1 = HttpClientHelper.Send("get", "api/OrderMessage", "");
            List<OrderMassage> list = JsonConvert.DeserializeObject<List<OrderMassage>>(str1);

            List<OrderMassage> list1 = new List<OrderMassage>();
            list1 = list.Where(m => m.OrdersId == id).ToList();

            UserModel u = new UserModel();
            u = list.Where(m => m.OrdersId == id).FirstOrDefault().orders.Users;
            ViewBag.name = u.UsersName;
            ViewBag.phone = u.UPhone;
            ViewBag.loc = u.ULoc;
            ViewBag.num = list1.Count();
            foreach (var item in list1)
            {
                price += item.Price;
            }

            ViewBag.price = price;

            return View(list1);
        }

        [HttpGet]
        public ActionResult State(int id)
        {
            string str1 = HttpClientHelper.Send("get", "api/Order?id="+id, "");

            if (str1 == "1")
            {
                return Content("成功");
            }
            else
            {
                return Content("失败");
            }

        }

    }



 public enum State
    {

        代发货=1,
        已发货=2,
        已签收=3
    };
}