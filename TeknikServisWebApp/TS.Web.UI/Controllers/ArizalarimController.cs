using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TS.Web.BLL.Repository;
using TS.Web.MODEL.ViewModels;

namespace TS.Web.UI.Controllers
{
    public class ArizalarimController : Controller
    {
        // GET: Yonetim/Ariza
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public JsonResult Arizalarim()
        {
            var model = new ArizaKaydiRepo().GetAll().OrderBy(x => x.OlusturulmaZamani).Where(x=>x.MusteriId== HttpContext.User.Identity.GetUserId()).Select(x => new ArizaViewModel()
            {
                Aciklama = x.Aciklama,
                Adres = x.Adres,
                MusteriId = x.MusteriId

            }).ToList();
            return Json(model, JsonRequestBehavior.AllowGet);
        }
    }
}