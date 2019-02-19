using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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

            return View();
        }

        public ActionResult admin_info()   // 个人资料
        {
            return View();
        }
    }
}