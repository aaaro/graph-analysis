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
        public MainWindow()
        {
            InitializeComponent();
        }
        //Wciśnięcie lewego przycisku myszy na canvasie
        public void DrawSpace_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Vertex w = new Vertex();
            //Dodanie do klasy Vertex eventu MouseRightButtonDown
            w.MouseRightButtonDown += W_MouseRightButtonDown;
            DrawSpace.Children.Add(w);
            Canvas.SetLeft(w, e.GetPosition(DrawSpace).X - 25);
            Canvas.SetTop(w, e.GetPosition(DrawSpace).Y - 25);
        }

        //Wciśnięcie prawego przycisku myszy na narysowanym wierzchołku
        private void W_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            Canvas c = sender as Canvas;
            DrawSpace.Children.Remove(c);
        }
    }
}
