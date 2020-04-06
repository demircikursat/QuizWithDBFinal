using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.MODEL.Entities
{
    public class Option : BaseEntity
    {
        public string OptionItem { get; set; }
        public int QuestionID { get; set; }
        public bool IsItTrue { get; set; }
        //Relational
        public virtual Question Question { get; set; }
    }
}
