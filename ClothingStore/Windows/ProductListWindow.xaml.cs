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

        private void GetListProduct()
        {
            List<Product> products = new List<Product>();
            products = EFClass.Context.Product.ToList();

            LvProduct.ItemsSource = products;
        }
    }
}
