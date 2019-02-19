using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using PetMvc.Models;
namespace PetMvc.Controllers
{
    public class UsersController : Controller
    {
        // GET: Users
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(UsersModel model)
        {
            string str = JsonConvert.SerializeObject(model);
            string reulst = HttpClientHelper.Send("post", "/api/UsersApi/", str);
            return Content("111");
        }
    }
}