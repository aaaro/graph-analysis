using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace Interfejs
{
    public partial class Form1 : Form
    {
        //class for right-click menu ability 
        public class MyContextMenu : ContextMenu
        {
            public MyContextMenu()
            {
                var item = MenuItems.Add("Delete");
                item.Click += RemoveVertex;
            }
            public void RemoveVertex(object sender, EventArgs e)
            {
                g.RemoveVertex(SourceControl as Vertex);
                SourceControl.Dispose();
            }
        }
        public static Graph g;
        public static Vertex toLink;
        public static Point toLinkPos;
        public static Graphics graphic;
        public class Graph
        {
            public List<Vertex> VertexList;
            public List<Edge> EdgeList;
            public Graph()
            {
                VertexList = new List<Vertex>();
                EdgeList = new List<Edge>();
            }
            public void AddVertex(Vertex v)
            {
                VertexList.Add(v);
            }
            public void AddVertex(Point p)
            {
                Vertex v = new Vertex(p);
                VertexList.Add(v);
            }
            public void RemoveVertex(Vertex v)
            {
                VertexList.Remove(v);
                List<Edge> delete = new List<Edge>();
                for(int i = 0; i < EdgeList.Count; i++)
                {
                    Edge e = EdgeList[i];
                    if(e.v1 == v || e.v2 == v)
                    {
                        delete.Add(e);
                    }
                }
                foreach(var item in delete)
                {
                    EdgeList.Remove(item);
                    graphic.DrawLine(new Pen(Color.White, 5), item.v1.Position, item.v2.Position);
                }
            }
            public void AddEdge(Edge e)
            {
                EdgeList.Add(e);
            }
            public void WriteVertices()
            {
                foreach(var item in VertexList)
                    Console.WriteLine(item);
            }
            public void WriteEdges()
            {
                foreach(var item in EdgeList)
                    Console.WriteLine(item);
            }
            public int[,] ToMatrix()
            {
                int n = Convert.ToInt32(VertexList[VertexList.Count - 1].Text);
                int[,] matrix = new int[n, n];
                foreach(var edge in EdgeList)
                {
                    matrix[Convert.ToInt32(edge.v1.Text) - 1, Convert.ToInt32(edge.v2.Text) - 1]++;
                    matrix[Convert.ToInt32(edge.v2.Text) - 1, Convert.ToInt32(edge.v1.Text) - 1]++;
                }
                return matrix;
            }
            public void Explore(Vertex start)
            {
                // DFS algorithm here
               

            }
        }
        //Edge class made of 2 Vertices
        public class Edge
        {
            public Vertex v1, v2;
            public Edge(Vertex v1, Vertex v2)
            {
                this.v1 = v1;
                this.v2 = v2;
            }
            public void DrawEdge()
            {
                Pen pen = new Pen(Color.Black,5);
                graphic.DrawLine(pen, v1.Position, v2.Position);
            }
            public override string ToString()
            {
                return "(" + v1 + ", " + v2 + ")";
            }
        }
        public class Vertex : Label
        {
            public static int vertexCount = 0;
            bool visited, post;
            public Point Position;
            public override string ToString()
            {
                return Text;
            }
            public Vertex(Point p)
            {
                ContextMenu = new MyContextMenu();
                vertexCount++;
                Top = p.Y;
                Left = p.X;
                Size = new Size(20, 25);
                Font = new Font(FontFamily.GenericSansSerif, 14);
                BackColor = Color.Red;
                Text = vertexCount.ToString();
                Visible = true;
                Click += CreateEdge;
                Position = new Point(p.X + 10, p.Y + 12);
                visited = false;
                post = false;
            }
            public void CreateEdge(object sender, EventArgs e)
            {
                MouseEventArgs me = e as MouseEventArgs;
                if (me.Button == MouseButtons.Left)
                {
                    Vertex v = sender as Vertex;
                    Vertex link;
                    Point linkPos;
                    if (toLink == null)
                    {
                        toLink = v;
                        toLinkPos = new Point(toLink.Left + (toLink.Size.Width / 2), toLink.Top + (toLink.Size.Height / 2));
                        //toLink = new Point(Left + (Size.Width / 2), Top + (Size.Height / 2));
                        BackColor = Color.LimeGreen;
                    }
                    else if (v == toLink)
                    {
                        toLink.BackColor = Color.Red;
                        toLink = null;
                    }
                    else
                    {
                        link = this;
                        linkPos = new Point(link.Left + (link.Size.Width / 2), link.Top + (link.Size.Height / 2));
                        //link = new Point(Left + (Size.Width / 2), Top + (Size.Height / 2));
                        Edge edge = new Edge(link, toLink);
                        edge.DrawEdge();
                        g.AddEdge(edge);
                        toLink.BackColor = Color.Red;
                        toLink = null;
                    }
                }
            }
        }
        public void AddVertex(Point p)
        {
            Vertex v = new Vertex(p);
            Controls.Add(v);
            g.AddVertex(v);
        }
        public Form1()
        {
            InitializeComponent();
            g = new Graph();
            graphic = CreateGraphics();
            toLink = null;        
        }

        private void Form1_DoubleClick(object sender, EventArgs e)
        {
            MouseEventArgs me = e as MouseEventArgs;
            if (me.Button == MouseButtons.Left)
            {
                AddVertex(PointToClient(new Point(MousePosition.X - 10, MousePosition.Y - 12)));
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            graphic.Clear(Color.White);
            g.WriteVertices();
            g.WriteEdges();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //save to .txt file as a matrix
            string save = "";
            int[,] matrix = g.ToMatrix();
            for(int i = 0; i < matrix.GetLength(0); i++)
            {
                for(int j = 0; j < matrix.GetLength(0); j++)
                {
                    save += matrix[i, j];
                }
                save += Environment.NewLine;
            }

            saveGraph.Filter = "Text File|*.txt";
            saveGraph.ShowDialog();
            string path = saveGraph.FileName;

            StreamWriter sw = new StreamWriter(path);
            sw.Write(save);
            sw.Close();
            
        }
    }
}
