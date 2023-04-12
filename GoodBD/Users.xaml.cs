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
    /// Логика взаимодействия для Users.xaml
    /// </summary>
    public partial class Users : Window
    {
        public Users()
        {
            InitializeComponent();
            Refresh();
        }

        private void cam123(object sender, SelectionChangedEventArgs e)
        {
            if (DG.SelectedItem != null)
            {
                SN.Text = (DG.SelectedItem as DataRowView).Row.ItemArray[1].ToString();
                FN.Text = (DG.SelectedItem as DataRowView).Row.ItemArray[2].ToString();
                PA.Text = (DG.SelectedItem as DataRowView).Row.ItemArray[3].ToString();
            }
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
            RolesTableAdapter A = new RolesTableAdapter();
            _Artem2_0DataSet1.RolesDataTable B = new _Artem2_0DataSet1.RolesDataTable();
            A.Fill(B);
            RCB.ItemsSource = B;
            RCB.DisplayMemberPath = "Role";
            RCB.SelectedValuePath = "ID_Role";

            UsersTableAdapter A1 = new UsersTableAdapter();
            _Artem2_0DataSet1.UsersDataTable B1 = new _Artem2_0DataSet1.UsersDataTable();
            A1.Fill(B1);
            DG.ItemsSource = B1;



        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                if (SN.Text != "" || FN.Text != "")
                {
                    if (String.IsNullOrWhiteSpace(SN.Text) || String.IsNullOrWhiteSpace(FN.Text))
                        throw new Exception();
                    new UsersTableAdapter().InsertQuery(SN.Text, FN.Text, PA.Text,  Convert.ToInt32(RCB.SelectedValue));
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
                new UsersTableAdapter().DeleteQuery(Convert.ToInt32((DG.SelectedItems[0] as DataRowView).Row.ItemArray[0]));
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

                if (SN.Text != "" || FN.Text != "")
                {
                    if (String.IsNullOrWhiteSpace(SN.Text) || String.IsNullOrWhiteSpace(FN.Text))
                        throw new Exception();
                    new UsersTableAdapter().UpdateQuery(SN.Text, FN.Text, PA.Text, Convert.ToInt32(RCB.SelectedValue), (Convert.ToInt32((DG.SelectedItems[0] as DataRowView).Row.ItemArray[0])));
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
