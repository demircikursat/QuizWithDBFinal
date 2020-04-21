using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.MODEL.Entities
{
    public class AppUser : BaseEntity
    {
        public string AppUserName { get; set; }
        public int QuizCozuldu { get; set; }
        public virtual List<AppUserScore> AppUserScores { get; set; }


    }
}
