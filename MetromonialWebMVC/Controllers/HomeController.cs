using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.Entity;
using MetromonialWebMVC.Models;

namespace MetromonialWebMVC.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }


        public ActionResult Services()
        {
            return View();
        }

        public ActionResult Team()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }
        public ActionResult Registration()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Registration(TblUser userData)
        {
            using (MatroMinialDTEntities entities = new MatroMinialDTEntities())
            {
                if (ModelState.IsValid)
                {
                    entities.TblUsers.Add(userData);
                    entities.SaveChanges();
                    Response.Write("<script>alert('Registration Sucessfully')</script>");
                    ModelState.Clear();
                }
            }
            return View(userData);
        }
        [HttpPost]
        public ActionResult Login(TblUser userData)
        {
            {
                using (MatroMinialDTEntities entities = new MatroMinialDTEntities())
                {
                    var obj = entities.TblUsers.Where(a => a.userName.Equals(userData.userName) && a.password.Equals(userData.password)).FirstOrDefault();
                    if (obj != null)
                    {
                        //Session["UserID"] = obj.UserId.ToString();
                        //Session["UserName"] = obj.email.ToString();
                        return RedirectToAction("Contact");
                    }
                }
            }
            return View(userData);
        }

    }
}