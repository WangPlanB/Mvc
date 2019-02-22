using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PetMvc.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart   购物车主页面
        public ActionResult Index()
        {
            //显示所属用户的购物车信息

            return View();
        }
        //删除购物车商品
        public ActionResult DeleteProduct()
        {
            return View();
        }
        //结算
        public ActionResult JieSuan()
        {
            //获取用户选中的商品

            return View();
        }


    }
}