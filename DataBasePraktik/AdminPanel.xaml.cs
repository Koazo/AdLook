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

namespace DataBasePraktik
{
    /// <summary>
    /// Логика взаимодействия для AdminPanel.xaml
    /// </summary>
    public partial class AdminPanel : Window
    {
        public AdminPanel()
        {
            InitializeComponent();
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void ListViewMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = ListViewMenu.SelectedIndex;
            MoveCursorMenu(index);

            switch (index)
            {
                case 0:
                    GridMainContent.Children.Clear();
                    GridMainContent.Children.Add(new UserControlItem());
                    break;
                case 1:
                    GridMainContent.Children.Clear();
                    GridMainContent.Children.Add(new AdminController_Products());
                    break;
                case 2:
                    GridMainContent.Children.Clear();
                    GridMainContent.Children.Add(new AdminController_Users());
                    break;
                case 3:
                    GridMainContent.Children.Clear();
                    GridMainContent.Children.Add(new AdminController_Ads());
                    break;
                case 4:
                    GridMainContent.Children.Clear();
                    GridMainContent.Children.Add(new AdminController_Messages());
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            UnregUserPanel unreg = new UnregUserPanel();
            this.Close();
            unreg.Show();

        }
    }
}

