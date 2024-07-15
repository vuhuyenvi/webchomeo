using _2001216311_VuThiHuyenVi_DoAn.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace _2001216311_VuThiHuyenVi_DoAn.Areas.Admin.Controllers
{
    public class AdminSanPhamController : Controller
    {
        // GET: Admin/SanPham
        public ActionResult Index()
        {

            CompanyDBContext db = new CompanyDBContext();
            List<SanPhamm> sp = db.SanPhamm.ToList();
            return View(sp);
        }
        //public ActionResult Detail(int id)
        //{
        //    CompanyDBContext db = new CompanyDBContext();
        //    SanPhamm spp = db.SanPhamm.Where(row => row.IdSP == id).FirstOrDefault();
        //    return View(spp);
        //}
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(SanPhamm s, HttpPostedFileBase HinhAnh)
        {
            if (ModelState.IsValid)
            {
                CompanyDBContext db = new CompanyDBContext();
                if (HinhAnh != null && HinhAnh.ContentLength > 0)
                {
                    if (HinhAnh.ContentLength > 2000000)
                    {
                        ModelState.AddModelError("Anh", "Kích thước file phải nhỏ hơn 2MB.");
                        return View();
                    }

                    var allowEx = new[] { ".jpg", ".png" };
                    var fileEx = Path.GetExtension(HinhAnh.FileName).ToLower();
                    if (!allowEx.Contains(fileEx))
                    {
                        ModelState.AddModelError("Anh", "Chỉ chấp nhận file ảnh jpg hoặc png.");
                        return View();
                    }

                    s.HinhAnh = "";
                    db.SanPhamm.Add(s);
                    db.SaveChanges();

                    SanPhamm pro = db.SanPhamm.ToList().Last();

                    var fileName = pro.IdSP.ToString() + "_1" + fileEx;
                    var path = Path.Combine(Server.MapPath("~/img"), fileName);
                    HinhAnh.SaveAs(path);

                    string link = "/img/" + fileName;
                    pro.HinhAnh = link;
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            CompanyDBContext db = new CompanyDBContext();
            SanPhamm sanPhamm = db.SanPhamm.Where(row=>row.IdSP == id).FirstOrDefault();
            return View(sanPhamm);
        }
        [HttpPost]
        public ActionResult Edit(SanPhamm phamm,int id, HttpPostedFileBase HinhAnh)
        {
            CompanyDBContext db = new CompanyDBContext();
            SanPhamm sanPhamm = db.SanPhamm.Where(row => row.IdSP == id).FirstOrDefault();
            sanPhamm.NameSP = phamm.NameSP;
            sanPhamm.IdTH = phamm.IdTH;
            sanPhamm.GiaCu = phamm.GiaCu;
            sanPhamm.GiaMoi = phamm.GiaMoi;
            if (ModelState.IsValid)
            {
                db = new CompanyDBContext();
                if (HinhAnh != null && HinhAnh.ContentLength > 0)
                {
                    if (HinhAnh.ContentLength > 2000000)
                    {
                        ModelState.AddModelError("Anh", "Kích thước file phải nhỏ hơn 2MB.");
                        return View();
                    }

                    var allowEx = new[] { ".jpg", ".png" };
                    var fileEx = Path.GetExtension(HinhAnh.FileName).ToLower();
                    if (!allowEx.Contains(fileEx))
                    {
                        ModelState.AddModelError("Anh", "Chỉ chấp nhận file ảnh jpg hoặc png.");
                        return View();
                    }

                    sanPhamm.HinhAnh = "";


                    db.SaveChanges();

                    SanPhamm pro = db.SanPhamm.ToList().Last();

                    var fileName = pro.IdSP.ToString() + "_1" + fileEx;
                    var path = Path.Combine(Server.MapPath("~/img"), fileName);
                    HinhAnh.SaveAs(path);

                    string link = "/img/" + fileName;
                    pro.HinhAnh = link;
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }

        }
        public ActionResult Delete(int id)
        {
            CompanyDBContext db = new CompanyDBContext();
            SanPhamm sanPhamm = db.SanPhamm.Where(row => row.IdSP == id).FirstOrDefault();
            return View(sanPhamm);
        }
        [HttpPost]
        public ActionResult Delete(int id, SanPhamm s)
        {
            CompanyDBContext db = new CompanyDBContext();
            SanPhamm sanPhamm = db.SanPhamm.Where(row => row.IdSP == id).FirstOrDefault();
            db.SanPhamm.Remove(sanPhamm);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}