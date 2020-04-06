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
                Session.Clear();





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
            if (Session["girisyapan"] != null && girisyapan.Score == null)
            {

                return RedirectToAction("Quiz");
            }
            else if (Session["girisyapan"] != null && girisyapan.Score != null)
            {
                ViewBag.TestCozuldu = "Daha önce testi çözdünüz.";

            }
            else
            {
                ViewBag.KullaniciYok = "KullaniciBulunamadi";

            }

            return View();

        }
    }
}