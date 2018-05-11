using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

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
        public Edge RemoveEdge(Edge e)
        {
            e.v1.Neighbours.Remove(e.v2);
            e.v2.Neighbours.Remove(e.v1);
            Edges.Remove(e);
            return e;
        }
        public void AddEdge(Edge e)
        {
            e.v1.Neighbours.Add(e.v2);
            e.v2.Neighbours.Add(e.v2);
            Edges.Add(e);
        }
        public void FindBridges()
        {
            foreach (var edge in Edges)
            {
                Edge tmpEdge = RemoveEdge(edge);
                int visitedVertices = BFS(1);
                if(visitedVertices != Vertices.Count)
                {
                    edge.Line = Brushes.Red;
                }
                AddEdge(tmpEdge);
            }
        }

        public int BFS(int s)
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
