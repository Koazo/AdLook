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
using System.Data.SqlClient;
using System.Data;
using DataBasePraktik.myDataSetTableAdapters;

namespace DataBasePraktik
{
    /// <summary>
    /// Логика взаимодействия для AdminController_Ads.xaml
    /// </summary>
    public partial class AdminController_Ads : UserControl
    {
        myDataSet currentDataSet;
        myDataSetTableAdapters.AdsTableAdapter adsTableAdapter;
        public AdminController_Ads()
        {
            InitializeComponent();
            currentDataSet = new myDataSet();
            adsTableAdapter = new myDataSetTableAdapters.AdsTableAdapter();
            adsTableAdapter.Fill(currentDataSet.Ads);
            dataGrid1.ItemsSource = currentDataSet.Tables["Ads"].DefaultView;
            dataGrid1.CanUserAddRows = false;
            dataGrid1.CanUserDeleteRows = false;

            new UsersTableAdapter().Fill(currentDataSet.Users);
            comboBoxSeller.ItemsSource = currentDataSet.Users;
            comboBoxSeller.DisplayMemberPath = "ID_User";
            comboBoxSeller.SelectedValuePath = "ID_User";
        }

        private void ButtonInsert_Click(object sender, RoutedEventArgs e)
        {
            adsTableAdapter.InsertQuery_Ads(textBoxName.Text, Convert.ToInt32(comboBoxSeller.Text), AddDate.Text);
            adsTableAdapter.Fill(currentDataSet.Ads);
        }

        private void ButtonUpdate_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            foreach (var Item in dataGrid1.SelectedItems)
            {
                //DataRowView selectedDataRow = (DataRowView)dataGrid1.SelectedItem;
                if (Item != null)
                {
                    adsTableAdapter.DeleteQuery_Ads((Convert.ToInt32((Item as DataRowView).Row.ItemArray[0])));

                }
                else
                {
                    MessageBox.Show("Выберите запись в таблице");
                }

            }
            adsTableAdapter.Fill(currentDataSet.Ads);
        }

        private void dataGrid1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
