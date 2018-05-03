using System;
using System.Collections.Generic;
using System.Linq;
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
        int n = 0;
        public MainWindow()
        {
            InitializeComponent();
        }
        public void DrawSpace_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            n++;
            Ellipse square = new Ellipse
            {
                Width = 50,
                Height = 50,
                Fill = Brushes.White,
                Stroke = Brushes.Black,
                StrokeThickness = 2

            };
            TextBox number = new TextBox
            {

                Width = 40,
                Height = 40,
                Background = Brushes.Transparent,
                BorderThickness = new Thickness(0, 0, 0, 0),
                Text = Convert.ToString(n),
                FontSize = 30,
                TextAlignment = TextAlignment.Center
            };
            DrawSpace.Children.Add(square);
            DrawSpace.Children.Add(number);
            Canvas.SetLeft(square, e.GetPosition(DrawSpace).X - 25);
            Canvas.SetTop(square, e.GetPosition(DrawSpace).Y - 25);
            Canvas.SetLeft(number, e.GetPosition(DrawSpace).X - 20);
            Canvas.SetTop(number, e.GetPosition(DrawSpace).Y - 20);
        }
        
    }
}
