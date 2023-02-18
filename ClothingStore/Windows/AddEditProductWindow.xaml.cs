using Microsoft.Win32;
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

using ClothingStore.ClassHelper;
using ClothingStore.Windows;
using ClothingStore.DB;
using System.IO;

namespace ClothingStore.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddEditProductWindow.xaml
    /// </summary>
    public partial class AddEditProductWindow : Window
    {
        private string pathImageProduct = null;

        public AddEditProductWindow()
        {
            InitializeComponent();

            CmbCategory.ItemsSource = EFClass.Context.Category.ToList();
            CmbCategory.DisplayMemberPath = "Name";
            CmbCategory.SelectedIndex = 0;
        }

        private void BtnChooseImage_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                ImgProduct.Source = new BitmapImage(new Uri(openFileDialog.FileName));

                pathImageProduct = openFileDialog.FileName; 
            }
        }

        private void BtnAddProduct_Click(object sender, RoutedEventArgs e)
        {
            // валидация 

            // добавление
            Product product = new Product();
            product.Name = TbName.Text;
            product.Price = Convert.ToDecimal(TbPrice.Text);
            product.IDCategory = (CmbCategory.SelectedItem as Category).IDCategory;
            if (pathImageProduct != null)
            {
                product.ProductImage = File.ReadAllBytes(pathImageProduct);
            }
            

            EFClass.Context.Product.Add(product);
            EFClass.Context.SaveChanges();

            MessageBox.Show("Товар добавлен");

            this.Close();
        }
    }
}
