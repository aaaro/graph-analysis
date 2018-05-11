using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Wyszukiwanie_mostów_w_grafie
{
    class Edge : Canvas
    {
        public Vertex v1;
        public Vertex v2;
        Line line;
        public Brush Line { set { line.Stroke = value; } }

        public Edge(Vertex v1, Vertex v2)
        {
            this.v1 = v1;
            this.v2 = v2;
            //Rysowanie linii pomiędzy wierzchołkami

            //dodaj linię tylko jeśli jeszcze jej nie ma
            if (!v1.Neighbours.Contains(v2))
            {
                //dodanie sąsiadów do listy
                v1.Neighbours.Add(v2);
                v2.Neighbours.Add(v1);

                //i dopiero rysowanie linii
                line = new Line();
                line.X1 = GetLeft(v1) + (v1.srednica / 2);
                line.Y1 = GetTop(v1) + (v1.srednica / 2);
                line.X2 = GetLeft(v2) + (v1.srednica / 2);
                line.Y2 = GetTop(v2) + (v1.srednica / 2);
                line.Stroke = Brushes.Black;
                line.StrokeThickness = 8;

                //zmiana na współrzędne krawędzi wierzchołka, jeśli na siebie nie nachodzą. Jak nachodzą, to rysuje od środka
                if (Math.Abs(line.X1 - line.X2) > v1.srednica || Math.Abs(line.Y1 - line.Y2) > v1.srednica)
                {
                    double[] wspolrzedne = SzukajPrzeciec(line);
                    line.X1 = wspolrzedne[0];
                    line.Y1 = wspolrzedne[1];
                    line.X2 = wspolrzedne[2];
                    line.Y2 = wspolrzedne[3];
                }
                Children.Add(line);
            }
        }
        public override string ToString()
        {
            return "{" + v1.ToString() + v2.ToString() + "}";
        }

        //FUCK THAT SHIT DOWN THERE, TOO MUCH MATH

        //nie ma property lenght, nie ma łatwego sposobu żeby ostatnie 25px były transparent (jak któryś znajdzie, to zajebię)
        //liczymy współrzędne punktów łączących się linii z okręgiem wierchułka
        //układ równań (x - x1)^2 + (y - y1)^2 = (srednia/2)^2  <to równanie okręgu, potrzeba obu
        //             y = ax + b                               <to prosta, czyli linia
        //z tego wychodzi zajebiście skomplikowane równanie, efekt na dole

        //ogólna funkcja, zwraca nowe wierzchołki
        //tablicę [x1, y1, x2, y2]
        public double[] SzukajPrzeciec(Line l)
        {
            double[] WspolrzednePunktow = new double[4];
            //jeśli są dokładnie jeden nad drugim, czyli nie jest wykres funkcji, to sposób niżej nie działa
            if (l.X1 == l.X2)
            {
                WspolrzednePunktow[0] = l.X1;
                WspolrzednePunktow[2] = l.X2;

                if (l.Y1 > l.Y2)
                {
                    WspolrzednePunktow[1] = l.Y1 - (v1.srednica / 2);
                    WspolrzednePunktow[3] = l.Y2 + (v1.srednica / 2);
                }
                else
                {
                    WspolrzednePunktow[1] = l.Y1 + (v1.srednica / 2);
                    WspolrzednePunktow[3] = l.Y2 - (v1.srednica / 2);
                }

            }
            //dla wszystkich innych przypadków
            else
            {
                //y = ax + b, to są a i b z równania prostej
                double prostaA = (l.Y2 - l.Y1) / (l.X2 - l.X1);
                double prostaB = ((l.Y1 * l.X2) - (l.X1 * l.Y2)) / (l.X2 - l.X1);
                //a to a, b i c z równania, które wyszło ostatecznie dla obszaru X1 Y1
                double rownanieA = Math.Pow(prostaA, 2) + 1;
                double rownanieB1 = (-2 * l.X1) + (2 * prostaA * prostaB) - (2 * prostaA * l.Y1);
                double rownanieC1 = Math.Pow(l.X1, 2) - (2 * prostaB * l.Y1) + Math.Pow(prostaB, 2) + Math.Pow(l.Y1, 2) - Math.Pow(v1.srednica / 2, 2);
                //dla obszaru X2 Y2
                double rownanieB2 = (-2 * l.X2) + (2 * prostaA * prostaB) - (2 * prostaA * l.Y2);
                double rownanieC2 = Math.Pow(l.X2, 2) - (2 * prostaB * l.Y2) + Math.Pow(prostaB, 2) + Math.Pow(l.Y2, 2) - Math.Pow(v1.srednica / 2, 2);
                //delta i pierwiastek
                double pierwDelty1 = PierwDelty(rownanieA, rownanieB1, rownanieC1);
                double pierwDelty2 = PierwDelty(rownanieA, rownanieB2, rownanieC2);
                //odpowiedni x, czyli punkt szukany. Oba punkty dla obu okręgów
                double rozwiazanieX1 = rozwiazanieX(rownanieA, rownanieB1, pierwDelty1, line);
                double rozwiazanieX2 = rozwiazanieX(rownanieA, rownanieB2, pierwDelty2, line);
                //z tego współrzędna y do tych punktów
                double rozwiazanieY1 = (prostaA * rozwiazanieX1) + prostaB;
                double rozwiazanieY2 = (prostaA * rozwiazanieX2) + prostaB;

                WspolrzednePunktow[0] = rozwiazanieX1;
                WspolrzednePunktow[1] = rozwiazanieY1;
                WspolrzednePunktow[2] = rozwiazanieX2;
                WspolrzednePunktow[3] = rozwiazanieY2;
            }

            return WspolrzednePunktow;
        }
        public double PierwDelty(double a, double b, double c)
        {
            double delta = Math.Pow(b, 2) - (4 * a * c);
            return Math.Sqrt(delta);
        }
        public double rozwiazanieX(double a, double b, double pierwDelty, Line l)
        {
            double rozw = (-b - pierwDelty) / (2 * a);
            //są dwa rozwiązania, potrzebujemy tego, które jest pomiędzy środkami
            if (rozw > l.X1 && rozw < l.X2 || rozw < l.X1 && rozw > l.X2)
                return rozw;
            else
                rozw = (-b + pierwDelty) / (2 * a);

            return rozw;
        }
    }
}
