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
        
        ScoreRepository sRep;
        AppUserScoreRepository asRep;
        public HomeController()
        {

            qRep = new QuestionRepository();
            aRep = new AppUserRepository();
            
            sRep = new ScoreRepository();
            asRep = new AppUserScoreRepository();
        }
        // GET: Home
        public ActionResult Quiz()
        {

            AppUserScore kullaniciScore = new AppUserScore();
            kullaniciScore.AppUser = Session["girisyapan"] as AppUser;

            if (kullaniciScore.Score != null)
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
                AppUserScore kullaniciScore = new AppUserScore();
                kullaniciScore.AppUser = Session["girisyapan"] as AppUser;
                kullaniciScore.Game = "Quiz";
                kullaniciScore.Score = new Score();
                kullaniciScore.Score.ScoreValue = skor;
                kullaniciScore.AppUser.QuizCozuldu = 1;




                asRep.Add(kullaniciScore);


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
            AppUser kullanici = Session["girisyapan"] as AppUser;
            return View(kullanici);
        }

        [HttpPost]

        public ActionResult Snake(int skor2)
        {
            //try
            //{
            AppUser kullanici = Session["girisyapan"] as AppUser;



            if (asRep.Any(x => x.AppUserID == kullanici.ID && x.Game == "Snake") == true)
            {
                
                AppUserScore varOlanKullaniciScore = asRep.Default(x => x.AppUserID == kullanici.ID && x.Game == "Snake");

                Score skor = sRep.Default(x => x.ID == varOlanKullaniciScore.ScoreID);
                if (skor2>skor.ScoreValue)
                {
                    skor.ScoreValue = skor2;
                    sRep.Update(skor);
                }
                else
                {
                    ViewBag.gec = "Daha önceki skorunuzu geçemediniz. Oyun kaydedilmedi.";
                }
                
                

            }
            else
            {
                AppUserScore kullaniciScore = new AppUserScore();
                kullaniciScore.AppUserID = kullanici.ID;

                Score score = new Score();
                score.ScoreValue = skor2;
                sRep.Add(score);

                kullaniciScore.ScoreID = score.ID;
                kullaniciScore.Game = "Snake";






                asRep.Add(kullaniciScore);
            }





            return Json(new { result = 1, puan = skor2 });
            //}
            //catch (Exception)
            //{

            //    return Json(new { result = 0 });
            //}

        }

        public PartialViewResult OyunScorGoster(string gameName)
        {



            return PartialView("_OyunScorGoster", asRep.ScoreListele(gameName));
        }
    }
}