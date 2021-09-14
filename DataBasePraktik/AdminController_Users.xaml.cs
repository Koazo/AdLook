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
using System.Data.Sql;
using System.Data;
using DataBasePraktik.myDataSetTableAdapters;
namespace DataBasePraktik
{
    /// <summary>
    /// Логика взаимодействия для AdminController_Users.xaml
    /// </summary>
    public partial class AdminController_Users : UserControl
    {
        myDataSet currentDataSet;
        myDataSetTableAdapters.UsersTableAdapter usersTableAdapter;
        public AdminController_Users()
        {
            InitializeComponent();
            currentDataSet = new myDataSet();
            usersTableAdapter = new myDataSetTableAdapters.UsersTableAdapter();
            usersTableAdapter.Fill(currentDataSet.Users);
            dataGrid1.ItemsSource = currentDataSet.Tables["Users"].DefaultView;
            dataGrid1.CanUserDeleteRows = false;
            dataGrid1.CanUserAddRows = false;

            new RolesTableAdapter().Fill(currentDataSet.Roles);
            ComboboxRoles.ItemsSource = currentDataSet.Roles;
            ComboboxRoles.DisplayMemberPath = "ID_Role";
            ComboboxRoles.SelectedValuePath = "ID_Role";
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            usersTableAdapter.InsertQuery_Users(textBoxUserPhone.Text, textBoxUserMail.Text, textBoxUsername.Text, textBoxUserPassword.Text);
            usersTableAdapter.Fill(currentDataSet.Users);
        }

        private void ButtonUpdate_Click(object sender, RoutedEventArgs e)
        {
            DataRowView selectedDataRow = (DataRowView)dataGrid1.SelectedItem;
            if (selectedDataRow != null)
            {
                usersTableAdapter.UpdateQuery_Users(textBoxUsername.Text,textBoxUserPhone.Text,textBoxUserMail.Text,Convert.ToInt32(ComboboxRoles.Text),textBoxUserPassword.Text,Convert.ToInt32(selectedDataRow.Row.ItemArray[0]));
                usersTableAdapter.Fill(currentDataSet.Users);
            }
            else
            {
                MessageBox.Show("Выберите запись в таблице");
            }
        }

        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            foreach (var Item in dataGrid1.SelectedItems)
            {
                //DataRowView selectedDataRow = (DataRowView)dataGrid1.SelectedItem;
                if (Item != null)
                {
                    usersTableAdapter.DeleteQuery_Users(Convert.ToInt32((Item as DataRowView).Row.ItemArray[0]));

                }
                else
                {
                    MessageBox.Show("Выберите запись в таблице");
                }

            }
            usersTableAdapter.Fill(currentDataSet.Users);
        }

        private void dataGrid1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataRowView selectedDataRow = (DataRowView)dataGrid1.SelectedItem;
            if (selectedDataRow != null)
            {
                textBoxUsername.Text = selectedDataRow.Row.ItemArray[4].ToString();
                textBoxUserPhone.Text = selectedDataRow.Row.ItemArray[1].ToString();
                textBoxUserMail.Text = selectedDataRow.Row.ItemArray[2].ToString();
                ComboboxRoles.Text = selectedDataRow.Row.ItemArray[3].ToString();
                textBoxUserPassword.Text = selectedDataRow.Row.ItemArray[5].ToString();
            }
        }
    }
}
