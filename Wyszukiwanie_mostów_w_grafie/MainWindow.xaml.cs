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
        Queue<int> skasowaneWierchulki = new Queue<int>();

        public MainWindow()
        {
            InitializeComponent();
        }
        public void DrawSpace_MouseLeftButtonDown(object sender, MouseButtonEventArgs e) //LEWY
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
                Width = 50,
                Height = 50,
                Background = Brushes.Transparent,
                BorderThickness = new Thickness(0, 0, 0, 0),
                Text = Convert.ToString(n),
                FontSize = 30,
                TextAlignment = TextAlignment.Center,
                Padding = new Thickness(0, 3, 0, 0),
                IsReadOnly = true,
                Cursor = Cursors.Pen,
            };
            
            DrawSpace.Children.Add(square);
            DrawSpace.Children.Add(number);
            Canvas.SetLeft(square, e.GetPosition(DrawSpace).X - 25);
            Canvas.SetTop(square, e.GetPosition(DrawSpace).Y - 25);
            Canvas.SetLeft(number, e.GetPosition(DrawSpace).X - 25);
            Canvas.SetTop(number, e.GetPosition(DrawSpace).Y - 25);
        }


        // tam na dole działa, ale słabo
        // nie da się kliknąć na objekt, więc może dodatkowy Canvas na górze, przezroczysty?
        // @up. Jeśli kliknę na objekt (np textbox) to nie klikam na canvas, więc nie łapie MouseRightClick
        // foreach wywala po zmieanie zawartości DrawSpace.Children, trzeba for i panować nad 'i'
        // obecny kod kasuje pojedynczo, jeśli kliknie się prawym trochę wyżej lub niżej. I działa, ale nie każdy klik łapie, co jest zjebane, zobaczyć
        // potencjał jest, ale wymaga przesiedzenia

        public void DrawSpace_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        { }// pusta metoda żeby nie wywalało, bo Canvas ma zadeklarowany RightClick. Do wyjebania przy pracy

        /*

        public void DrawSpace_MouseRightButtonDown(object sender, MouseButtonEventArgs e) //PRAWY
        {
            double kursorX = e.GetPosition(DrawSpace).X;
            double kursorY = e.GetPosition(DrawSpace).Y;

            ZnajdzWierchulki(kursorX, kursorY);
        }
        public void ZnajdzWierchulki(double x, double y)
        {
            double top = y + 70;
            double bot = y - 70;
            double left = x - 25;
            double right = x + 25;

            foreach (UIElement item in DrawSpace.Children)
            {
                double objX = Canvas.GetLeft(item);
                double objY = Canvas.GetTop(item);

                if (objX > left && objX < right && objY > bot && objY < top)
                {
                    DrawSpace.Children.Remove(item);
                    break;

                }
            }
        }
        */


    }
}
