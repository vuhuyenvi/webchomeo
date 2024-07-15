using _2001216311_VuThiHuyenVi_DoAn.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _2001216311_VuThiHuyenVi_DoAn.Areas.Admin.Controllers
{
    public class AdminTaiKhoanController : Controller
    {
        // GET: Admin/AdminTaiKhoan
        public ActionResult Index()
        {
            CompanyDBContext db = new CompanyDBContext();
            List<User> us = db.User.ToList();
            return View(us);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(User s)
        {
            CompanyDBContext db = new CompanyDBContext();
            db.User.Add(s);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int id)
        {
            CompanyDBContext db = new CompanyDBContext();
            User user = db.User.Where(row => row.UserId == id).FirstOrDefault();
            return View(user);
        }
        [HttpPost]
        public ActionResult Edit(User s)
        {
            CompanyDBContext db = new CompanyDBContext();
            User user = db.User.Where(row => row.UserId == s.UserId).FirstOrDefault();
            user.UserName = s.UserName;
            user.Password = s.Password;
            user.EmailAddress = s.EmailAddress;
            user.Role = s.Role;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            CompanyDBContext db = new CompanyDBContext();
            User user = db.User.Where(row => row.UserId == id).FirstOrDefault();
            return View(user);
        }
        [HttpPost]
        public ActionResult Delete(int id, User s)
        {
            CompanyDBContext db = new CompanyDBContext();
            User user = db.User.Where(row => row.UserId == id).FirstOrDefault();
            db.User.Remove(user);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}