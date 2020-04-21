using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.MODEL.Entities
{
    public class AppUserScore:BaseEntity
    {

        public string Game { get; set; }
        public int AppUserID { get; set; }
        public int ScoreID { get; set; }
       
        public virtual AppUser AppUser { get; set; }
        public virtual Score Score { get; set; }

       
    }
}
