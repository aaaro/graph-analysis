using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Wyszukiwanie_mostów_w_grafie
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //flagi do rozróżnienia, która akcja powinna odbywać się w danym momencie
        public static bool edgeFlag = false;
        public static bool vertexFlag = false;
        //wskaźnik pokazujący na ostatni wybrany wierzchołek (wykorzystywany w tworzeniu krawędzi)
        Vertex tmp;
        public MainWindow()
        {
            InitializeComponent();
        }
        //Wciśnięcie lewego przycisku myszy na canvasie
        public void DrawSpace_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (vertexFlag)
            {
                Vertex vertex = new Vertex();
                //Dodanie do klasy Vertex eventów związanych z myszką
                vertex.MouseRightButtonDown += vertex_MouseRightButtonDown;
                vertex.MouseLeftButtonDown += vertex_MouseLeftButtonDown;
                //Rysowanie i pozycjonowanie wierzchołka
                DrawSpace.Children.Add(vertex);
                Canvas.SetLeft(vertex, e.GetPosition(DrawSpace).X - 25);
                Canvas.SetTop(vertex, e.GetPosition(DrawSpace).Y - 25);
            }
        }
        //Wciśnięcie lewego przycisku myszy na narysowanym wierzchołku
        private void vertex_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if(edgeFlag)
            {
                Vertex v = sender as Vertex;
                //po wyborze pierwszego wierzchołka
                if (tmp == null)
                {
                    tmp = v;
                    v.textBox.Foreground = Brushes.Red;
                    v.ellipse.Stroke = Brushes.Red;
                }
                //po wyborze drugiego wierzchołka
                else
                {
                    //rysowanie linii pomiędzy środkami wierzchołków
                    tmp.textBox.Foreground = Brushes.Black;
                    tmp.ellipse.Stroke = Brushes.Black;
                    Line line = new Line();
                    line.X1 = Canvas.GetLeft(tmp) + 25;
                    line.Y1 = Canvas.GetTop(tmp) + 25;
                    line.X2 = Canvas.GetLeft(v) + 25;
                    line.Y2 = Canvas.GetTop(v) + 25;
                    line.Stroke = Brushes.Black;
                    line.StrokeThickness = 8;
                    line.MouseRightButtonDown += Line_MouseRightButtonDown;
                    
                    DrawSpace.Children.Add(line);
                    tmp = null;
                }
            }
        }
        //Wciśnięcie prawego przycisku myszy na narysowanej krawędzi
        private void Line_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            Line l = sender as Line;
            DrawSpace.Children.Remove(l);
        }

        //Wciśnięcie prawego przycisku myszy na narysowanym wierzchołku
        private void vertex_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            Canvas c = sender as Canvas;
            DrawSpace.Children.Remove(c);
        }
        //Obsługa przycisku do rysowania krawędzi
        private void AddEdge_Click(object sender, RoutedEventArgs e)
        {
            edgeFlag = true;
            vertexFlag = false;
        }
        //Obsługa przycisku do rysowania wierzchołków
        private void AddVertex_Click(object sender, RoutedEventArgs e)
        {
            edgeFlag = false;
            vertexFlag = true;
        }
    }
}
