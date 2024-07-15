using System.Web.Mvc;

namespace _2001216311_VuThiHuyenVi_DoAn.Areas.Admin
{
    public class AdminAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Admin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Admin_default",
                "Admin/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional },
                namespaces: new[] {"_2001216311_VuThiHuyenVi_DoAn.Areas.Admin.Controllers"}
            );
        }
    }
}