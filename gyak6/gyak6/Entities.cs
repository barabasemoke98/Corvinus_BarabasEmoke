using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gyak6
{
    class Entities
    {
        public class RateData
        {
            public DateTime Date;
            public string Currency { get; set; }
            public decimal Value { get; set; }

        }
    }
}
