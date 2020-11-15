using gyak8_TBCJ6C.Abstractions;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gyak8_TBCJ6C.Entities
{
    public class Present : Toy
    {
        public Color ribbonColor { get; set; }
        public Color boxColor { get; set; }
        protected override void DrawImage(Graphics g)
        {
            throw new NotImplementedException();
        }
    }
}
