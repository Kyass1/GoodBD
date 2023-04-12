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
    /// Логика взаимодействия для Hoodies.xaml
    /// </summary>
    public partial class Hoodies : Window
    {
        public Hoodies()
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

        private void cam22_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = "0123456789".IndexOf(e.Text) < 0;
        }

        public void Refresh()
        {
            HoodiesTableAdapter A = new HoodiesTableAdapter();
            _Artem2_0DataSet1.HoodiesDataTable B = new _Artem2_0DataSet1.HoodiesDataTable();
            A.Fill(B);
            DG.ItemsSource = B;

            SeasonsTableAdapter A1 = new SeasonsTableAdapter();
            _Artem2_0DataSet1.SeasonsDataTable B1 = new _Artem2_0DataSet1.SeasonsDataTable();
            A1.Fill(B1);
            SCB.ItemsSource = B1;
            SCB.DisplayMemberPath = "Season";
            SCB.SelectedValuePath = "ID_Season";


            WarehousesTableAdapter A2 = new WarehousesTableAdapter();
            _Artem2_0DataSet1.WarehousesDataTable B2 = new _Artem2_0DataSet1.WarehousesDataTable();
            A2.Fill(B2);
            WCB.ItemsSource = B2;
            WCB.DisplayMemberPath = "Adress";
            WCB.SelectedValuePath = "ID_Warehouse";

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                if (TB.Text != "")
                {
                    if (String.IsNullOrWhiteSpace(TB.Text))
                        throw new Exception();
                    new HoodiesTableAdapter().InsertQuery(TB.Text, Convert.ToInt32(SCB.SelectedValue), Convert.ToInt32(WCB.SelectedValue), Convert.ToDecimal(SA.Text));
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
                new HoodiesTableAdapter().DeleteQuery(Convert.ToInt32((DG.SelectedItems[0] as DataRowView).Row.ItemArray[0]));
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
                    new HoodiesTableAdapter().UpdateQuery(TB.Text, Convert.ToInt32(SCB.SelectedValue), Convert.ToInt32(WCB.SelectedValue), Convert.ToDecimal(SA.Text),(Convert.ToInt32((DG.SelectedItems[0] as DataRowView).Row.ItemArray[0])));
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
