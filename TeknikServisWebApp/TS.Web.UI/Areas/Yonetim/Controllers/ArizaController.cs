using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TS.Web.BLL.Repository;
using TS.Web.MODEL.ViewModels;

namespace TS.Web.UI.Areas.Yonetim.Controllers
{
    public class ArizaController : Controller
    {
        // GET: Yonetim/Ariza
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public JsonResult Arizalar()
        {
            var model = new ArizaKaydiRepo().GetAll().OrderBy(x => x.OlusturulmaZamani).Select(x => new ArizaViewModel()
            {
                 Aciklama=x.Aciklama,
                  Adres=x.Adres,
                   MusteriId=x.MusteriId
                    
            }).ToList();
            return Json(model, JsonRequestBehavior.AllowGet);
        }
    }
}