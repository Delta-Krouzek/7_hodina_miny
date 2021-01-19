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
        }

        private void Casovac_Tick(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
