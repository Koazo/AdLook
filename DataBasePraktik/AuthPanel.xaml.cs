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
    /// Логика взаимодействия для AuthPanel.xaml
    /// </summary>
    public partial class AuthPanel : Window
    {
        myDataSet usersDataSet;
        myDataSetTableAdapters.UsersTableAdapter usersTableAdapter;
        public AuthPanel()
        {
            InitializeComponent();
            usersDataSet = new myDataSet();
            usersTableAdapter = new myDataSetTableAdapters.UsersTableAdapter();
            usersTableAdapter.Fill(usersDataSet.Users);
        }

        private void ButtonSignIn_Click(object sender, RoutedEventArgs e)
        {
            bool isUserExist = false;
            if (TextboxLogin.Text.Length > 0 && TextboxPassword.Text.Length > 0)
            {
                int Count = usersTableAdapter.GetUsers(TextboxLogin.Text, TextboxPassword.Text).Count;
                //MessageBox.Show(Count.ToString());
                if (Count > 0)
                {
                    isUserExist = true;
                }
                else
                {
                    MessageBox.Show("Вы ввели некорректные данные");
                }
                if (isUserExist)
                {
                    //MessageBox.Show((Convert.ToInt32(usersTableAdapter.GetUserId(TextboxLogin.Text, TextboxPassword.Text))).ToString()) ;
                    if (1 == Convert.ToInt32(usersTableAdapter.GetUserId(TextboxLogin.Text, TextboxPassword.Text)))
                    {
                        AdminPanel admin = new AdminPanel();
                        this.Close();
                        admin.Show();

                    }
                    else if (2 == Convert.ToInt32(usersTableAdapter.GetUserId(TextboxLogin.Text, TextboxPassword.Text)))
                    {
                        UserPanel user = new UserPanel();
                        this.Close();
                        user.Show();

                    }
                    else
                    {
                        MessageBox.Show("Не существует такого пользователя");
                    }
                }
            }
            else
            {
                MessageBox.Show("Заполните поля");
            }
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            RegPanel reg = new RegPanel();
            this.Close();
            reg.ShowDialog();

        }

        private void TextboxLogin_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                e.Handled = true;
            }
        }
    }
}
