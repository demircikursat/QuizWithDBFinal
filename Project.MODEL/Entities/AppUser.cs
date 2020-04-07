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
        public int? Score { get; set; }
        public int? SnakeScore { get; set; }


    }
}
