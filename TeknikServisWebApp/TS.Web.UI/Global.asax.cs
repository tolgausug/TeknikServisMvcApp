using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using TS.Web.BLL.Account;
using TS.Web.MODEL.IdentityModels;
using TS.Web.UI.App_Start;

namespace TS.Web.UI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            var roleManager = MembershipTools.NewRoleManager();
            if (!roleManager.RoleExists("Admin"))
            {
                roleManager.Create(new ApplicationRole()
                {
                    Name = "Admin",
                    Description = "Site Yöneticisi"
                });
            }
            if (!roleManager.RoleExists("Musteri"))
            {
                roleManager.Create(new ApplicationRole()
                {
                    Name = "Musteri",
                    Description = "Uygulama Müşterisi"
                });
            }
            if (!roleManager.RoleExists("Teknisyen"))
            {
                roleManager.Create(new ApplicationRole()
                {
                    Name = "Teknisyen",
                    Description = "Site Teknisyeni"
                });
            }
            if (!roleManager.RoleExists("Operator"))
            {
                roleManager.Create(new ApplicationRole()
                {
                    Name = "Operator",
                    Description = "Site Operatörü"
                });
            }

        }
    }
}
