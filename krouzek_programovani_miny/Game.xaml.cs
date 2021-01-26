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
using System.Windows.Shapes;
using System.Windows.Threading;

namespace krouzek_programovani_miny
{
    /// <summary>
    /// Interakční logika pro Game.xaml
    /// </summary>
    public partial class Game : Window
    {

        int vyska, sirka;
        int[,] pole;
        int pocetMin;
        int najito, naklikl;
        DispatcherTimer casovac = new DispatcherTimer();

        Win vyhra;
        Over prohra;
        
        public Game()
        {
            InitializeComponent();

            vyska = MainWindow.height;
            sirka = MainWindow.width;
            pocetMin = MainWindow.mines;
            pole = new int[sirka, vyska];
            casovac.Interval = new TimeSpan(0, 0, 2);
            casovac.Tick += Casovac_Tick;

            Random nahoda = new Random();
            for (int i = 0; i < pocetMin; i++)
            {
                int nahodaX = nahoda.Next(0, sirka);
                int nahodaY = nahoda.Next(0, vyska);
                if (pole[nahodaX, nahodaY] == 0)
                {
                    pole[nahodaX, nahodaY] = 1;
                }
                else
                {
                    i--;
                }
            }

            for (int i = 0; i < vyska; i++)
            {
                RowDefinition rada = new RowDefinition();
                Mrizka.RowDefinitions.Add(rada);
            }

            for (int i = 0; i < sirka; i++)
            {
                ColumnDefinition sloupec = new ColumnDefinition();
                Mrizka.ColumnDefinitions.Add(sloupec);
            }

            for (int y = 0; y < vyska; y++)
            {
                for (int x = 0; x < sirka; x++)
                {
                    Rectangle rec = new Rectangle();
                    rec.Fill = new SolidColorBrush(Color.FromRgb(100, 100, 100));
                    rec.MouseLeftButtonDown += Rec_MouseLeftButtonDown;
                    rec.MouseRightButtonDown += Rec_MouseRightButtonDown;
                    rec.SetValue(Grid.RowProperty, y);
                    rec.SetValue(Grid.ColumnProperty, x);
                    Mrizka.Children.Add(rec);

                    Border ohraniceni = new Border();
                    ohraniceni.BorderBrush = Brushes.Black;
                    ohraniceni.BorderThickness = new Thickness(1);
                    ohraniceni.SetValue(Grid.RowProperty, y);
                    ohraniceni.SetValue(Grid.ColumnProperty, x);
                    Mrizka.Children.Add(ohraniceni);
                }
            }

        }

        private void Rec_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Rec_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Rectangle rec = (Rectangle)sender;
            int x = Convert.ToInt32(rec.GetValue(Grid.RowProperty));
            int y = Convert.ToInt32(rec.GetValue(Grid.ColumnProperty));

            if (Convert.ToString(rec.Fill) == "#FFFF00FF")
            {
                naklikl = naklikl - 1;
            }
            if (pole[y, x] == 1)
            {
                for (int i = 0; i < pole.GetLength(0); i++)
                {
                    for (int j = 0; j < pole.GetLength(1); j++)
                    {
                        if (pole[i, j] == 1)
                        {
                            Rectangle rec2 = new Rectangle();
                            rec2.Fill = new SolidColorBrush(Colors.Red);
                            rec2.SetValue(Grid.RowProperty, j);
                            rec2.SetValue(Grid.ColumnProperty, i);
                            Mrizka.Children.Add(rec2);
                        }
                    }
                }
                prohra = new Over();
                casovac.Start();
                prohra.ShowDialog();
            }
        }

        private void Casovac_Tick(object sender, EventArgs e)
        {
            Close();
            if (vyhra != null)
            {
                vyhra.Close();
            }
            if (prohra != null)
            {
                prohra.Close();
            }
        }
    }
}
