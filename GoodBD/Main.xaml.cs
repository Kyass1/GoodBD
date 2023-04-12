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

namespace GoodBD
{
    /// <summary>
    /// Логика взаимодействия для Main.xaml
    /// </summary>
    public partial class Main : Window
    {
        public Main()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Models qwe = new Models();
            qwe.Left = this.Left;
            qwe.Top = this.Top;
            this.Hide();
            qwe.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Seasons qwe = new Seasons();
            qwe.Left = this.Left;
            qwe.Top = this.Top;
            this.Hide();
            qwe.Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Countries qwe = new Countries();
            qwe.Left = this.Left;
            qwe.Top = this.Top;
            this.Hide();
            qwe.Show();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Providers qwe = new Providers();
            qwe.Left = this.Left;
            qwe.Top = this.Top;
            this.Hide();
            qwe.Show();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            Warehouses qwe = new Warehouses();
            qwe.Left = this.Left;
            qwe.Top = this.Top;
            this.Hide();
            qwe.Show();
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            Sneakers qwe = new Sneakers();
            qwe.Left = this.Left;
            qwe.Top = this.Top;
            this.Hide();
            qwe.Show();
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            Roles qwe = new Roles();
            qwe.Left = this.Left;
            qwe.Top = this.Top;
            this.Hide();
            qwe.Show();
        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            Users qwe = new Users();
            qwe.Left = this.Left;
            qwe.Top = this.Top;
            this.Hide();
            qwe.Show();
        }

        private void Button_Click_8(object sender, RoutedEventArgs e)
        {
            Hoodies qwe = new Hoodies();
            qwe.Left = this.Left;
            qwe.Top = this.Top;
            this.Hide();
            qwe.Show();
        }

        private void Button_Click_9(object sender, RoutedEventArgs e)
        {
            Cheques qwe = new Cheques();
            qwe.Left = this.Left;
            qwe.Top = this.Top;
            this.Hide();
            qwe.Show();
        }
    }
}
