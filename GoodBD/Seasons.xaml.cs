using GoodBD._Artem2_0DataSet1TableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
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
    /// Логика взаимодействия для Seasons.xaml
    /// </summary>
    public partial class Seasons : Window
    {
        public Seasons()
        {
            InitializeComponent();
            Refresh();
        }

        private void cam123(object sender, SelectionChangedEventArgs e)
        {
            if (DG.SelectedItem != null)
                TB.Text = (DG.SelectedItem as DataRowView).Row.ItemArray[1].ToString();
        }
        private void cam21_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (int.TryParse(e.Text, out int i))
            {
                e.Handled = true;
            }
        }

        public void Refresh()
        {
            SeasonsTableAdapter A = new SeasonsTableAdapter();
            _Artem2_0DataSet1.SeasonsDataTable B = new _Artem2_0DataSet1.SeasonsDataTable();
            A.Fill(B);
            DG.ItemsSource = B;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                if (TB.Text != "")
                {
                    if (String.IsNullOrWhiteSpace(TB.Text))
                        throw new Exception();
                    new SeasonsTableAdapter().InsertQuery(TB.Text);
                    Refresh();
                }
                else
                    MessageBox.Show("Не могу добавить");
            }
            catch
            {
                MessageBox.Show("Не могу добавить");
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            try
            {
                new SeasonsTableAdapter().DeleteQuery(Convert.ToInt32((DG.SelectedItems[0] as DataRowView).Row.ItemArray[0]));
                Refresh();
            }
            catch
            {
                MessageBox.Show("Не могу удалить");
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            try
            {

                if (TB.Text != "")
                {
                    if (String.IsNullOrWhiteSpace(TB.Text))
                        throw new Exception();
                    new SeasonsTableAdapter().UpdateQuery(TB.Text, (Convert.ToInt32((DG.SelectedItems[0] as DataRowView).Row.ItemArray[0])));
                    Refresh();
                }
                else
                    MessageBox.Show("Не могу измениить");
            }
            catch
            {
                MessageBox.Show("Не могу изменить");
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Main qwe = new Main();
            qwe.Left = this.Left;
            qwe.Top = this.Top;
            this.Hide();
            qwe.Show();
        }
    }
}
