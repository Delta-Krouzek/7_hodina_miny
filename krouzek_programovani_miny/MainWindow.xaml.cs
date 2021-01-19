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

namespace krouzek_programovani_miny
{
    /// <summary>
    /// Interakční logika pro MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public static int width = 5, height = 5, mines = 5;
        Game hra;


        public MainWindow()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            if (width * height >= mines)
            {
                hra = new Game();
                hra.Closing += Hra_Closing;
                hra.Show();
                IsEnabled = false;
            }
            else
            {
                slider3.Value = width * height;
            }
        }

        private void Hra_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            IsEnabled = true;
        }

        private void slider1_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (label1 == null)
            {
                return;
            }
            width = Convert.ToInt32(slider1.Value);
            label1.Content = width;
        }

        private void slider2_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (label2 == null)
            {
                return;
            }
            height = Convert.ToInt32(slider2.Value);
            label2.Content = height;
        }

        private void slider3_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (label3 == null)
            {
                return;
            }
            mines = Convert.ToInt32(slider3.Value);
            label3.Content = mines;
        }
    }
}
