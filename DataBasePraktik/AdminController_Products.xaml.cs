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
using Microsoft.Win32;

namespace DataBasePraktik
{
    /// <summary>
    /// Логика взаимодействия для AdminController_Products.xaml
    /// </summary>
    public partial class AdminController_Products : UserControl
    {
        public string imagePath;
        myDataSet currentDataSet;
        myDataSetTableAdapters.GoodsTableAdapter goodsTableAdapter;

        public AdminController_Products()
        {
            InitializeComponent();
            currentDataSet = new myDataSet();
            goodsTableAdapter = new myDataSetTableAdapters.GoodsTableAdapter();
            goodsTableAdapter.Fill(currentDataSet.Goods);
            dataGrid1.ItemsSource = currentDataSet.Tables["Goods"].DefaultView;
            dataGrid1.CanUserAddRows = false;
            dataGrid1.CanUserDeleteRows = false;

            new CategoriesTableAdapter().Fill(currentDataSet.Categories);
            comboBoxCategories.ItemsSource = currentDataSet.Categories;
            comboBoxCategories.DisplayMemberPath = "ID_Category";
            comboBoxCategories.SelectedValuePath = "ID_Category";

            new TypesTableAdapter().Fill(currentDataSet.Types);
            comboBoxType.ItemsSource = currentDataSet.Types;
            comboBoxType.DisplayMemberPath = "ID_Type";
            comboBoxType.SelectedValuePath = "ID_Type";

            //comboBoxMark
            new MarksTableAdapter().Fill(currentDataSet.Marks);
            comboBoxMark.ItemsSource = currentDataSet.Marks;
            comboBoxMark.DisplayMemberPath = "ID_Mark";
            comboBoxMark.SelectedValuePath = "ID_Mark";
            //comboBoxLocation

            new LocationsTableAdapter().Fill(currentDataSet.Locations);
            comboBoxLocation.ItemsSource = currentDataSet.Locations;
            comboBoxLocation.DisplayMemberPath = "ID_Location";
            comboBoxLocation.SelectedValuePath = "ID_Location";

        }



        private void ButtonInsert_Click(object sender, RoutedEventArgs e)
        {

            if (textBoxName.Text == "")
                MessageBox.Show("Введены некорректные данные");
            else
            {
                goodsTableAdapter.InsertQuery_Goods(textBoxName.Text, textBoxDescription.Text, Convert.ToInt32(comboBoxCategories.Text), Convert.ToInt32(comboBoxType.Text), Convert.ToInt32(comboBoxMark.Text), Convert.ToInt32(textBoxPrice.Text), imagePath, Convert.ToInt32(comboBoxLocation.Text), isSoldCheck.IsChecked.Value);
                goodsTableAdapter.Fill(currentDataSet.Goods);
            }

        }

        private void ButtonUpdate_Click(object sender, RoutedEventArgs e)
        {
            DataRowView selectedDataRow = (DataRowView)dataGrid1.SelectedItem;
            if (selectedDataRow != null)
            {
                goodsTableAdapter.UpdateQuery_Goods(textBoxName.Text, textBoxDescription.Text, Convert.ToInt32(comboBoxCategories.Text), Convert.ToInt32(comboBoxType.Text), Convert.ToInt32(comboBoxMark.Text), Convert.ToInt32(textBoxPrice.Text), imagePath, Convert.ToInt32(comboBoxLocation.Text), isSoldCheck.IsChecked.Value, Convert.ToInt32(selectedDataRow.Row.ItemArray[0]));
                goodsTableAdapter.Fill(currentDataSet.Goods);
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
                    goodsTableAdapter.DeleteQuery_Goods(Convert.ToInt32((Item as DataRowView).Row.ItemArray[0]));

                }
                else
                {
                    MessageBox.Show("Выберите запись в таблице");
                }

            }
            goodsTableAdapter.Fill(currentDataSet.Goods);
        }

        private void ButtonSetImage_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Png files (*.png)| *.png | Jpg giles (*.jpg)| *.jpg";
            imagePath = openFileDialog.FileName.ToString();
            openFileDialog.ShowDialog();
            ImageSource image = new BitmapImage(new Uri(imagePath, UriKind.Relative));
            imageBox.Source = image;
            
        }

        private void textBoxName_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                e.Handled = true;
            }
        }
    }
}
