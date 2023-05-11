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

namespace ClothingStore.Windows
{
    /// <summary>
    /// Логика взаимодействия для ProductListWindow.xaml
    /// </summary>
    public partial class ProductListWindow : Window
    {
        public ProductListWindow()
        {
            InitializeComponent();

            GetListProduct();
        }

        private void GetCountCartProduct()
        {
            TxtCartCount.Text = ClassHelper.CartClass.products.Count.ToString();
        }

        private void GetListProduct()
        {
            List<Product> products = new List<Product>();
            products = EFClass.Context.Product.ToList();

            LvProduct.ItemsSource = products;
        }

        private void BtnAddProduct_Click(object sender, RoutedEventArgs e)
        {
            // переход на окно добавления товара
            AddEditProductWindow addEditProductWindow = new AddEditProductWindow();
            addEditProductWindow.ShowDialog();

            GetListProduct();
            GetCountCartProduct();
        }

        private void BtnMore_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            if (button == null)
            {
                return;
            }

            Product selectedProduct = button.DataContext as Product;

            AddEditProductWindow addEditProductWindow = new AddEditProductWindow(selectedProduct);
            addEditProductWindow.ShowDialog();

            GetListProduct();
            GetCountCartProduct();

        }

        private void BtnCart_Click(object sender, RoutedEventArgs e)
        {
            // добавление в корзину

            Button button = sender as Button;
            if (button == null)
            {
                return;
            }

            Product selectedProduct = button.DataContext as Product;

            ClassHelper.CartClass.products.Add(selectedProduct);

            GetCountCartProduct();
        }

        private void BtnGoToCart_Click(object sender, RoutedEventArgs e)
        {
            CArtWindow cArtWindow = new CArtWindow();
            cArtWindow.Show();
            this.Close();

            GetCountCartProduct();
        }
    }
}
