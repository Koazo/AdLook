using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    public class GoodMiniObject
    {
        public string Title { get; set; }
        public string ImagePath { get; set; }
        public string Description { get; set; }
        public string Price { get; set; }

    }
    public partial class UnregUserPanel : Window
    {
        public bool goodCurrentForm = false;
        myDataSet currentDataSet;
        myDataSetTableAdapters.GoodsTableAdapter goodsTableAdapter =new myDataSetTableAdapters.GoodsTableAdapter();
        public ObservableCollection<GoodMiniObject> GoodMiniObjects{ get; set; }
        public UnregUserPanel()
        {
            InitializeComponent();

            GoodMiniObjects = new ObservableCollection<GoodMiniObject>();
            //{
            //    new GoodMiniObject { Title = "45678", ImagePath = @"Assets/imacretina27.jpg", Description = "Тестовый описание с кучами бла бла бла бла бла бла бла бла бла", Price = "1999$" },
                

            //new GoodMiniObject { Title = "Xiaomi Mi Air 13.3 2018", ImagePath = @"Assets/miair133.jpg", Description = "Тестовый описание с кучами бла бла бла бла бла бла бла бла бла", Price = "1999$" },
            //    new GoodMiniObject { Title = "Xiaomi Redmi Note 7", ImagePath = @"Assets/redminote7.jpg", Description = "Тестовый описание с кучами бла бла бла бла бла бла бла бла бла", Price = "1999$" },
            //    new GoodMiniObject { Title = "IMac Retine 5K 27' 2019", ImagePath = @"Assets/imacretina27.jpg", Description = "Тестовый описание с кучами бла бла бла бла бла бла бла бла бла", Price = "1999$" },
            //    new GoodMiniObject { Title = "IMac Retine 5K 27' 2019", ImagePath = @"Assets/redminote7.jpg", Description = "Тестовый описание с кучами бла бла бла бла бла бла бла бла бла", Price = "1999$" },
            //    new GoodMiniObject { Title = "IMac Retine 5K 27' 2019", ImagePath = @"Assets/imacretina27.jpg", Description = "Тестовый описание с кучами бла бла бла бла бла бла бла бла бла", Price = "1999$" }
            //};
            DataTable goods = goodsTableAdapter.GetData();
            foreach (DataRow a in goods.Rows)
            {
                GoodMiniObjects.Add(new GoodMiniObject { Title = a.ItemArray[1].ToString(), ImagePath = a.ItemArray[7].ToString(), Description = a.ItemArray[2].ToString(), Price = a.ItemArray[6].ToString() + "$"});
            }


        GoodsList.ItemsSource = GoodMiniObjects;
            currentDataSet = new myDataSet();
            
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
        public Good good = new Good();
        private void ListViewMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = ListViewMenu.SelectedIndex;
            MoveCursorMenu(index);

            switch (index)
            {
                case 0:
                    //GridMainContent.Children.Clear();
                    // GridMainContent.Children.Add(new UserControlItem());
                   
            
                    break;
                case 1:
                   // GridMainContent.Children.Clear();
                    MessageBox.Show("Вы должны зарегестрироваться");
                    break;
                case 2:
                   // GridMainContent.Children.Clear();
                    MessageBox.Show("Вы должны зарегестрироваться");
                    break;
                case 3:
                   // GridMainContent.Children.Clear();
                    MessageBox.Show("Вы должны зарегестрироваться");
                    break;
                default:
                    break;
            }
        }

        private void MoveCursorMenu(int index)
        {
            TransitioningContentSlide.OnApplyTemplate();
            GridCursor.Margin = new Thickness(0, (100 + (60 * index)), 0, 0);
        }

        private void SignInButton_Click(object sender, RoutedEventArgs e)
        {

            AuthPanel auth = new AuthPanel();
            auth.ShowDialog();
        }

        private void ButtonMessage_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Вы должны зарегестрироваться");
        }

        private void GoodsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
    
}
