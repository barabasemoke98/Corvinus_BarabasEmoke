using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using gyak8_TBCJ6C.Entities;

namespace gyak8_TBCJ6C.Abstractions
{
    public interface IToyFactory
    {
        Toy CreateNew();
    }
}
