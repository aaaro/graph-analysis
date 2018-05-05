using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Wyszukiwanie_mostów_w_grafie
{
    class Edge : Canvas
    {
        public Vertex v1;
        public Vertex v2;
        Line line;
        bool directed;
        public Edge(Vertex v1, Vertex v2, bool directed = false)
        {
            
            this.v1 = v1;
            this.v2 = v2;
            this.directed = directed;
            //Rysowanie linii pomiędzy wierzchołkami

            line = new Line();
            line.X1 = GetLeft(v1) + 25;
            line.Y1 = GetTop(v1) + 25;
            line.X2 = GetLeft(v2) + 25;
            line.Y2 = GetTop(v2) + 25;
            line.Stroke = Brushes.Black;
            line.StrokeThickness = 8;
            line.Margin = new Thickness(25);
            Children.Add(line);
        }
    }
}
