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

        public void FindBridges()
        {
            bool[] visitedGlobal = new bool[Vertices.Count + 1];
            foreach (var edge in Edges)
            {
                visitedGlobal = new bool[Vertices.Count + 1];
                visitedGlobal[0] = true;
                int visitedVertices = 0;
                edge.Line.Stroke = Brushes.Black;
                int v1 = edge.v1.id;
                int v2 = edge.v2.id;
                Console.WriteLine("Krawedz {0}-{1}", edge.v1.id, edge.v2.id);
                int visitedVerticesInSubgraph = BFS(1);
                //if graph is connected
                if(visitedVerticesInSubgraph == Vertices.Count)
                {
                    Console.WriteLine("Graf jest spójny", visitedVertices);
                    Console.WriteLine("Znaleziono {0} wierzcholkow w subgrafie", visitedVerticesInSubgraph);
                    visitedVertices = BFS(1, v1, v2, ref visitedGlobal);
                    Console.WriteLine("Odwiedzono {0} wierzcholkow w subgrafie", visitedVertices);
                    if(visitedVertices != Vertices.Count)
                        edge.Line.Stroke = Brushes.Red;
                } else //if graph is disconnected
                {
                    Console.WriteLine("graf nie spojny");
                    int nextFalse = 1;
                    while (visitedGlobal.Count(t => t == true) - 1 < Vertices.Count)
                    {
                        Console.WriteLine("petla while");
                        visitedVerticesInSubgraph = BFS(nextFalse);
                        Console.WriteLine("Znaleziono {0} wierzcholkow w subgrafie", visitedVerticesInSubgraph);
                        visitedVertices = BFS(nextFalse, v1, v2, ref visitedGlobal);
                        Console.WriteLine("Odwiedzono {0} wierzcholkow", visitedVertices);
                        if (visitedVertices != visitedVerticesInSubgraph)
                        {
                            edge.Line.Stroke = Brushes.Red;
                            break;
                        } else
                        {
                            nextFalse = Array.IndexOf(visitedGlobal, false)+1;
                            Console.WriteLine("nextfalse {0}",nextFalse);
                        }
                    }
                }
            }
            Console.WriteLine(visitedGlobal.Count(t => t == true));
        }
        public int BFS(int s, int v1, int v2, ref bool[] visitedGlobal)
        {
            bool[] visited = new bool[Vertices.Count+1];
            Queue<int> q = new Queue<int>();
            int counter = 0;
            visited[s] = true;
            visitedGlobal[s] = true;
            Console.WriteLine("odwiedzono wierzchołek 1");
            ++counter;
            q.Enqueue(s);

            while(q.Count > 0)
            {
                s = q.Dequeue();
                foreach (var vertex in Vertices.Find(v => v.id == s).Neighbours)
                {
                    if ((s == v1 && vertex.id == v2) || (s == v2 && vertex.id == v1))
                        continue;
                    if(!visited[vertex.id])
                    {
                        visited[vertex.id] = true;
                        visitedGlobal[vertex.id] = true;
                        Console.WriteLine("odwiedzono wierzchołek {0} ",vertex.id);
                        q.Enqueue(vertex.id);
                        ++counter;
                    }
                }
            }
            return counter;
        }
        public int BFS(int s)
        {
            bool[] visited = new bool[Vertices.Count + 1];
            Queue<int> q = new Queue<int>();
            int counter = 0;
            visited[s] = true;
            ++counter;
            q.Enqueue(s);

            while (q.Count > 0)
            {
                s = q.Dequeue();
                foreach (var vertex in Vertices.Find(v => v.id == s).Neighbours)
                {
                    if (!visited[vertex.id])
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
