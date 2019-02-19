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
            string str = HttpClientHelper.Send("get", "api/OrderApi", "");
            List<OrderModel> list = JsonConvert.DeserializeObject<List<OrderModel>>(str);
            ViewBag.data = list;
            return View();
        }
     
    }



 public enum State
    {

        代发货=1,
        已发货=2,
        已签收=3
    };
}