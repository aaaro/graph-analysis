using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wyszukiwanie_mostów_w_grafie.Models
{
    class Edge
    {
        Vertex u;
        Vertex v;
        bool directed;

        public Edge(Vertex u, Vertex v, bool directed)
        {
            this.u = u;
            this.v = v;
            this.directed = directed;
        }
    }
}
