using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wyszukiwanie_mostów_w_grafie.Models
{
    class Verticle
    {
        Vertex u;
        Vertex v;
        bool directed;

        public Verticle(Vertex u, Vertex v, bool directed)
        {
            this.u = u;
            this.v = v;
            this.directed = directed;
        }
    }
}
