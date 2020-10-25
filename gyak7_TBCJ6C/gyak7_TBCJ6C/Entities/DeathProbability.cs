using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gyak7_TBCJ6C.Entities
{
    class DeathProbability
    {
        public Gender gender { get; set; }
        public Gender Gender { get; internal set; }
        public int Age { get; set; }
        public double DeathProbabilitiess { get; set; }
        
    }
}
