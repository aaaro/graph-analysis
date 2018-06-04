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
        public int NumberOfConsistentComponents()
        {
            Stack<int> S = new Stack<int>();
            int n = Vertices.Count;
            bool[] visited = new bool[n+1];
            int consistentComponents = 0;
            for (int i = 1; i <= n; i++)
            {
                if (visited[i])
                    continue;
                consistentComponents++;
                S.Push(i);
                visited[i] = true;
                while (S.Count > 0)
                {
                    int v = S.Pop();
                    foreach (var vertex in Vertices.Find(w => w.id == v).Neighbours)
                    {
                        if (visited[vertex.id])
                            continue;
                        S.Push(vertex.id);
                        visited[vertex.id] = true;
                    }
                }
            }
            return consistentComponents;
        }
        public int NumberOfConsistentComponents(int v1, int v2)
        {
            Stack<int> S = new Stack<int>();
            int n = Vertices.Count;
            bool[] visited = new bool[n + 1];
            int consistentComponents = 0;
            for (int i = 1; i <= n; i++)
            {
                if (visited[i])
                    continue;
                consistentComponents++;
                S.Push(i);
                visited[i] = true;
                while (S.Count > 0)
                {
                    int v = S.Pop();
                    foreach (var vertex in Vertices.Find(w => w.id == v).Neighbours)
                    {
                        if ((v == v1 && vertex.id == v2) || (v == v2 && vertex.id == v1))
                            continue;
                        if (visited[vertex.id])
                            continue;
                        S.Push(vertex.id);
                        visited[vertex.id] = true;
                    }
                }
            }
            return consistentComponents;
        }

        public void FindBridges()
        {
            ResetBridges();
            int consistentComponenets = NumberOfConsistentComponents();
            int n = Vertices.Count;
            for (int i = 1; i <= n; i++)
            {
                int v1 = i;
                foreach (var vertex in Vertices.Find(w => w.id == i).Neighbours)
                {
                    int v2 = vertex.id;
                    if (vertex.id < i)
                        continue;
                    if(NumberOfConsistentComponents(v1,v2) > consistentComponenets)
                        Edges.Find(e => (e.v1.id == v1 && e.v2.id == v2) || (e.v1.id == v2 && e.v2.id == v1)).Line.Stroke = Brushes.Red;
                }
            }
        }
        public void ResetBridges()
        {
            foreach (var edge in Edges)
            {
                edge.Line.Stroke = Brushes.Black;
            }
        }
    }
}
