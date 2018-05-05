using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Wyszukiwanie_mostów_w_grafie
{
    class Graph
    {
        public List<Vertex> Vertices;  //Lista wierzchołków grafu
        public List<Edge> Edges;  //Lista krawędzi grafu

        public Graph()
        {
            Vertices = new List<Vertex>();
            Edges = new List<Edge>();
        }
        /*public void Remove(Vertex v)
        {
            Vertices.Remove(v);
            for(int i = 0; i < Edges.Count; i++)
            {
                if(Edges[i].v1 == v || Edges[i].v2 == v)
                {
                    Edges.Remove(Edges[i]);
                }
            }
        }*/
    }
}
