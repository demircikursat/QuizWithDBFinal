using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.MODEL.Entities
{
    public class Question : BaseEntity
    {

        public string QuestionItem { get; set; }



        //Relations

        public virtual List<Option> Options { get; set; }


    }
}
