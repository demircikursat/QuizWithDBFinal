﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.MODEL.Entities
{
    public class Score : BaseEntity
    {
        
        
        public int ScoreValue { get; set; }

        public virtual List<AppUserScore> AppUserScores { get; set; }
    } 
    
}
