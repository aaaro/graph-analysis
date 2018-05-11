﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Wyszukiwanie_mostów_w_grafie
{
    public class Vertex : Canvas
    {
        public double srednica = 50;
        public int id;
        static int count = 0; //licznik wierzchołków
        public Ellipse ellipse { get; set; } //rysowana elipsa
        public TextBox textBox { get; set; } //rysowany numer wierzchołka

        public List<Vertex> Neighbours; //Lista sąsiadujących wierzchołków

        public Vertex()
        {
            //Deklaracje
            count++;
            id = count;
            ellipse = new Ellipse();
            textBox = new TextBox();
            Neighbours = new List<Vertex>();
            //canvas
            Width = srednica;
            Height = srednica;
            //elipsa
            ellipse.Width = srednica;
            ellipse.Height = srednica;
            ellipse.Fill = Brushes.White;
            ellipse.Stroke = Brushes.Black;
            ellipse.StrokeThickness = 2;
            Children.Add(ellipse);
            //textbox
            textBox.Width = srednica;
            textBox.Height = srednica;
            textBox.Background = Brushes.Transparent;
            textBox.BorderThickness = new Thickness(0, 0, 0, 0);
            textBox.Text = Convert.ToString(count);
            textBox.FontSize = 30;
            textBox.TextAlignment = TextAlignment.Center;
            textBox.Padding = new Thickness(0, 3, 0, 0);
            textBox.IsReadOnly = true;
            textBox.Cursor = Cursors.Pen;
            textBox.IsHitTestVisible = false;
            Children.Add(textBox);          
        }
        public override string ToString()
        {
            string neighbours = "";
            foreach(var item in Neighbours)
            {
                neighbours += " {" + item.id + "},";
            }
            return id + ": " + neighbours;
        }
    }
}
