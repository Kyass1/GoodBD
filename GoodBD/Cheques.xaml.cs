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
    /// Логика взаимодействия для Cheques.xaml
    /// </summary>
    public partial class Cheques : Window
    {
        public Cheques()
        {
            InitializeComponent();
            Refresh();
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
            ChequesTableAdapter A = new ChequesTableAdapter();
            _Artem2_0DataSet1.ChequesDataTable B = new _Artem2_0DataSet1.ChequesDataTable();
            A.Fill(B);
            DG.ItemsSource = B;

            SneakersTableAdapter A1 = new SneakersTableAdapter();
            _Artem2_0DataSet1.SneakersDataTable B1 = new _Artem2_0DataSet1.SneakersDataTable();
            A1.Fill(B1);
            SCB.ItemsSource = B1;
            SCB.DisplayMemberPath = "Name";
            SCB.SelectedValuePath = "ID_Sneakers";


            HoodiesTableAdapter A3 = new HoodiesTableAdapter();
            _Artem2_0DataSet1.HoodiesDataTable B3 = new _Artem2_0DataSet1.HoodiesDataTable();
            A3.Fill(B3);
            HCB.ItemsSource = B3;
            HCB.DisplayMemberPath = "Name";
            HCB.SelectedValuePath = "ID_Hoodie";

            UsersTableAdapter A2 = new UsersTableAdapter();
            _Artem2_0DataSet1.UsersDataTable B2 = new _Artem2_0DataSet1.UsersDataTable();
            A2.Fill(B2);
            UCB.ItemsSource = B2;
            UCB.DisplayMemberPath = "SecondName";
            UCB.SelectedValuePath = "ID_User";

        }
        private void cam24_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Date.SelectedDate > DateTime.Today)
            {
                MessageBox.Show("Дату больше сегодняшней нельзя ввести");
            }
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
               
                    new ChequesTableAdapter().InsertQuery(Convert.ToString(Date.SelectedDate), Convert.ToInt32(UCB.SelectedValue), Convert.ToInt32(SCB.SelectedValue), Convert.ToInt32(HCB.SelectedValue), 1);
                    Refresh();
               
            }
            catch
            {
                MessageBox.Show("Не могу добавить");
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
        //    try
        //    {
                new SneakersTableAdapter().DeleteQuery(Convert.ToInt32((DG.SelectedItems[0] as DataRowView).Row.ItemArray[0]));
                Refresh();
        //    }
         //   catch
         //   {
         //       MessageBox.Show("Не могу удалить");
        //    }
        }

       
        private void cam22_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = "0123456789".IndexOf(e.Text) < 0;
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
