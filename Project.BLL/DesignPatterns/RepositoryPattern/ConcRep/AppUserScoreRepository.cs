using Project.BLL.DesignPatterns.RepositoryPattern.BaseRep;
using Project.MODEL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.DesignPatterns.RepositoryPattern.ConcRep
{
    public class AppUserScoreRepository : BaseRepository<AppUserScore>
    {
        public List<AppUserScore> ScoreListele(string oyunAdi)
        {

            return db.AppUserScore.Where(x => x.Game == oyunAdi).OrderByDescending(x => x.Score.ScoreValue).ToList();
        }

        public void Update2(int id)
        { 
        

        }
    }
}
