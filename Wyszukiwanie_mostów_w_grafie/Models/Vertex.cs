using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wyszukiwanie_mostów_w_grafie.Models
{
    class Vertex
    {
        ushort value;
        public ushort Value { get { return value; } }

        public Vertex(ushort value)
        {
            this.value = value;
        }
    }
}
