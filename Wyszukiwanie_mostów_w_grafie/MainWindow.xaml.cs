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
                vertex.MouseLeftButtonDown += vertex_MouseLeftButtonDown;
                //Rysowanie i pozycjonowanie wierzchołka
                DrawSpace.Children.Add(vertex);
                Canvas.SetLeft(vertex, e.GetPosition(DrawSpace).X - (vertex.srednica/2));
                Canvas.SetTop(vertex, e.GetPosition(DrawSpace).Y - (vertex.srednica / 2));
                //Dodanie wierzchołka do grafu
                graph.Vertices.Add(vertex);
            }
        }
        //Wciśnięcie lewego przycisku myszy na narysowanym wierzchołku
        private void vertex_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            //przypadek rysowania krawędzi lub krawędzi skierowanej
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
                else if(tmp != v)
                {
                    //rysowanie zwykłej linii pomiędzy środkami wierzchołków
                    tmp.textBox.Foreground = Brushes.Black;
                    tmp.ellipse.Stroke = Brushes.Black;

                    Edge edge = new Edge(tmp, v);
                    edge.MouseLeftButtonDown += edge_MouseLeftButtonDown;
                   
                    DrawSpace.Children.Add(edge);

                    graph.Edges.Add(edge);
                    tmp = null;
                }
                else
                {
                    tmp.textBox.Foreground = Brushes.Black;
                    tmp.ellipse.Stroke = Brushes.Black;
                    tmp = null;
                }
            }
            //przypadek usuwania elementów
            if(deleteFlag)
            {
                Vertex toDelete = sender as Vertex;
                //usuwam z grafu i z rysunku wszystkie krawędzie podłączone do wierzchołka
                //skomplikowane usuwanie, bo nie można usuwać w czasie wykonywania pętli, bo ilość elementów się zmienia
                List<Edge> edgeToDelete = new List<Edge>();
                for(int i = 0; i < graph.Edges.Count; i++)
                {
                    if(graph.Edges[i].v1 == toDelete || graph.Edges[i].v2 == toDelete)
                    {
                        edgeToDelete.Add(graph.Edges[i]);
                    }
                }
                foreach(Edge item in edgeToDelete)
                {
                    graph.Edges.Remove(item);
                    DrawSpace.Children.Remove(item);
                }
                //usuwam z grafu i rysunku wierzchołek
                graph.Vertices.Remove(toDelete);
                DrawSpace.Children.Remove(toDelete);
            }
        }
        //Wciśnięcie lewego przycisku myszy na narysowanej krawędzi
        private void edge_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (deleteFlag)
            {
                Edge l = sender as Edge;
                l.v1.Neighbours.Remove(l.v2);
                l.v2.Neighbours.Remove(l.v1);

                graph.Edges.Remove(l);
                DrawSpace.Children.Remove(l);
            }
        }
        //Obsługa przycisku do rysowania krawędzi
        private void AddEdge_Click(object sender, RoutedEventArgs e)
        {
            edgeFlag = true;
            vertexFlag = false;
            deleteFlag = false;
            ChangeButtonColors();
        }
        //Obsługa przycisku do rysowania wierzchołków
        private void AddVertex_Click(object sender, RoutedEventArgs e)
        {
            edgeFlag = false;
            vertexFlag = true;
            deleteFlag = false;
            ChangeButtonColors();
        }
        //Obsługa przycisku do usuwania elementów
        private void DeleteElements_Click(object sender, RoutedEventArgs e)
        {
            edgeFlag = false;
            vertexFlag = false;
            deleteFlag = true;
            ChangeButtonColors();
        }
        private void ChangeButtonColors()
        {
            //powrót wszystkich przycisków do default
            AddVertex.ClearValue(BackgroundProperty);
            AddEdge.ClearValue(BackgroundProperty);
            DeleteElements.ClearValue(BackgroundProperty);

            //zmiana koloru odpowiedniego przycisku
            if (vertexFlag)
                AddVertex.Background = Brushes.LightGreen;
            if (edgeFlag)
                AddEdge.Background = Brushes.LightGreen;
            if (deleteFlag)
                DeleteElements.Background = Brushes.LightGreen;
        }
    }
}
