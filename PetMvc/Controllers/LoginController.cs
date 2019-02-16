using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;

namespace PetMvc.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]  //控制器
        public ActionResult a()
        {
            return File(new Ddmo.VerifvCode().GetVerifvCode(), @"image/Gif");
        }
    }
}