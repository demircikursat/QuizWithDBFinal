using Project.BLL.DesignPatterns.RepositoryPattern.ConcRep;
using Project.MODEL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace QuizWithDBUI.Controllers
{
    public class HomeController : Controller
    {
        QuestionRepository qRep;
        AppUserRepository aRep;
        public HomeController()
        {
            qRep = new QuestionRepository();
            aRep = new AppUserRepository();
        }
        // GET: Home
        public ActionResult Quiz()
        {
            AppUser kullanici = Session["girisyapan"] as AppUser;
            if (kullanici.Score!=null)
            {
                ViewBag.testcozuldu = "Daha önce testi cozdunuz.";
            }
            
            return View(qRep.GetAll());
        }

        [HttpPost]

        public ActionResult Quiz(int skor)
        {
            try
            {
                AppUser kullanici = Session["girisyapan"] as AppUser;


                kullanici.Score = skor;
                aRep.Update(kullanici);
                





                return Json(new { result = 1, puan = skor, ok = false, newurl = Url.Action("Login", "Home") });

            }
            catch (Exception)
            {
                return Json(new { result = 0 });

            }


        }

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(AppUser item)
        {
            AppUser girisyapan = aRep.Default(x => x.AppUserName == item.AppUserName);
            Session["girisyapan"] = girisyapan;
            return RedirectToAction("AraView");
            //if (Session["girisyapan"] != null && girisyapan.Score == null)
            //{

            //    return RedirectToAction("Quiz");
            //}
            //else if (Session["girisyapan"] != null && girisyapan.Score != null)
            //{
            //    ViewBag.TestCozuldu = "Daha önce testi çözdünüz.";
               

            //}
            //else
            //{
            //    ViewBag.KullaniciYok = "KullaniciBulunamadi";

            //}

            //return View();

        }
        
        public ActionResult AraView()
        {
            AppUser kullanici = Session["girisyapan"] as AppUser;
            
            return View(kullanici);    
        }

        public ActionResult LogOut()
        {
            Session.Clear();
            return RedirectToAction("Login");
        }

       

        public ActionResult Snake()
        {
            return View();
        }

        [HttpPost]

        public ActionResult Snake(int skor2)
        {
            try
            {
                AppUser kullanici = Session["girisyapan"] as AppUser;
                kullanici.SnakeScore = skor2;
              
                aRep.Update(kullanici);
                
                return Json(new { result = 1, puan = skor2 });
            }
            catch (Exception)
            {

                return Json(new { result = 0 });
            }
           
        }
    }
}