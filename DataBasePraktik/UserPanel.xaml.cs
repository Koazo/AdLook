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

namespace DataBasePraktik
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class UserPanel : Window
    {
        public UserPanel()
        {
            InitializeComponent();
        }

        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
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
                    break;
                case 2:
                    GridMainContent.Children.Clear();
                    break;
                case 3:
                    GridMainContent.Children.Clear();
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

        private void ButtonExit_Click(object sender, RoutedEventArgs e)
        {
            UnregUserPanel unreg = new UnregUserPanel();
            this.Close();
            unreg.Show();
            
        }
    }
}
