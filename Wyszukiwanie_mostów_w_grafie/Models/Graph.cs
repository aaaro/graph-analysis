using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
        public override string ToString()
        {
            string zwrot = "";
            foreach(var item in Vertices)
            {
                zwrot += item.ToString() + Environment.NewLine;
            }
            return zwrot;
        }
        public Edge GetEdge(Vertex v1, Vertex v2)
        {
            foreach(var item in Edges)
            {
                if((v1 == item.v1 && v2 == item.v2)|| (v1 == item.v2 && v2 == item.v1))
                {
                    return item;
                }
            }
            return null;
        }
    }
}
