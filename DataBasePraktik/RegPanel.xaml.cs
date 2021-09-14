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
using System.Data.SqlClient;
using System.Data;
using DataBasePraktik.myDataSetTableAdapters;

namespace DataBasePraktik
{
    /// <summary>
    /// Логика взаимодействия для RegPanel.xaml
    /// </summary>
    public partial class RegPanel : Window
    {
        myDataSet usersDataSet;
        myDataSetTableAdapters.UsersTableAdapter usersTableAdapter;
        public RegPanel()
        {
            InitializeComponent();
            usersDataSet = new myDataSet();
            usersTableAdapter = new myDataSetTableAdapters.UsersTableAdapter();
            usersTableAdapter.Fill(usersDataSet.Users);
        }

        private void ButtonRegister_Click(object sender, RoutedEventArgs e)
        {
            if (TextboxPassword.Text == "")
                MessageBox.Show("Введены некорректные данные");
            else
            {
                usersTableAdapter.InsertQuery_Users(TextboxNumber.Text, TextboxMail.Text, TextboxLogin.Text, TextboxPassword.Text);
                UnregUserPanel unreg = new UnregUserPanel();
                this.Close();
                unreg.Show();
            }
        }

        private void TextboxLogin_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TextboxLogin_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                e.Handled = true;
            }
        }

        private void TextboxPassword_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                e.Handled = true;
            }
        }

        private void TextboxNumber_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                e.Handled = true;
            }
        }

        private void TextboxMail_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                e.Handled = true;
            }
        }
    }
}
