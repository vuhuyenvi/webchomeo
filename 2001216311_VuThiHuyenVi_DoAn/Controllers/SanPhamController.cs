using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using _2001216311_VuThiHuyenVi_DoAn.Models;

namespace _2001216311_VuThiHuyenVi_DoAn.Controllers
{
    public class SanPhamController : Controller
    {
        // GET: SanPham
        //[HttpPost]
        public ActionResult Index(string search = "", string sortOrder = "IdSP", int page = 1)
        {
            CompanyDBContext db = new CompanyDBContext();
            List<SanPhamm> sp = db.SanPhamm.ToList();
            sp = db.SanPhamm.Where(row => row.NameSP.Contains(search)).ToList();
            ViewBag.Search = search;
            switch (sortOrder)
            {
                case "az":
                    sp = sp.OrderBy(item => item.NameSP).ToList();
                    break;
                case "za":
                    sp = sp.OrderByDescending(item => item.NameSP).ToList();
                    break;
                case "gia_tang":
                    sp = sp.OrderBy(item => item.GiaMoi).ToList();
                    break;
                case "gia_giam":
                    sp = sp.OrderByDescending(item => item.GiaMoi).ToList();
                    break;
                default:
                    break;
            }
            int NoOf = 12;
            int No = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(sp.Count) / Convert.ToDouble(NoOf)));
            int NoOfSkip = (page - 1) * NoOf;
            ViewBag.Page = page;
            ViewBag.No = No;
            sp = sp.Skip(NoOfSkip).Take(NoOf).ToList();


            return View(sp);
        }
        public ActionResult Detail(int id)
        {
            CompanyDBContext db = new CompanyDBContext();
            SanPhamm spp = db.SanPhamm.Where(row => row.IdSP == id).FirstOrDefault();
            return View(spp);
        }
    }
}