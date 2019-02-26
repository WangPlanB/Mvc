using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PetMvc.Models;
using Newtonsoft.Json;

namespace PetMvc.Controllers
{
    public class PetController : Controller
    {
        // GET: Pet
        public ActionResult Index()    // 主模板
        {
            return View();
        }
        [HttpGet]
        public ActionResult AddPet()    // 添加宠物模板模板
        {
            var ResultAdd = HttpClientHelper.Send("get", "api/PetTypeApi?petTypeId=0", "");
            List<PetType> lisXiaLa = JsonConvert.DeserializeObject<List<PetType>>(ResultAdd);
            SelectList lis = new SelectList(lisXiaLa, "Id", "TypeName");
            SelectList lis2 = new SelectList(new List<PetType>(), "Id", "TypeName");
            ViewBag.Pid = lis;
            ViewBag.TypeId = lis2;
            return View();
        }
        public ActionResult XiaLa(int Pid)    // 添加宠物模板模板
        {
            var ResultAdd = HttpClientHelper.Send("get", "api/PetTypeApi?petTypeId=" + Pid, "");
            List<PetType> lisXiaLa = JsonConvert.DeserializeObject<List<PetType>>(ResultAdd);
            return Json(lisXiaLa);
        }
        
            public ActionResult FanTianPet(int Id)    // 反填宠物模板
        {
            var ResultAdd = HttpClientHelper.Send("get", "api/Pets", "");
            List<PetModel> lisFanTian = JsonConvert.DeserializeObject<List<PetModel>>(ResultAdd);
            var lis =( from s in lisFanTian.ToList()
            where s.PetId.Equals(Id)
            select s).FirstOrDefault();
            return Json(lis);
        }
        public ActionResult UpdPet(PetModel model,HttpPostedFileBase PetHeads)    // 修改宠物模板
        {
            string jue = Server.MapPath("/image/");
            string filename = DateTime.Now.ToString("yyyyMMddHHmmss") + PetHeads.FileName;
            PetHeads.SaveAs(jue + filename);
            model.PetHead = "/image/" + filename;
            string strUpd = JsonConvert.SerializeObject(model);
            var Resultupd = HttpClientHelper.Send("put", "api/Pets",strUpd);
            if (Convert.ToInt32(Resultupd) > 0)
            {
                return Content("<script>alert('修改成功√');location.href='/Pet/ShowPet'</script>");
            }
            else
            {
                return Content("<script>alert(修改失败×');location.href='/Pet/ShowPet'</script>");
            }
        }
        [HttpPost]
        public ActionResult AddPet(PetModel model, HttpPostedFileBase PetHead)    // 添加宠物模板模板
        {
            model.PetState = 1;
            model.PetStartTime = DateTime.Now.ToString("yyyy-MM-dd");
            string jue = Server.MapPath("/image/");
            string filename = DateTime.Now.ToString("yyyyMMddHHmmss") + PetHead.FileName;
            PetHead.SaveAs(jue + filename);
            model.PetHead = "/image/" + filename;

            string strPet = JsonConvert.SerializeObject(model);
            var ResultAdd = HttpClientHelper.Send("post", "api/Pets", strPet);
            if (Convert.ToInt32(ResultAdd) > 0)
            {
                return Content("<script>alert('添加成功√');location.href='/Pet/AddPet'</script>");
            }
            else
            {
                return Content("<script>alert('添加失败×');location.href='/Pet/AddPet'</script>");
            }
        }
        public ActionResult DelPet(string  id)    // 删除宠物模板
        {
            var ResultDel = HttpClientHelper.Send("delete", "api/Pets?Id="+ id, "");
            if (Convert.ToInt32(ResultDel) > 0)
            {
                return Content("<script>alert('删除成功√');location.href='/Pet/ShowPet'</script>");
            }
            else
            {
                return Content("<script>alert('删除失败×');location.href='/Pet/ShowPet'</script>");
            }
        }

        public ActionResult ShowPet(string ShowTime="",string DogClass="",string MaoClass="")    // 显示宠物模板模板
        {
            var ResultAdd = "";
            List<PetModel> liPet;
            ResultAdd = HttpClientHelper.Send("get", "api/Pets", "");
            liPet = JsonConvert.DeserializeObject<List<PetModel>>(ResultAdd);  //宠物表
            IEnumerable<PetModel> lisPet = null;
            var ResultPetType = HttpClientHelper.Send("get", "api/PetTypeApi", "");
            List<PetType> lisPetType = JsonConvert.DeserializeObject<List<PetType>>(ResultPetType);  //宠物品种表
            #region  if判断进行查询
            if (ShowTime != "")
            {
                lisPet = from s in liPet.ToList()
                         where s.PetStartTime.Equals(ShowTime)
                         select s;
            }
            else if (ShowTime != "" && DogClass != "")
            {
                lisPet = from s in liPet.ToList()
                         join ss in lisPetType.ToList()
                         on s.TypeId equals ss.Id
                         where s.PetStartTime.Equals(ShowTime) && ss.petTypeId.Equals(2)
                         select s;
            }
            else if (ShowTime != "" && MaoClass != "")
            {
                lisPet = from s in liPet.ToList()
                         join ss in lisPetType.ToList()
                         on s.TypeId equals ss.Id
                         where s.PetStartTime.Equals(ShowTime) && ss.petTypeId.Equals(3)
                         select s;
            }
            else if (DogClass != "")
            {
                lisPet = from s in liPet.ToList()
                         join ss in lisPetType.ToList()
                         on s.TypeId equals ss.Id
                         where ss.petTypeId.Equals(2)
                         select s;
            }
            else if (MaoClass != "")
            {
                lisPet = from s in liPet.ToList()
                         join ss in lisPetType.ToList()
                         on s.TypeId equals ss.Id
                         where ss.petTypeId.Equals(3)
                         select s;
            }
            else if (ShowTime == "" && DogClass == "" && DogClass == "")
            {
                lisPet = from s in liPet.ToList()
                         select s;
            }
            #endregion
            ViewBag.Snum = liPet.Count();
            //本店内有多少只狗
            ViewBag.DogNum = (from s in liPet.ToList()
                              join ss in lisPetType.ToList()
                              on s.TypeId equals ss.Id
                              where ss.petTypeId.Equals(2)
                              select s).Count();
            //本店内有多少只猫
            ViewBag.MaoNum = (from s in liPet.ToList()
                              join ss in lisPetType.ToList()
                              on s.TypeId equals ss.Id
                              where ss.petTypeId.Equals(3)
                              select s).Count();
            return View(lisPet);
        }
        


        public ActionResult Home()    // 系统首页
        {

            return View();
        }

        public ActionResult StateUpd(int Id)   // 状态改变
        {

            var Resultupd = HttpClientHelper.Send("get", "api/Pets", "");
            List<PetModel> lisPet = JsonConvert.DeserializeObject<List<PetModel>>(Resultupd);
            var data = (from s in lisPet.ToList()
                        where s.PetId.Equals(Id)
                        select s).FirstOrDefault();
            if (data.PetState == 1)
            {
                data.PetState = 2;
                string strupd = JsonConvert.SerializeObject(data);
                var ResultUpd = HttpClientHelper.Send("put", "api/Pets", strupd);
                return Redirect("ShowPet");
                //return Content("<script>location.href='/Pet/ShowPet'</script>");

            }
            else if (data.PetState == 2)
            {
                data.PetState = 1;
                string strupd = JsonConvert.SerializeObject(data);
                var ResultUpd = HttpClientHelper.Send("put", "api/Pets", strupd);
                return Redirect("ShowPet");
                //return Content("<script>location.href='/Pet/ShowPet'</script>");
            }
            else
            {
                return Redirect("ShowPet"); //return Content("<script>location.href='/Pet/ShowPet'</script>"); }
            }
        }
    }
    public enum StateInfo
    {
        上架中 = 1,
        下架中 = 2
    }
}