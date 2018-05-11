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

        public void FindBridges()
        {
            foreach (var edge in Edges)
            {
                int v1 = edge.v1.id;
                int v2 = edge.v2.id;
                int visitedVertices = BFS(1, v1, v2);
                if(visitedVertices != Vertices.Count)
                {
                    edge.SetAsBridge();
                }
            }
        }
        public int BFS(int s, int v1, int v2)
        {
            bool[] visited = new bool[Vertices.Count+1];
            Queue<int> q = new Queue<int>();
            int counter = 0;
            visited[s] = true;
            ++counter;
            q.Enqueue(s);

            while(q.Count > 0)
            {
                s = q.Dequeue();
                foreach (var vertex in Vertices.Find(v => v.id == s).Neighbours)
                {
                    if (s == v1 && vertex.id == v2 )
                        continue;
                    if(!visited[vertex.id])
                    {
                        visited[vertex.id] = true;
                        q.Enqueue(vertex.id);
                        ++counter;
                    }
                }
            }
            return counter;
        }
    }
}
