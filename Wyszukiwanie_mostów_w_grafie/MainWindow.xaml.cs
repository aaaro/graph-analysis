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
        public bool edgeFlag;
        public bool directedFlag;
        public bool vertexFlag;
        public bool deleteFlag;

        //wskaźnik pokazujący na ostatni wybrany wierzchołek (wykorzystywany w tworzeniu krawędzi)
        Vertex tmp;
        //Objekt grafu
        Graph graph;
        //Konstruktor okna
        public MainWindow()
        {
            InitializeComponent();
            graph = new Graph();
            tmp = null;
            edgeFlag = false;
            directedFlag = false;
            vertexFlag = false;
            deleteFlag = false;
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
                //Dodanie wierzchołka do grafu
                graph.Vertices.Add(vertex);
            }
        }
        //Wciśnięcie lewego przycisku myszy na narysowanym wierzchołku
        private void vertex_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if(edgeFlag || directedFlag)
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
                else if(tmp != v)
                {
                    //rysowanie zwykłej linii pomiędzy środkami wierzchołków
                    tmp.textBox.Foreground = Brushes.Black;
                    tmp.ellipse.Stroke = Brushes.Black;

                    Edge edge;
                    if (directedFlag)
                        edge = new Edge(tmp, v);
                    else
                        edge = new Edge(tmp, v, true);
                    edge.MouseRightButtonDown += edge_MouseRightButtonDown;
                    edge.MouseLeftButtonDown += edge_MouseLeftButtonDown;
                   
                    DrawSpace.Children.Add(edge);

                    graph.Edges.Add(edge);
                    tmp = null;
                }
                else
                {
                    tmp.textBox.Foreground = Brushes.Black;
                    tmp.ellipse.Stroke = Brushes.Black;
                }
            }
            if(deleteFlag)
            {
                Vertex toDelete = sender as Vertex;
                graph.Remove(toDelete);
                DrawSpace.Children.Remove(toDelete);
            }
        }
        //Wciśnięcie prawego przycisku myszy na narysowanej krawędzi
        private void edge_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (deleteFlag)
            {
                Line l = sender as Line;
                DrawSpace.Children.Remove(l);
            }
        }
        //Wciśnięcie lewego przycisku myszy na narysowanej krawędzi
        private void edge_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (deleteFlag)
            {
                Line l = sender as Line;
                DrawSpace.Children.Remove(l);
            }
        }
        //Wciśnięcie prawego przycisku myszy na narysowanym wierzchołku
        private void vertex_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (deleteFlag)
            {
                Canvas c = sender as Canvas;
                DrawSpace.Children.Remove(c);
            }
        }
        //Obsługa przycisku do rysowania krawędzi
        private void AddEdge_Click(object sender, RoutedEventArgs e)
        {
            edgeFlag = true;
            vertexFlag = false;
            deleteFlag = false;
            directedFlag = false;
        }
        //Obsługa przycisku do rysowania wierzchołków
        private void AddVertex_Click(object sender, RoutedEventArgs e)
        {
            edgeFlag = false;
            vertexFlag = true;
            deleteFlag = false;
            directedFlag = false;
        }
        //Obsługa przycisku do usuwania elementów
        private void DeleteElements_Click(object sender, RoutedEventArgs e)
        {
            edgeFlag = false;
            vertexFlag = false;
            deleteFlag = true;
            directedFlag = false;
        }

        private void AddDirectedEdge_Click(object sender, RoutedEventArgs e)
        {
            edgeFlag = false;
            vertexFlag = false;
            deleteFlag = false;
            directedFlag = true;
        }
    }
}
