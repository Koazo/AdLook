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
    /// Логика взаимодействия для AdminController_Messages.xaml
    /// </summary>
    public partial class AdminController_Messages : UserControl
    {
        myDataSet messagesDataSet;
        myDataSetTableAdapters.MessagesTableAdapter messagesTableAdapter;
        public AdminController_Messages()
        {
            InitializeComponent();
            messagesDataSet = new myDataSet();
            messagesTableAdapter = new myDataSetTableAdapters.MessagesTableAdapter();
            messagesTableAdapter.Fill(messagesDataSet.Messages);
            dataGrid1.ItemsSource = messagesDataSet.Tables["Messages"].DefaultView;
            dataGrid1.CanUserDeleteRows = false;
            dataGrid1.CanUserAddRows = false;
        }

    }
}
