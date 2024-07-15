using _2001216311_VuThiHuyenVi_DoAn.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _2001216311_VuThiHuyenVi_DoAn.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            CompanyDBContext db = new CompanyDBContext();
            List<SanPhamm> sp = db.SanPhamm.ToList();
            return View(sp);
        }
    }
}