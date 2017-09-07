using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using TS.Web.BLL.SiteSettings;
using TS.Web.MODEL.IdentityModels;
using TS.Web.MODEL.ViewModels;
using static TS.Web.BLL.Account.MembershipTools;

namespace TS.Web.UI.Areas.Yonetim.Controllers
{
    public class TekOpController : Controller
    {
        // GET: Yonetim/TekOp
        public ActionResult Index()
        {
            return View();
        }

        public string SiteUrl()
        {
            return Request.Url.Scheme + Uri.SchemeDelimiter + Request.Url.Host +
            (Request.Url.IsDefaultPort ? "" : ":" + Request.Url.Port);
        }

        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var userManager = NewUserManager();
            var checkUser = userManager.FindByEmail(model.Email);
            if (checkUser != null)
            {
                ModelState.AddModelError("", "Bu email adresi kullanılmaktadır");
                return View(model);
            }
            checkUser = await userManager.FindByNameAsync(model.Username);
            if (checkUser != null)
            {
                ModelState.AddModelError("", "Bu kullanici adı kullanılmaktadır");
                return View(model);
            }
            var actcode = Guid.NewGuid().ToString().Replace("-", "");
            var user = new ApplicationUser()
            {
                Name = model.Name,
                Email = model.Email,
                PhoneNumber = model.Phone,
                Surname = model.Surname,
                UserName = model.Username
                //ActivationCode = actcode
            };
            bool adminMi = userManager.Users.Count() == 0;

            var sonuc = await userManager.CreateAsync(user, model.ConfirmPassword);
            if (sonuc.Succeeded)
            {
                if (adminMi)
                {
                    userManager.AddToRole(user.Id, "Admin");

                }
                else if (model.OperatorMu)
                {
                    userManager.AddToRole(user.Id, "Operator");
                }
                else if (model.TeknisyenMi)
                {
                    userManager.AddToRole(user.Id, "Teknisyen");
                }
                else
                {
                    userManager.AddToRole(user.Id, "Musteri");

                }
                await Settings.SendMail(new MailModel()
                {
                    To = user.Email,
                    Subject = "Hoşgeldiniz",
                    Message = $"Merhaba {user.UserName}, <br/>Sisteme başarıyla kaydoldunuz<br/>Hesabınızı aktifleştirmek için <a href='{SiteUrl()}/hesap/aktivasyon?code={actcode}'>Aktivasyon Kodu</a>"
                });

                return RedirectToAction("Register", "Hesap"); // Değişecek
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Kullanıcı kayıt işleminde hata oluştu!");
                return View(model);
            }
        }
    }
}