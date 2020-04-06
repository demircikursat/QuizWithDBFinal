using Project.DAL.Context;
using Project.MODEL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.StrategyPattern
{
    public class MyInit : CreateDatabaseIfNotExists<QuizContext>
    {
        protected override void Seed(QuizContext context)
        {

            //ANSWERS

            string[,] answers = new string[5, 4];
            answers[0, 0] = "Oturmaktan canı sıkılmış, yalnızlıktan patlamış, hacking yapmayı marifet bilen asosyal ergenler+False";
            answers[0, 1] = "Kişileri ve kurumları hacklemeyi bir yarış haline getirmiş bilgisayardan iyi anlayan tipler+False";
            answers[0, 2] = "Kişileri ve kurumları hackleyerek gelir elde eden büyük organizasyonlar+False";
            answers[0, 3] = "Yukarıdakilerin tamamı+True";

            answers[1, 0] = "Virüs tarayımızın ve şirket firewall’umuzun gerekli güvenliği sağladığından emin bir şekilde bilgisayarımı kullanmaya devam ederim.+False";
            answers[1, 1] = "Bilgisayarımda full virus tarama çalıştırırım, sonra da yeni bir update vardır belki diye bilgisayarımı yeniden başlatırım.+False";
            answers[1, 2] = "IT ekibi veya Risk departmanı ile iletişime geçerim.+True";
            answers[1, 3] = "Bilgisayarım iyiye mi yoksa kötüye mi gidiyor diye bir süre izlemeye karar veririm.+False";

            answers[2, 0] = "Çokça banka transferi yapan bankalar ve finans kurumları.+False";
            answers[2, 1] = "Herhangi biri veya herhangi bir organizasyon.+True";
            answers[2, 2] = "Çokça önemli bilgi barındıran şirketler.+False";
            answers[2, 3] = "Müşterilerin kredi kartı bilgilerini kaydeden şirketler.+False";

            answers[3, 0] = "Kötü yazım dili ve imla hataları dolandırıcılık maili olduğunu gösterir.+False";
            answers[3, 1] = "E-mail gönderici adresini kontrol etmek yeterlidir.+False";
            answers[3, 2] = "E-mail içindeki logoların ve imajların kalitesinden kolayca anlaşılabilir.+False";
            answers[3, 3] = "Gönderici ile iletişime geçip böyle bir e-mail gönderip göndermediklerini öğrenmek gerekir.+True";

            answers[4, 0] = "Tandığımız birinden geliyorsa zaten link güvenlidir, açabilirim.+False";
            answers[4, 1] = "Güvenli olmayan bir link şirket güvenlik kurallarından zaten geçemez, bu yüzden güvenlidir, açabilirim.+False";
            answers[4, 2] = "Göndericiye e-mailini reply-back yaparak linkin güvenli olup olmadığını sorarım.+True";
            answers[4, 3] = "Linki açmadan ve e-maili reply-back yapmadan doğrulama için göndericiyi ararım.+False";

            //QUESTIONS

            string[] questions = new string[5];
            questions[0] = "Aşağıdakilerden hangisi günümüz hacker’ını en iyi tarif eder?";
            questions[1] = "Şüpheli bir e-mail’deki bir linke tıkladınız ve bilgisayarınızın bu andan itibaren farklı davrandığını hissediyorsunuz. Bu durumda ne yaparsınız?";
            questions[2] = "Günümüz modern hackerlarının asıl hedefi kimlerdir?";
            questions[3] = "Gerçek bir e-mail ile bir dolandırıcılık (phishing) e-mail’ini en iyi nasıl ayırt edebiliriz?";
            questions[4] = "Bir iş ortağı gönderdiği e-mail’deki bir linki hızlıca açmamızı istiyor. Bu durumda en güvenli adım ne olmalı?";






            for (int i = 0; i < questions.Length; i++)
            {
                Question soru = new Question();
                soru.QuestionItem = questions[i];


                context.Question.Add(soru);
                context.SaveChanges();

                for (int a = 0; a < 4; a++)
                {

                    List<string> sikkinKendisi = answers[i, a].Split('+').ToList();

                    Option o = new Option();

                    o.QuestionID = soru.ID;

                    o.OptionItem = sikkinKendisi[0];

                    if (sikkinKendisi[1] == "True")
                    {
                        o.IsItTrue = true;
                    }
                    else
                    {
                        o.IsItTrue = false;
                    }

                    context.Option.Add(o);
                    context.SaveChanges();







                }





            }

            AppUser a1 = new AppUser
            {
                AppUserName = "demircikursat"
            };

            context.AppUser.Add(a1);
            context.SaveChanges();

            AppUser a2 = new AppUser
            {
                AppUserName = "kenanpeker"
            };
            context.AppUser.Add(a2);
            context.SaveChanges();










        }
    }
}