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
    /// Логика взаимодействия для Warehouses.xaml
    /// </summary>
    public partial class Warehouses : Window
    {
        public Warehouses()
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
            WarehousesTableAdapter A = new WarehousesTableAdapter();
            _Artem2_0DataSet1.WarehousesDataTable B = new _Artem2_0DataSet1.WarehousesDataTable();
            A.Fill(B);
            DG.ItemsSource = B;

            CountriesTableAdapter A1 = new CountriesTableAdapter();
            _Artem2_0DataSet1.CountriesDataTable B1 = new _Artem2_0DataSet1.CountriesDataTable();
            A1.Fill(B1);
            CCB.ItemsSource = B1;
            CCB.DisplayMemberPath = "Country";
            CCB.SelectedValuePath = "ID_Country";


            ProvidersTableAdapter A2 = new ProvidersTableAdapter();
            _Artem2_0DataSet1.ProvidersDataTable B2 = new _Artem2_0DataSet1.ProvidersDataTable();
            A2.Fill(B2);
            PCB.ItemsSource = B2;
            PCB.DisplayMemberPath = "Provider";
            PCB.SelectedValuePath = "ID_Provider";

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                if (TB.Text != "")
                {
                    if (String.IsNullOrWhiteSpace(TB.Text))
                        throw new Exception();
                    new WarehousesTableAdapter().InsertQuery(TB.Text, Convert.ToInt32(PCB.SelectedValue), Convert.ToInt32(CCB.SelectedValue));
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
                new WarehousesTableAdapter().DeleteQuery(Convert.ToInt32((DG.SelectedItems[0] as DataRowView).Row.ItemArray[0]));
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
                    new WarehousesTableAdapter().UpdateQuery(TB.Text, Convert.ToInt32(PCB.SelectedValue), Convert.ToInt32(CCB.SelectedValue), (Convert.ToInt32((DG.SelectedItems[0] as DataRowView).Row.ItemArray[0])));
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
