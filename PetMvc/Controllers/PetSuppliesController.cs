using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PetMvc.Controllers
{
    public class PetSuppliesController : Controller
    {
        // GET: PetSupplies   宠物用品添加页面
        public ActionResult Index()
        {
            return View();
        }
    }
}